using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Strings
{
    public class IfLengthEqualsValidationTests
    {
        [Fact]
        public void Null_IfLengthEquals_NoErrors()
        {
            // Arrange
            string client = null;
            var length = 5;


            // Act
            var act = client.Validate()
                .IfLengthEquals(length);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Empty_IfLengthEquals_NoErrors()
        {
            // Arrange
            var client = "";
            var length = 5;


            // Act
            var act = client.Validate()
                .IfLengthEquals(length);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void FourLength_IfLengthEquals_NoErrors()
        {
            // Arrange
            var client = "fake";
            var length = 5;


            // Act
            var act = client.Validate()
                .IfLengthEquals(length);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void SixLength_IfLengthEquals_NoErrors()
        {
            // Arrange
            var client = "fake";
            var length = 6;


            // Act
            var act = client.Validate()
                .IfLengthEquals(length);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void FiveLength_IfLengthEquals_OneError()
        {
            // Arrange
            var client = "fake";
            var length = 4;


            // Act
            var act = client.Validate()
                .IfLengthEquals(length);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(client)}' is of an invalid length. The length cannot be {length}"
            );
        }

        [Fact]
        public void UnauthorizedError_IfLengthEquals_ErrorCode()
        {
            // Arrange
            var client = "faker";
            var length = 5;

            var expectedProperty = "fakeProp fake SPACE";
            var expectedCode = "fakeCode fake SPACE";
            var expectedDescription = $"Fake description fake SPACE > '{expectedProperty}'";


            // Act
            var act = client.Validate()
                .IfLengthEquals(
                    length,
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
