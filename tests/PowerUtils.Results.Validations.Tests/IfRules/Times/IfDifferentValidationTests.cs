using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Times
{
    public class IfDifferentValidationTests
    {
#if NET6_0_OR_GREATER
        [Fact]
        public void Equals_IfDifferent_NoErrors()
        {
            // Arrange
            var dateOfBirth = new TimeOnly(00, 12, 31);
            var otherValue = new TimeOnly(00, 12, 31);



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
            var dateOfBirth = new TimeOnly(21, 1, 1);
            var otherValue = new TimeOnly(00, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' cannot be different to '{otherValue}'"
            );
        }

        [Fact]
        public void Null_IfDifferentNullable_OneError()
        {
            // Arrange
            TimeOnly? dateOfBirth = null;
            var otherValue = new TimeOnly(20, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' cannot be different to '{otherValue}'"
            );
        }

        [Fact]
        public void OtherEquals_IfDifferentNullable_NoErrors()
        {
            // Arrange
            TimeOnly? dateOfBirth = new TimeOnly(20, 12, 31);
            var otherValue = new TimeOnly(20, 12, 31);


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
            TimeOnly? dateOfBirth = new TimeOnly(21, 1, 1);
            var otherValue = new TimeOnly(00, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' cannot be different to '{otherValue}'"
            );
        }

        [Fact]
        public void BothNull_IfDifferentNullable_NoErrors()
        {
            // Arrange
            TimeOnly? dateOfBirth = null;
            TimeOnly? otherValue = null;


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
            TimeOnly? dateOfBirth = new TimeOnly(20, 12, 31);
            TimeOnly? otherValue = null;


            // Act
            var act = dateOfBirth.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' cannot be equal to '{otherValue}'"
            );
        }

        [Fact]
        public void Equals_IfDifferentNullable_NoErrors()
        {
            // Arrange
            TimeOnly? dateOfBirth = new TimeOnly(20, 12, 31);
            TimeOnly? otherValue = new TimeOnly(20, 12, 31);


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
            TimeOnly? dateOfBirth = new TimeOnly(20, 02, 12);
            TimeOnly? otherValue = new TimeOnly(19, 12, 31);

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
#endif
    }
}
