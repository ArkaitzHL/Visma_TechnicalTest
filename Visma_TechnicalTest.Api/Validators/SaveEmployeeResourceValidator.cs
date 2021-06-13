using FluentValidation;
using Visma_TechnicalTest.Api.Resources;

namespace Visma_TechnicalTest.Api.Validators
{
    public class SaveEmployeeResourceValidator : AbstractValidator<SaveEmployeeResource>
    {
        public SaveEmployeeResourceValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(x => x.SocialSecurityNumber)
                .NotEmpty()
                .MaximumLength(12);

            RuleFor(x => x.Phone)
                .MaximumLength(15);
        }
    }
}
