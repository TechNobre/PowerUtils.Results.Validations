using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Dates
{
    public class IfEqualsValidationTests
    {
#if NET6_0_OR_GREATER
        [Fact]
        public void Equals_IfEquals_OneError()
        {
            // Arrange
            var dateOfBirth = new DateOnly(2000, 12, 31);
            var otherValue = new DateOnly(2000, 12, 31);


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
            var dateOfBirth = new DateOnly(2021, 1, 1);
            var otherValue = new DateOnly(2000, 12, 31);


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
            DateOnly? dateOfBirth = null;
            var otherValue = new DateOnly(2000, 12, 31);


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
            DateOnly? dateOfBirth = null;
            DateOnly? otherValue = null;


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
            DateOnly? dateOfBirth = new DateOnly(2000, 12, 31);
            var otherValue = new DateOnly(2000, 12, 31);


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
            DateOnly? dateOfBirth = new DateOnly(2000, 12, 31);
            DateOnly? otherValue = null;


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
            DateOnly? dateOfBirth = new DateOnly(2000, 12, 31);
            DateOnly? otherValue = new DateOnly(2000, 12, 31);


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
        public void ForbiddenError_IfEqualsNullable_OneError()
        {
            // Arrange
            DateOnly? dateOfBirth = new DateOnly(2000, 12, 31);
            DateOnly? otherValue = new DateOnly(2000, 12, 31);

            var expectedProperty = "fake Prop diff";
            var expectedCode = "fake Code diff";
            var expectedDescription = $"Fake desc diff > '{expectedProperty}'";


            // Act
            var act = dateOfBirth.Validate()
                .IfEquals(
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
