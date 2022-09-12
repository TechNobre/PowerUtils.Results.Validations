using System;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.DateTimes
{
    public class IfGreaterThanUtcNowValidationTests
    {
        [Fact]
        public void FutureDate_IfGreaterThanUtcNow_OneError()
        {
            // Arrange
            var dateOfBirth = DateTime.UtcNow.AddSeconds(2);


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcNow();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MAX:DATETIME_UTCNOW"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very future. The maximum is UTC NOW"
            );
        }

        [Fact]
        public void PastDate_IfGreaterThanUtcNow_NoErrors()
        {
            // Arrange
            var dateOfBirth = DateTime.UtcNow.AddDays(-2);


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcNow();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Null_IfGreaterThanUtcNowNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = null;


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcNow();


            // Assert
            act.Errors.Should().HaveCount(0);
        }


        [Fact]
        public void FutureDate_IfGreaterThanUtcNowNullable_OneError()
        {
            // Arrange
            DateTime? dateOfBirth = DateTime.UtcNow.AddSeconds(2);


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcNow();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MAX:DATETIME_UTCNOW"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very future. The maximum is UTC NOW"
            );
        }

        [Fact]
        public void PastDate_IfGreaterThanUtcNowNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = DateTime.UtcNow.AddSeconds(-2);


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcNow();


            // Assert
            act.Errors.Should().HaveCount(0);
        }
    }
}
