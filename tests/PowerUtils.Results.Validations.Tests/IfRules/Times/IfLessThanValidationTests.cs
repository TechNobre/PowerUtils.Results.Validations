using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Times
{
    public class IfLessThanValidationTests
    {
#if NET6_0_OR_GREATER
        [Fact]
        public void PastDate_IfLessThan_OneError()
        {
            // Arrange
            var dateOfBirth = new TimeOnly(19, 12, 12);
            var min = new TimeOnly(20, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThan(min);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MIN:20:12:31"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very old. The minimum is 20:12:31"
            );
        }

        [Fact]
        public void FutureDate_IfLessThan_NoErrors()
        {
            // Arrange
            var dateOfBirth = new TimeOnly(20, 13, 12);
            var min = new TimeOnly(20, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThan(min);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Equals_IfLessThan_NoErrors()
        {
            // Arrange
            var dateOfBirth = new TimeOnly(17, 1, 14);
            var min = new TimeOnly(17, 1, 14);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThan(min);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Equals_IfLessThanNullable_NoErrors()
        {
            // Arrange
            TimeOnly? dateOfBirth = new TimeOnly(12, 1, 14);
            var min = new TimeOnly(12, 1, 14);


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
            TimeOnly? dateOfBirth = null;
            var min = new TimeOnly(20, 12, 31);


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
            TimeOnly? dateOfBirth = new TimeOnly(19, 12, 12);
            var min = new TimeOnly(20, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThan(min);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MIN:20:12:31"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very old. The minimum is 20:12:31"
            );
        }

        [Fact]
        public void FutureDate_IfLessThanNullable_NoErrors()
        {
            // Arrange
            TimeOnly? dateOfBirth = new TimeOnly(21, 12, 12);
            var min = new TimeOnly(20, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThan(min);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ForbiddenError_IfLessThan_ErrorCode()
        {
            // Arrange
            var dateOfBirth = new TimeOnly(19, 12, 12);
            var min = new TimeOnly(20, 12, 31);

            var expectedProperty = "fake Prop diff";
            var expectedCode = "fake Code diff";
            var expectedDescription = $"Fake desc diff > '{expectedProperty}'";


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThan(
                    min,
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

        [Fact]
        public void ForbiddenError_IfLessThanNullable_ErrorCode()
        {
            // Arrange
            TimeOnly? dateOfBirth = new TimeOnly(19, 12, 12);
            var min = new TimeOnly(20, 12, 31);

            var expectedProperty = "fake Prop diff";
            var expectedCode = "fake Code diff";
            var expectedDescription = $"Fake desc diff > '{expectedProperty}'";


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThan(
                    min,
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
