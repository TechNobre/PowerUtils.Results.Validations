using System;
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
    }
}
