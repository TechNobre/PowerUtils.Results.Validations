using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.DateTimes
{
    public class IfDifferentValidationTests
    {
        [Fact]
        public void Equals_IfDifferent_NoErrors()
        {
            // Arrange
            var dateOfBirth = new DateTime(2000, 12, 31);
            var otherValue = new DateTime(2000, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Different_IfDifferent_OneError()
        {
            // Arrange
            var dateOfBirth = new DateTime(2021, 1, 1);
            var otherValue = new DateTime(2000, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == ResultErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' cannot be different to '{otherValue}'"
            );
        }

        [Fact]
        public void Null_IfDifferentNullable_OneError()
        {
            // Arrange
            DateTime? dateOfBirth = null;
            var otherValue = new DateTime(2000, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == ResultErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' cannot be different to '{otherValue}'"
            );
        }

        [Fact]
        public void OtherEquals_IfDifferentNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = new DateTime(2000, 12, 31);
            var otherValue = new DateTime(2000, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Different_IfDifferentNullable_OneError()
        {
            // Arrange
            DateTime? dateOfBirth = new DateTime(2021, 1, 1);
            var otherValue = new DateTime(2000, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == ResultErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' cannot be different to '{otherValue}'"
            );
        }

        [Fact]
        public void BothNull_IfDifferentNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = null;
            DateTime? otherValue = null;


            // Act
            var act = dateOfBirth.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void OtherNull_IfDifferentNullable_OneError()
        {
            // Arrange
            DateTime? dateOfBirth = new DateTime(2000, 12, 31);
            DateTime? otherValue = null;


            // Act
            var act = dateOfBirth.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == ResultErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' cannot be equal to '{otherValue}'"
            );
        }

        [Fact]
        public void Equals_IfDifferentNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = new DateTime(2000, 12, 31);
            DateTime? otherValue = new DateTime(2000, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ForbiddenError_IfDifferentNullable_OneError()
        {
            // Arrange
            DateTime? dateOfBirth = new DateTime(2000, 02, 12);
            DateTime? otherValue = new DateTime(1987, 12, 31);

            var expectedProperty = "fake Prop diff";
            var expectedCode = "fake Code diff";
            var expectedDescription = $"Fake desc diff > '{expectedProperty}'";


            // Act
            var act = dateOfBirth.Validate()
                .IfDifferent(
                    otherValue,
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
