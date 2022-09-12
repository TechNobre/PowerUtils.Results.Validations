using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Network
{
    public class IfNotEmailValidationTests
    {
        [Fact]
        public void Null_IfNotEmail_NoErrors()
        {
            // Arrange
            string clientEmail = null;


            // Act
            var act = clientEmail.Validate()
                .IfNotEmail();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Empty_IfNotEmail_OneError()
        {
            // Arrange
            var clientEmail = "";


            // Act
            var act = clientEmail.Validate()
                .IfNotEmail();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(clientEmail)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(clientEmail)}' is not a valid email"
            );
        }

        [Fact]
        public void WithSpace_IfNotEmail_OneError()
        {
            // Arrange
            var clientEmail = "    ";


            // Act
            var act = clientEmail.Validate()
                .IfNotEmail();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(clientEmail)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(clientEmail)}' is not a valid email"
            );
        }

        [Fact]
        public void FakeText_IfNotEmail_OneError()
        {
            // Arrange
            var clientEmail = "fake";


            // Act
            var act = clientEmail.Validate()
                .IfNotEmail();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(clientEmail)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(clientEmail)}' is not a valid email"
            );
        }

        [Fact]
        public void Email_IfNotEmail_NoErrors()
        {
            // Arrange
            var clientEmail = "fake@fake.tk";


            // Act
            var act = clientEmail.Validate()
                .IfNotEmail();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("fake@fake.com")]
        [InlineData("fake@fake.com.co")]
        [InlineData("nelson.nobre@fake.com")]
        [InlineData("nelson.nobre-@fake.com")]
        [InlineData("nelson.nobre@fake.com.br")]
        [InlineData("nelson.nobre@fake.c0")]
        [InlineData("nelson@fake.xn--6frz82g")]
        [InlineData("nelson@fake.pt6")]
        [InlineData("nelson@fake.6pt")]
        public void AnyEmail_IfNotEmail_NoErrors(string email)
        {
            // Arrange & Act
            var act = email.Validate()
                .IfNotEmail();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("fake@fake..com")]
        [InlineData("fake@.com")]
        [InlineData("@fake.com")]
        [InlineData("nelson")]
        [InlineData("nelson.nobre")]
        [InlineData("nelson.nobre@")]
        [InlineData("nelson.nobre@.com")]
        [InlineData("nelson.nobre@..com")]
        [InlineData("nelson.nobre@fake..com")]
        [InlineData("nelson.nobre@@fake.com")]
        [InlineData("n,nobre@@fake.com")]
        [InlineData("nelson.nobre@fake.")]
        [InlineData("nelson.nobre@fake.com.")]
        [InlineData("´nelson@fake.com")]
        [InlineData("nelson@fake")]
        public void AnyInvalidEmail_IfNotEmail_OneError(string email)
        {
            // Arrange & Act
            var act = email.Validate()
                .IfNotEmail();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(email)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(email)}' is not a valid email"
            );
        }
    }
}
