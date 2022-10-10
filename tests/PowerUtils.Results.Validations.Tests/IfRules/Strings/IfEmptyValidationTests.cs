using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Strings
{
    public class IfEmptyValidationTests
    {
        [Fact]
        public void Null_IfEmpty_NoErrors()
        {
            // Arrange
            string client = null;


            // Act
            var act = client.Validate()
                .IfEmpty();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Empty_IfEmpty_OneError()
        {
            // Arrange
            var client = "";


            // Act
            var act = client.Validate()
                .IfEmpty();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == ResultErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(client)}' cannot be empty"
            );
        }

        [Fact]
        public void Withspaces_IfEmpty_NoErrors()
        {
            // Arrange
            var client = "    ";


            // Act
            var act = client.Validate()
                .IfEmpty();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Word_IfEmpty_NoErrors()
        {
            // Arrange
            var client = "fake";


            // Act
            var act = client.Validate()
                .IfEmpty();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void NotFoundError_IfEmpty_ErrorCode()
        {
            // Arrange
            var t4e = "";

            var expectedProperty = "fakeProp";
            var expectedCode = "fakeCode";
            var expectedDescription = $"Fake description > '{expectedProperty}'";


            // Act
            var act = t4e.Validate()
                .IfEmpty(
                    property => Error.NotFound(
                        expectedProperty,
                        expectedCode,
                        expectedDescription
                    )
                );


            // Assert
            act.Errors.Should().HaveCount(1);
            act.Errors.First().Should().BeOfType<NotFoundError>();

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
