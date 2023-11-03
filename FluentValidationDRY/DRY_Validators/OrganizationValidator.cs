using FluentValidation;

namespace FluentValidationDRY.DRY_Validators
{
    public class OrganizationValidator : AbstractValidator<Organization>
    {
        public OrganizationValidator()
        {
            RuleFor(x => x.Email)
                .MustBeValidEmail()
                .MustNotBeTemporaryEmail();
        }
    }
}