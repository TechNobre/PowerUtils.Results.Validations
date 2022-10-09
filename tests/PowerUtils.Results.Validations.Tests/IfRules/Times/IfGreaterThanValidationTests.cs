using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Times
{
    public class IfGreaterThanValidationTests
    {
#if NET6_0_OR_GREATER
        [Fact]
        public void FutureDate_IfGreaterThan_OneError()
        {
            // Arrange
            var dateOfBirth = new TimeOnly(22, 12, 12);
            var max = new TimeOnly(13, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThan(max);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MAX:13:12:31"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very future. The maximum is 13:12:31"
            );
        }

        [Fact]
        public void PastDate_IfGreaterThan_NoErrors()
        {
            // Arrange
            var dateOfBirth = new TimeOnly(19, 12, 12);
            var max = new TimeOnly(20, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThan(max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Equals_IfGreaterThan_NoErrors()
        {
            // Arrange
            var dateOfBirth = new TimeOnly(19, 02, 29);
            var max = new TimeOnly(19, 02, 29);


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
            TimeOnly? dateOfBirth = null;
            var max = new TimeOnly(20, 12, 31);


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
            TimeOnly? dateOfBirth = new TimeOnly(17, 12, 12);
            var max = new TimeOnly(15, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThan(max);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MAX:15:12:31"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very future. The maximum is 15:12:31"
            );
        }

        [Fact]
        public void PastDate_IfGreaterThanNullable_NoErrors()
        {
            // Arrange
            TimeOnly? dateOfBirth = new TimeOnly(19, 12, 12);
            var max = new TimeOnly(20, 12, 31);


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThan(max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void EqualsDate_IfGreaterThanNullable_NoErrors()
        {
            // Arrange
            TimeOnly? dateOfBirth = new TimeOnly(18, 11, 12);
            var max = new TimeOnly(18, 11, 12);


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThan(max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ForbiddenError_IfGreaterThan_ErrorCode()
        {
            // Arrange
            var dateOfBirth = new TimeOnly(12, 12, 12);
            var max = new TimeOnly(00, 12, 31);

            var expectedProperty = "fake Prop diff";
            var expectedCode = "fake Code diff";
            var expectedDescription = $"Fake desc diff > '{expectedProperty}'";


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThan(
                    max,
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
        public void ForbiddenError_IfGreaterThanNullable_ErrorCode()
        {
            // Arrange
            TimeOnly? dateOfBirth = new TimeOnly(12, 12, 12);
            var max = new TimeOnly(10, 12, 31);

            var expectedProperty = "fake Prop diff";
            var expectedCode = "fake Code diff";
            var expectedDescription = $"Fake desc diff > '{expectedProperty}'";


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThan(
                    max,
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
