using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using SimpleSoapWrapper.Model.Request;

namespace SimpleSoapWrapper.Infrastructure
{
    public interface IServiceFeature
    {
        Task<IActionResult> ServiceTask();

        Task<ValidationResult> ValidateRequest<T, TV>()
            where T : AServiceRequest
            where TV : AbstractValidator<T>, new();

        Task<T> GetRequestObject<T>() where T : AServiceRequest;
    }
}