using System;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.DateTimes
{
    public class IfGreaterThanValidationTests
    {
        [Fact]
        public void FutureDate_IfGreaterThan_OneError()
        {
            // Arrange
            var dateOfBirth = new DateTime(2012, 12, 12);
            var max = new DateTime(2000, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThan(max);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MAX:2000-12-31"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very future. The maximum is 2000-12-31"
            );
        }

        [Fact]
        public void PastDate_IfGreaterThan_NoErrors()
        {
            // Arrange
            var dateOfBirth = new DateTime(1980, 12, 12);
            var max = new DateTime(2000, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThan(max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }



        [Fact]
        public void Null_IfGreaterThanNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = null;
            var max = new DateTime(2000, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThan(max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }


        [Fact]
        public void FutureDate_IfGreaterThanNullable_OneError()
        {
            // Arrange
            DateTime? dateOfBirth = new DateTime(2012, 12, 12);
            var max = new DateTime(2000, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThan(max);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MAX:2000-12-31"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very future. The maximum is 2000-12-31"
            );
        }

        [Fact]
        public void PastDate_IfGreaterThanNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = new DateTime(1980, 12, 12);
            var max = new DateTime(2000, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThan(max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }
    }
}
