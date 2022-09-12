using System;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.DateTimes
{
    public class IfLessThanUtcTodayValidationTests
    {
        [Fact]
        public void UtcNowMinus2Seconds_IfLessThanUtcToday_NoErrors()
        {
            // Arrange
            var dateOfBirth = DateTime.UtcNow.AddSeconds(-2);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void UtcNowMinus1Day_IfLessThanUtcToday_OneError()
        {
            // Arrange
            var dateOfBirth = DateTime.UtcNow.AddDays(-1);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MIN:DATETIME_UTCTODAY"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very old. The minimum is UTC TODAY"
            );
        }

        [Fact]
        public void UtcNowMore2Seconds_IfLessThanUtcToday_NoErrors()
        {
            // Arrange
            var dateOfBirth = DateTime.UtcNow.AddSeconds(2);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Null_IfLessThanUtcTodayNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = null;


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(0);
        }


        [Fact]
        public void UtcNowMinus2Seconds_IfLessThanUtcTodayNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = DateTime.UtcNow.AddSeconds(-2);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(0);
        }


        [Fact]
        public void UtcNowMinus1Day_IfLessThanUtcTodayNullable_OneError()
        {
            // Arrange
            DateTime? dateOfBirth = DateTime.UtcNow.AddDays(-1);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MIN:DATETIME_UTCTODAY"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very old. The minimum is UTC TODAY"
            );
        }

        [Fact]
        public void UtcNowMore2Seconds_IfLessThanUtcTodayNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = DateTime.UtcNow.AddSeconds(2);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(0);
        }
    }
}
