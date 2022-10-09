using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.ShouldRules.Financial
{
    public class ShouldBeValidCardExpiryDateTests
    {
        [Fact]
        public void NULL_ShouldBeValidCardExpiryDate_NoErrors()
        {
            // Arrange
            string number = null;


            // Act
            var act = number.Validate()
                .ShouldBeValidCardExpiryDate();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData("4234")]
        [InlineData("2021/12/12")]
        [InlineData("2023/12/12")]
        [InlineData("12/99")]
        [InlineData("12/a")]
        [InlineData("1/31")]
        public void InvalidFormatDefaultExpiryDate_ShouldBeValidCardExpiryDate_OneError(string expiryDate)
        {
            // Arrange && Act
            var act = expiryDate.Validate()
                .ShouldBeValidCardExpiryDate();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(expiryDate)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(expiryDate)}' is an invalid expiry date format"
            );
        }

        [Theory]
        [InlineData("")]
        [InlineData("4234")]
        [InlineData("2021/12/12")]
        [InlineData("2023/12/12")]
        [InlineData("99/23")]
        [InlineData("99/a")]
        [InlineData("31/1")]
        public void InvalidFormatMMyyExpiryDate_ShouldBeValidCardExpiryDate_OneError(string expiryDate)
        {
            // Arrange && Act
            var act = expiryDate.Validate()
                .ShouldBeValidCardExpiryDate("MM/yy");


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(expiryDate)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(expiryDate)}' is an invalid expiry date format"
            );
        }

        [Fact]
        public void ExpiredFormatDefaultExpiryDate_ShouldBeValidCardExpiryDate_OneError()
        {
            // Arrange
            var date = new DateTime(
                DateTime.UtcNow.Year,
                DateTime.UtcNow.Month,
                1
            ).AddDays(-1);

            var carDate = $"{date:yy/MM}";


            // Act
            var act = carDate.Validate()
                .ShouldBeValidCardExpiryDate();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(carDate)
                &&
                c.Code == "MIN:CURRENT_MONTH"
                &&
                c.Description == $"The '{nameof(carDate)}' is an expiry date"
            );
        }

        [Fact]
        public void ExpiredFormatMMyyExpiryDate_ShouldBeValidCardExpiryDate_OneError()
        {
            // Arrange
            var date = new DateTime(
                DateTime.UtcNow.Year,
                DateTime.UtcNow.Month,
                1
            ).AddDays(-1);

            var carDate = $"{date:MM/yy}";


            // Act
            var act = carDate.Validate()
                .ShouldBeValidCardExpiryDate("MM/yy");


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(carDate)
                &&
                c.Code == "MIN:CURRENT_MONTH"
                &&
                c.Description == $"The '{nameof(carDate)}' is an expiry date"
            );
        }



        [Fact]
        public void ValidFormatDefaultExpiryDate_ShouldBeValidCardExpiryDate_NoError()
        {
            // Arrange
            var date = DateTime.UtcNow.AddMonths(1);
            var carDate = $"{date:yy/MM}";


            // Act
            var act = carDate.Validate()
                .ShouldBeValidCardExpiryDate();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ValidFormatMMyyExpiryDate_ShouldBeValidCardExpiryDate_NoError()
        {
            // Arrange
            var date = DateTime.UtcNow.AddMonths(1);
            var carDate = $"{date:MM/yy}";


            // Act
            var act = carDate.Validate()
                .ShouldBeValidCardExpiryDate("MM/yy");


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Day1CurrentMonth_ShouldBeValidCardExpiryDate_NoError()
        {
            // Arrange
            var date = DateTime.UtcNow;
            var carDate = $"{date:yy/MM}";


            // Act
            var act = carDate.Validate()
                .ShouldBeValidCardExpiryDate();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void CustomError_ShouldBeValidCardExpiryDate_ErrorCode()
        {
            // Arrange
            var carDate = "2011/12";

            var expectedProperty = "fakeProp date";
            var expectedCode = "fakeCode date";
            var expectedDescription = $"Fake description date > '{expectedProperty}'";


            // Act
            var act = carDate.Validate()
                .ShouldBeValidCardExpiryDate(
                    property => Error.Forbidden(
                        expectedProperty,
                        expectedCode,
                        expectedDescription
                    ),
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
