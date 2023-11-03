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
}