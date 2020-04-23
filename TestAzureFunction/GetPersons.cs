using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SimpleSoapWrapper;
using SimpleSoapWrapper.Model;
using SimpleSoapWrapper.Model.Request;
using SimpleSoapWrapper.Model.Response;
using SimpleSoapWrapper.Service;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestAzureFunction
{
    public static class GetPersons
    {
        [FunctionName("GetPersons")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            var functionApiKey = Environment.GetEnvironmentVariable("API_KEY");

            // TODO: Need to validate the request body
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var simpleRequest = JsonConvert.DeserializeObject<SimpleRequest>(requestBody);

            var apiKey = req.Headers["api-key"];
            log.LogInformation($"API Key in Env: {functionApiKey}");
            log.LogInformation($"API Key in Header: {apiKey}");
            if (apiKey != functionApiKey)
                return new UnauthorizedResult();

            var simpleResponse = new SimpleResponse();

            // Auto Mapper Configuration
            var config = new MapperConfiguration(cfg =>
             {
                 cfg.AddProfile(new MappingProfile());
             });

            var mapper = config.CreateMapper();
            // Auto Mapper Configuration

            ISoapDemoAPI soapDemoApi = new SoapDemoAPI();

            if (simpleRequest.FindPerson)
            {
                if (simpleRequest.PersonId > 0)
                {
                    var response = await soapDemoApi.GetPersonById(simpleRequest.PersonId);
                    simpleResponse.Person = mapper.Map<SimplePersonDetails>(response);
                }
                else
                    simpleResponse.Person = "Please provide person-id";
            }

            if (simpleRequest.FindAllPerson)
            {
                var response = await soapDemoApi.GetAllPersons();
                var result = response.Select(pi => mapper.Map<SimplePerson>(pi));

                simpleResponse.PersonList = result;
            }

            if (simpleRequest.FindAddress)
            {
                if (!string.IsNullOrEmpty(simpleRequest.ZipCode))
                {
                    var response = await soapDemoApi.GetCityDetails(simpleRequest.ZipCode);
                    simpleResponse.Address = response;
                }
                else
                    simpleResponse.Address = "Please provide the zip-code";
            }

            var functionResponse = JsonConvert.SerializeObject(simpleResponse);
            return new OkObjectResult(functionResponse);
        }
    }
}