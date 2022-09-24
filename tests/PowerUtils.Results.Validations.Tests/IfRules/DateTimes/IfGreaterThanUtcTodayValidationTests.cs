using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.DateTimes
{
    public class IfGreaterThanUtcTodayValidationTests
    {
        [Fact]
        public void UtcNowMore2Seconds_IfGreaterThanUtcToday_OneError()
        {
            // Arrange
            var dateOfBirth = DateTime.UtcNow.AddSeconds(2);


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MAX:DATETIME_UTCTODAY"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very future. The maximum is UTC TODAY"
            );
        }

        [Fact]
        public void UtcNowMinus2Seconds_IfGreaterThanUtcToday_NoErrors()
        {
            // Arrange
            var dateOfBirth = DateTime.UtcNow.AddDays(-2);


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Null_IfGreaterThanUtcTodayNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = null;


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(0);
        }


        [Fact]
        public void UtcNowMore2Seconds_IfGreaterThanUtcTodayNullable_OneError()
        {
            // Arrange
            DateTime? dateOfBirth = DateTime.UtcNow.AddSeconds(2);


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MAX:DATETIME_UTCTODAY"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very future. The maximum is UTC TODAY"
            );
        }

        [Fact]
        public void UtcNowMinus2Seconds_IfGreaterThanUtcTodayNullable_OneError()
        {
            // Arrange
            DateTime? dateOfBirth = DateTime.UtcNow.AddSeconds(-2);


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MAX:DATETIME_UTCTODAY"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very future. The maximum is UTC TODAY"
            );
        }

        [Fact]
        public void UtcNowMinus1Day_IfGreaterThanUtcTodayNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = DateTime.UtcNow.AddDays(-1);


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(0);
        }


        [Fact]
        public void ForbiddenError_IfGreaterThanUtcToday_OneError()
        {
            // Arrange
            var dateOfBirth = new DateTime(2874, 1, 1);

            var expectedProperty = "fake Prop diff";
            var expectedCode = "fake Code diff";
            var expectedDescription = $"Fake desc diff > '{expectedProperty}'";


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcToday(
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


        [Fact]
        public void ForbiddenError_IfGreaterThanUtcTodayNullable_OneError()
        {
            // Arrange
            DateTime? dateOfBirth = new DateTime(2874, 1, 1);

            var expectedProperty = "fake Prop diff";
            var expectedCode = "fake Code diff";
            var expectedDescription = $"Fake desc diff > '{expectedProperty}'";


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcToday(
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
