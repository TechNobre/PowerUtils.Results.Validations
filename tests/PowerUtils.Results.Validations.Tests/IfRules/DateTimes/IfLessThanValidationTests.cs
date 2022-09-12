using System;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.DateTimes
{
    public class IfLessThanValidationTests
    {
        [Fact]
        public void PastDate_IfLessThan_OneError()
        {
            // Arrange
            var dateOfBirth = new DateTime(1980, 12, 12);
            var min = new DateTime(2000, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThan(min);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MIN:2000-12-31"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very old. The minimum is 2000-12-31"
            );
        }

        [Fact]
        public void FutureDate_IfLessThan_NoErrors()
        {
            // Arrange
            var dateOfBirth = new DateTime(2012, 12, 12);
            var min = new DateTime(2000, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThan(min);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Null_IfLessThanNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = null;
            var min = new DateTime(2000, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThan(min);


            // Assert
            act.Errors.Should().HaveCount(0);
        }


        [Fact]
        public void PastDate_IfLessThanNullable_OneError()
        {
            // Arrange
            DateTime? dateOfBirth = new DateTime(1980, 12, 12);
            var min = new DateTime(2000, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThan(min);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MIN:2000-12-31"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very old. The minimum is 2000-12-31"
            );
        }

        [Fact]
        public void FutureDate_IfLessThanNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = new DateTime(2012, 12, 12);
            var min = new DateTime(2000, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThan(min);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

    }
}
