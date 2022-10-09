using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Strings
{
    public class IfNullOrEmptyValidationTests
    {
        [Fact]
        public void Null_IfNullOrEmpty_OneError()
        {
            // Arrange
            string client = null;


            // Act
            var act = client.Validate()
                .IfNullOrEmpty();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == Errors.Codes.REQUIRED
                &&
                c.Description == $"The '{nameof(client)}' cannot be null or empty"
            );
        }

        [Fact]
        public void Empty_IfNullOrEmpty_OneError()
        {
            // Arrange
            var client = "";


            // Act
            var act = client.Validate()
                .IfNullOrEmpty();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == Errors.Codes.REQUIRED
                &&
                c.Description == $"The '{nameof(client)}' cannot be null or empty"
            );
        }

        [Fact]
        public void Value_IfNullOrEmpty_NoErrors()
        {
            // Arrange
            var client = "fake";


            // Act
            var act = client.Validate()
                .IfNullOrEmpty();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Withspaces_IfNullOrEmpty_NoErrors()
        {
            // Arrange
            var client = "    ";


            // Act
            var act = client.Validate()
                .IfNullOrEmpty();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ValidationError_IfNullOrEmpty_ErrorCode()
        {
            // Arrange
            var t4e = "";

            var expectedProperty = "fakeProp fake";
            var expectedCode = "fakeCode fake";
            var expectedDescription = $"Fake description fake > '{expectedProperty}'";


            // Act
            var act = t4e.Validate()
                .IfNullOrEmpty(
                    property => Error.Validation(
                        expectedProperty,
                        expectedCode,
                        expectedDescription
                    )
                );


            // Assert
            act.Errors.Should().HaveCount(1);
            act.Errors.First().Should().BeOfType<ValidationError>();

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
