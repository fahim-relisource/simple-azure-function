using Newtonsoft.Json;
using SimpleSoapWrapper.Model.Response;
using System;
using System.ComponentModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace TestAzureFunction
{
    public class ApiPath
    {
        [Description("Get the person details with person id")]
        public const string FindPerson = "find-person";

        [Description("Get the list of person")]
        public const string PersonList = "person-list";

        [Description("Find the address with the given zip-code")]
        public const string FindAddress = "find-address";

        public static IActionResult GetPathInfo()
        {
            var classFields = typeof(ApiPath).GetFields();
            var pathInfos = classFields.Select(field => new
            {
                path = field.GetRawConstantValue(),
                desc = (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute)
                    ?.Description
            });
            var response = new SimpleResponse
            {
                Data = pathInfos,
                Message = "Not a valid endpoint"
            };
            var jsonResponse = JsonConvert.SerializeObject(response);
            return new OkObjectResult(jsonResponse);
        }
    }
}