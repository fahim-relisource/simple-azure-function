using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleSoapWrapper.Model.Request;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SimpleSoapWrapper.Infrastructure
{
    public abstract class AServiceFeature : IServiceFeature
    {
        protected HttpRequest Request;
        protected ILogger Logger;

        protected AServiceFeature(HttpRequest req, ILogger logger)
        {
            Request = req;
            Logger = logger;
        }

        public abstract Task<IActionResult> ServiceTask();

        public async Task<ValidationResult> ValidateRequest<T, TV>()
            where T : AServiceRequest
            where TV : AbstractValidator<T>, new()
        {
            var validator = new TV();
            var requestObject = await GetRequestObject<T>();
            return await validator.ValidateAsync(requestObject);
        }

        public async Task<T> GetRequestObject<T>() where T : AServiceRequest
        {
            var requestBody = "";
            Request.EnableBuffering();
            var requestStream = Request.Body;
            using (var streamReader = new StreamReader(requestStream, bufferSize: -1, leaveOpen: true))
            {
                requestBody = await streamReader.ReadToEndAsync();

                if (requestStream.CanSeek)
                    requestStream.Seek(0, SeekOrigin.Begin);
            }

            if (string.IsNullOrEmpty(requestBody))
                requestBody = "{}";
            var request = JsonConvert.DeserializeObject<T>(requestBody);
            return request;
        }
    }
}