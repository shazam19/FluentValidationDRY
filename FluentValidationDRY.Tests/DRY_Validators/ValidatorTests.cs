using FluentValidationDRY.DRY_Validators;

namespace FluentValidationDRY.Tests.DRY_Validators
{
    public class ValidatorTests
    {
        [Theory]
        [InlineData("test@example.com", true)]
        [InlineData("invalid-email", false)]
        [InlineData("", false)]
        [InlineData("temporary@yopmail.com", false)]
        public void UserValidator_Should_ValidateEmail(string email, bool expectedIsValid)
        {
            // Arrange
            var userValidator = new UserValidator();
            var user = new User { Email = email };

            // Act
            var result = userValidator.Validate(user);

            // Assert
            Assert.Equal(expectedIsValid, result.IsValid);
        }

        [Theory]
        [InlineData("test@organization.com", true)]
        [InlineData("invalid-email", false)]
        [InlineData("", false)]
        [InlineData("temporary@yopmail.com", false)]
        public void OrganizationValidator_Should_ValidateEmail(string email, bool expectedIsValid)
        {
            // Arrange
            var organizationValidator = new OrganizationValidator();
            var organization = new Organization { Email = email };

            // Act
            var result = organizationValidator.Validate(organization);

            // Assert
            Assert.Equal(expectedIsValid, result.IsValid);
        }
    }

}