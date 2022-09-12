using System;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.DateTimes
{
    public class IfLessThanUtcNowValidationTests
    {
        [Fact]
        public void PastDate_IfLessThanUtcNow_OneError()
        {
            // Arrange
            var dateOfBirth = DateTime.UtcNow.AddSeconds(-2);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcNow();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MIN:DATETIME_UTCNOW"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very old. The minimum is UTC NOW"
            );
        }

        [Fact]
        public void FutureDate_IfLessThanUtcNow_NoErrors()
        {
            // Arrange
            var dateOfBirth = DateTime.UtcNow.AddSeconds(2);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcNow();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Null_IfLessThanUtcNowNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = null;


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcNow();


            // Assert
            act.Errors.Should().HaveCount(0);
        }


        [Fact]
        public void PastDate_IfLessThanUtcNowNullable_OneError()
        {
            // Arrange
            DateTime? dateOfBirth = DateTime.UtcNow.AddSeconds(-2);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcNow();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MIN:DATETIME_UTCNOW"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very old. The minimum is UTC NOW"
            );
        }

        [Fact]
        public void FutureDate_IfLessThanUtcNowNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = DateTime.UtcNow.AddSeconds(2);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcNow();


            // Assert
            act.Errors.Should().HaveCount(0);
        }
    }
}
