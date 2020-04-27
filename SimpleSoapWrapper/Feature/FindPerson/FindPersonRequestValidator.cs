using FluentValidation;

namespace SimpleSoapWrapper.Feature.FindPerson
{
    public class FindPersonRequestValidator : AbstractValidator<FindPersonRequest>
    {
        public FindPersonRequestValidator()
        {
            RuleFor(x => x.PersonId).NotEmpty();
        }
    }
}
