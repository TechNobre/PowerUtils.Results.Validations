using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Strings
{
    public class IfLengthDifferentValidationTests
    {
        [Fact]
        public void Null_IfLengthDifferent_OneError()
        {
            // Arrange
            string client = null;
            var length = 6;


            // Act
            var act = client.Validate()
                .IfLengthDifferent(length);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(client)}' is of an invalid length. The length must be {length}"
            );
        }

        [Fact]
        public void Empty_IfLengthDifferent_OneError()
        {
            // Arrange
            var client = "";
            var length = 6;


            // Act
            var act = client.Validate()
                .IfLengthDifferent(length);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(client)}' is of an invalid length. The length must be {length}"
            );
        }

        [Fact]
        public void FiveLength_IfLengthDifferent_OneError()
        {
            // Arrange
            var client = "fake";
            var length = 5;


            // Act
            var act = client.Validate()
                .IfLengthDifferent(length);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(client)}' is of an invalid length. The length must be {length}"
            );
        }

        [Fact]
        public void SixLength_IfLengthDifferent_OneError()
        {
            // Arrange
            var client = "fake";
            var length = 6;


            // Act
            var act = client.Validate()
                .IfLengthDifferent(length);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(client)}' is of an invalid length. The length must be {length}"
            );
        }

        [Fact]
        public void FourLength_IfLengthDifferent_NoErrors()
        {
            // Arrange
            var client = "fake";
            var length = 4;


            // Act
            var act = client.Validate()
                .IfLengthDifferent(length);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void FiveLength_IfLengthDifferent_NoErrors()
        {
            // Arrange
            var client = "fake";
            var length = 5;


            // Act
            var act = client.Validate()
                .IfLengthDifferent(length);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(client)}' is of an invalid length. The length must be {length}"
            );
        }

        [Fact]
        public void ThreeLength_IfLengthDifferent_NoErrors()
        {
            // Arrange
            var client = "fake";
            var length = 3;


            // Act
            var act = client.Validate()
                .IfLengthDifferent(length);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(client)}' is of an invalid length. The length must be {length}"
            );
        }

        [Fact]
        public void UnauthorizedError_IfLengthDifferent_ErrorCode()
        {
            // Arrange
            var client = "fake";
            var length = 15;

            var expectedProperty = "fakeProp fake SPACE";
            var expectedCode = "fakeCode fake SPACE";
            var expectedDescription = $"Fake description fake SPACE > '{expectedProperty}'";


            // Act
            var act = client.Validate()
                .IfLengthDifferent(
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
