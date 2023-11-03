using FluentValidation;

namespace FluentValidationDRY.WET_Validators
{
    public class OrganizationValidator : AbstractValidator<Organization>
    {
        public OrganizationValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Must(NotBeTemporaryEmail);
        }

        private static bool NotBeTemporaryEmail(string email)
        {
            return email.ToLower().EndsWith("yopmail.com");
        }
    }
}