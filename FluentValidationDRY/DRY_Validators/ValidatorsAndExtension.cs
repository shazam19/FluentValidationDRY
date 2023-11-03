using FluentValidation;

namespace FluentValidationDRY.DRY_Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email)
                .MustBeValidEmail()
                .MustNotBeTemporaryEmail();
        }
    }

    public class OrganizationValidator : AbstractValidator<Organization>
    {
        public OrganizationValidator()
        {
            RuleFor(x => x.Email)
                .MustBeValidEmail()
                .MustNotBeTemporaryEmail();
        }
    }

    public static class EmailValidationExtension
    {
        public static IRuleBuilderOptions<T, string> MustBeValidEmail<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                .EmailAddress().WithMessage("Invalid email address");
        }

        public static IRuleBuilderOptions<T, string> MustNotBeTemporaryEmail<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Must(NotBeTemporaryEmail);
        }

        private static bool NotBeTemporaryEmail(string email)
        {
            return !email.ToLower().EndsWith("yopmail.com");
        }
    }
}