using FluentValidation;

namespace FluentValidationDRY.WET_Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .Must(NotBeTemporaryEmail);
        }

        private bool NotBeTemporaryEmail(string email)
        {
            return !email.ToLower().EndsWith("yopmail.com");
        }
    }
}