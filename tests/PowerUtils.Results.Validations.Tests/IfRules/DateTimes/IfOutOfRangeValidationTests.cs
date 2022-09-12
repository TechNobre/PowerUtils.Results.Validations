using System;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.DateTimes
{
    public class IfOutOfRangeValidationTests
    {
        [Fact]
        public void InRange_IfOutOfRange_NoErrors()
        {
            // Arrange
            var dateOfBirth = new DateTime(2021, 1, 1);
            var min = new DateTime(2000, 12, 31);
            var max = new DateTime(2021, 1, 2);


            // Act
            var act = dateOfBirth.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Past_IfOutOfRange_OneError()
        {
            // Arrange
            var dateOfBirth = new DateTime(1999, 1, 1);
            var min = new DateTime(2000, 12, 31);
            var max = new DateTime(2021, 1, 2);


            // Act
            var act = dateOfBirth.Validate()
                .IfOutOfRange(min, max);


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
        public void Future_IfOutOfRange_OneError()
        {
            // Arrange
            var dateOfBirth = new DateTime(2022, 1, 1);
            var min = new DateTime(2000, 12, 31);
            var max = new DateTime(2021, 1, 2);


            // Act
            var act = dateOfBirth.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MAX:2021-01-02"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very future. The maximum is 2021-01-02"
            );
        }

        [Fact]
        public void NULL_IfOutOfRangeNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = null;
            var min = new DateTime(2000, 12, 31);
            var max = new DateTime(2021, 1, 2);


            // Act
            var act = dateOfBirth.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void InRange_IfOutOfRangeNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = new DateTime(2021, 1, 1);
            var min = new DateTime(2000, 12, 31);
            var max = new DateTime(2021, 1, 2);


            // Act
            var act = dateOfBirth.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Past_IfOutOfRangeNullable_OneError()
        {
            // Arrange
            DateTime? dateOfBirth = new DateTime(1999, 1, 1);
            var min = new DateTime(2000, 12, 31);
            var max = new DateTime(2021, 1, 2);


            // Act
            var act = dateOfBirth.Validate()
                .IfOutOfRange(min, max);


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
        public void Future_IfOutOfRangeNullable_OneError()
        {
            // Arrange
            DateTime? dateOfBirth = new DateTime(2022, 1, 1);
            var min = new DateTime(2000, 12, 31);
            var max = new DateTime(2021, 1, 2);


            // Act
            var act = dateOfBirth.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MAX:2021-01-02"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very future. The maximum is 2021-01-02"
            );
        }
    }
}
