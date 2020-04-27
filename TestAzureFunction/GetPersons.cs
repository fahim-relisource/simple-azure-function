using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SimpleSoapWrapper.Infrastructure;
using SimpleSoapWrapper.Model.Response;
using SimpleSoapWrapper.Service;
using System;
using System.Threading.Tasks;
using AutoMapper;
using SimpleSoapWrapper.Feature.FindPerson;

namespace TestAzureFunction
{
    public class GetPersons
    {
        private readonly IConfigurationProvider _mappingConfigurationProvider;
        private readonly ISoapDemoAPI _soapDemoApi;

        public GetPersons(IConfigurationProvider mappingConfigurationProvider, ISoapDemoAPI soapDemoApi)
        {
            _mappingConfigurationProvider = mappingConfigurationProvider;
            _soapDemoApi = soapDemoApi;
        }

        [FunctionName("GetPersons")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "{path?}")]
            HttpRequest req,
            ILogger log,
            string? path)
        {
            AServiceFeature serviceWrap;

            switch (path)
            {
                case ApiPath.FindPerson:
                    serviceWrap = new FindPersonFeature(req, log, _soapDemoApi, _mappingConfigurationProvider);
                    var serviceResponse = await serviceWrap.ServiceTask();
                    return serviceResponse;
                case ApiPath.PersonList:
                    break;
                case ApiPath.FindAddress:
                    break;
                default:
                    return ApiPath.GetPathInfo();
            }

            return new OkObjectResult(JsonConvert.SerializeObject(new SimpleResponse
            {
                Success = false,
                Data = null,
                Message = "Well!, I should not come here in the first place"
            }));
        }
    }
}