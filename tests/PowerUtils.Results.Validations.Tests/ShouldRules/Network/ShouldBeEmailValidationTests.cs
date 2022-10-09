using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.ShouldRules.Network
{
    public class ShouldBeEmailValidationTests
    {
        [Fact]
        public void Null_ShouldBeEmail_NoErrors()
        {
            // Arrange
            string clientEmail = null;


            // Act
            var act = clientEmail.Validate()
                .ShouldBeEmail();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Empty_ShouldBeEmail_OneError()
        {
            // Arrange
            var clientEmail = "";


            // Act
            var act = clientEmail.Validate()
                .ShouldBeEmail();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(clientEmail)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(clientEmail)}' is not a valid email"
            );
        }

        [Fact]
        public void WithSpace_ShouldBeEmail_OneError()
        {
            // Arrange
            var clientEmail = "    ";


            // Act
            var act = clientEmail.Validate()
                .ShouldBeEmail();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(clientEmail)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(clientEmail)}' is not a valid email"
            );
        }

        [Fact]
        public void FakeText_ShouldBeEmail_OneError()
        {
            // Arrange
            var clientEmail = "fake";


            // Act
            var act = clientEmail.Validate()
                .ShouldBeEmail();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(clientEmail)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(clientEmail)}' is not a valid email"
            );
        }

        [Fact]
        public void Email_ShouldBeEmail_NoErrors()
        {
            // Arrange
            var clientEmail = "fake@fake.tk";


            // Act
            var act = clientEmail.Validate()
                .ShouldBeEmail();


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
        public void AnyEmail_ShouldBeEmail_NoErrors(string email)
        {
            // Arrange & Act
            var act = email.Validate()
                .ShouldBeEmail();


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
        public void AnyInvalidEmail_ShouldBeEmail_OneError(string email)
        {
            // Arrange & Act
            var act = email.Validate()
                .ShouldBeEmail();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(email)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(email)}' is not a valid email"
            );
        }

        [Fact]
        public void ForbiddenError_ShouldBeEmail_ErrorCode()
        {
            // Arrange
            var clientEmail = "fake";

            var expectedProperty = "fakeProp";
            var expectedCode = "fakeCode";
            var expectedDescription = $"Fake 👓 description > '{expectedProperty}'";


            // Act
            var act = clientEmail.Validate()
                .ShouldBeEmail(property =>
                    Error.Forbidden(
                        expectedProperty,
                        expectedCode,
                        expectedDescription
                    )
                );


            // Assert
            act.Errors.Should().HaveCount(1);
            act.Errors.First().Should().BeOfType<ForbiddenError>();

            act.Errors.Should().OnlyContain(c =>
                c.Property == expectedProperty
                &&
                c.Code == expectedCode
                &&
                c.Description == expectedDescription
            );
        }
    }
}
