using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Strings
{
    public class IfNullOrWhiteSpaceValidationTests
    {
        [Fact]
        public void Null_IfNullOrWhiteSpace_OneError()
        {
            // Arrange
            string client = null;


            // Act
            var act = client.Validate()
                .IfNullOrWhiteSpace();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == ErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(client)}' cannot be null or white spaces"
            );
        }

        [Fact]
        public void Empty_IfNullOrWhiteSpace_OneError()
        {
            // Arrange
            var client = "";


            // Act
            var act = client.Validate()
                .IfNullOrWhiteSpace();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == ErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(client)}' cannot be null or white spaces"
            );
        }

        [Fact]
        public void WithSpace_IfNullOrWhiteSpace_OneError()
        {
            // Arrange
            var client = "      ";


            // Act
            var act = client.Validate()
                .IfNullOrWhiteSpace();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == ErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(client)}' cannot be null or white spaces"
            );
        }

        [Fact]
        public void Value_IfNullOrWhiteSpace_Valid()
        {
            // Arrange
            var client = "fake";


            // Act
            var act = client.Validate()
                .IfNullOrWhiteSpace();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void UnauthorizedError_IfNullOrWhiteSpace_ErrorCode()
        {
            // Arrange
            var t4e = "     ";

            var expectedProperty = "fakeProp fake SPACE";
            var expectedCode = "fakeCode fake SPACE";
            var expectedDescription = $"Fake description fake SPACE > '{expectedProperty}'";


            // Act
            var act = t4e.Validate()
                .IfNullOrWhiteSpace(
                    property => Error.Unauthorized(
                        expectedProperty,
                        expectedCode,
                        expectedDescription
                    )
                );


            // Assert
            act.Errors.Should().HaveCount(1);
            act.Errors.First().Should().BeOfType<UnauthorizedError>();

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
