using System;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.DateTimes
{
    public class IfEqualsValidationTests
    {
        [Fact]
        public void Equals_IfEquals_OneError()
        {
            // Arrange
            var dateOfBirth = new DateTime(2000, 12, 31);
            var otherValue = new DateTime(2000, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' cannot be equal to '{otherValue}'"
            );
        }

        [Fact]
        public void Different_IfEquals_NoErrors()
        {
            // Arrange
            var dateOfBirth = new DateTime(2021, 1, 1);
            var otherValue = new DateTime(2000, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }


        [Fact]
        public void Null_IfEqualsNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = null;
            var otherValue = new DateTime(2000, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void BothNull_IfEqualsNullable_OneError()
        {
            // Arrange
            DateTime? dateOfBirth = null;
            DateTime? otherValue = null;


            // Act
            var act = dateOfBirth.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' cannot be equal to '{otherValue}'"
            );
        }

        [Fact]
        public void OtherEquals_IfEqualsNullable_OneError()
        {
            // Arrange
            DateTime? dateOfBirth = new DateTime(2000, 12, 31);
            var otherValue = new DateTime(2000, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' cannot be equal to '{otherValue}'"
            );
        }

        [Fact]
        public void OtherNull_IfEqualsNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = new DateTime(2000, 12, 31);
            DateTime? otherValue = null;


            // Act
            var act = dateOfBirth.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Equals_IfEqualsNullable_OneError()
        {
            // Arrange
            DateTime? dateOfBirth = new DateTime(2000, 12, 31);
            DateTime? otherValue = new DateTime(2000, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' cannot be equal to '{otherValue}'"
            );
        }
    }
}
