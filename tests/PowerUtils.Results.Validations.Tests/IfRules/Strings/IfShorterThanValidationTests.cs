using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Strings
{
    public class IfShorterThanValidationTests
    {
        [Fact]
        public void Null_IfShorterThan_NoErrors()
        {
            // Arrange
            string client = null;
            var min = 3;


            // Act
            var act = client.Validate()
                .IfShorterThan(min);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Equals_IfShorterThan_NoErrors()
        {
            // Arrange
            var client = "My";
            var max = 2;



            // Act
            var act = client.Validate()
                .IfShorterThan(max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ShortText_IfShorterThan_OneError()
        {
            // Arrange
            var client = "Fk";
            var min = 3;


            // Act
            var act = client.Validate()
                .IfShorterThan(min);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == $"MIN:{min}"
                &&
                c.Description == $"The '{nameof(client)}' is too short. The minimum length is {min}"
            );
        }

        [Fact]
        public void BigText_IfShorterThan_NoErrors()
        {
            // Arrange
            var client = "Fake fake fake";
            var min = 3;


            // Act
            var act = client.Validate()
                .IfShorterThan(min);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void WithSpace_IfShorterThan_OneError()
        {
            // Arrange
            var client = " ";
            var min = 3;


            // Act
            var act = client.Validate()
                .IfShorterThan(min);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == $"MIN:{min}"
                &&
                c.Description == $"The '{nameof(client)}' is too short. The minimum length is {min}"
            );
        }

        [Fact]
        public void UnauthorizedError_IfShorterThan_ErrorCode()
        {
            // Arrange
            var client = "   SADASDSA  SAEAEASEAS    ";
            var min = 1542;

            var expectedProperty = "fakeProp fake SPACE";
            var expectedCode = "fakeCode fake SPACE";
            var expectedDescription = $"Fake description fake SPACE > '{expectedProperty}'";


            // Act
            var act = client.Validate()
                .IfShorterThan(
                    min,
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
