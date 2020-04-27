using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SimpleSoapWrapper.Infrastructure;
using SimpleSoapWrapper.Model;
using SimpleSoapWrapper.Model.Response;
using SimpleSoapWrapper.Service;

namespace SimpleSoapWrapper.Feature.FindPerson
{
    public class FindPersonFeature : AServiceFeature
    {
        private readonly IMapper _mapper;

        private readonly ISoapDemoAPI _soapDemoApi;

        public FindPersonFeature(HttpRequest req, ILogger logger, ISoapDemoAPI soapDemoApi,
            IConfigurationProvider mappingConfigurationProvider) : base(req, logger)
        {
            _soapDemoApi = soapDemoApi;
            _mapper = mappingConfigurationProvider.CreateMapper();
        }

        public override async Task<IActionResult> ServiceTask()
        {
            var validatorResult = await ValidateRequest<FindPersonRequest, FindPersonRequestValidator>();
            if (!validatorResult.IsValid)
            {
                var errors = validatorResult.Errors.Select(e => new
                {
                    field = e.PropertyName,
                    error = e.ErrorMessage
                });
            
                return new BadRequestObjectResult(JsonConvert.SerializeObject(
                    new SimpleResponse
                    {
                        Success = false,
                        Data = null,
                        Message = errors
                    }));
            }

            var request = await GetRequestObject<FindPersonRequest>();

            var response = await _soapDemoApi.GetPersonById(request.PersonId);
            var person = _mapper.Map<SimplePersonDetails>(response);
            return new OkObjectResult(JsonConvert.SerializeObject(new SimpleResponse
            {
                Data = person
            }));
        }
    }
}