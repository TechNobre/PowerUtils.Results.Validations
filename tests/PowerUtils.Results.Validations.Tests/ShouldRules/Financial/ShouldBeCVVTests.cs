using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.ShouldRules.Financial
{
    public class ShouldBeCVVTests
    {
        [Fact]
        public void NULL_ShouldBeCVV_NoErrors()
        {
            // Arrange
            string cvv = null;


            // Act
            var act = cvv.Validate()
                .ShouldBeCVV();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData("das")]
        [InlineData("1sd")]
        [InlineData("cvv")]
        [InlineData("1")]
        [InlineData("12")]
        [InlineData("00")]
        [InlineData("300d")]
        [InlineData("10d")]
        [InlineData("00000")]
        [InlineData("23424")]
        [InlineData("12345")]
        [InlineData(" 123")]
        [InlineData("123 ")]
        [InlineData("121.3")]
        [InlineData("921.3")]
        public void Invalid_ShouldBeCVV_OneError(string cvv)
        {
            // Arrange && Act
            var act = cvv.Validate()
                .ShouldBeCVV();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(cvv)
                &&
                c.Code == ResultErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(cvv)}' is an invalid CVV format"
            );
        }

        [Theory]
        [InlineData("000")]
        [InlineData("0000")]
        [InlineData("001")]
        [InlineData("444")]
        [InlineData("4444")]
        [InlineData("4445")]
        [InlineData("9874")]
        public void Valid_ShouldBeCVV_OneError(string cvv)
        {
            // Arrange && Act
            var act = cvv.Validate()
                .ShouldBeCVV();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ForbiddenError_ShouldBeCVV_ErrorCode()
        {
            // Arrange
            var card = "cvv";

            var expectedProperty = "fakeProp cvv";
            var expectedCode = "fakeCode cvv";
            var expectedDescription = $"Fake description cvv > '{expectedProperty}'";


            // Act
            var act = card.Validate()
                .ShouldBeCVV(
                    property => Error.Forbidden(
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
