using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Times
{
    public class IfLessThanUtcNowValidationTests
    {
#if NET6_0_OR_GREATER
        [Fact]
        public void PastDate_IfLessThanUtcNow_OneError()
        {
            // Arrange
            var dateOfBirth = TimeOnly.FromDateTime(DateTime.UtcNow.AddSeconds(-2));


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcNow();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MIN:TIME_UTCNOW"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very old. The minimum is UTC NOW"
            );
        }

        [Fact]
        public void FutureDate_IfLessThanUtcNow_NoErrors()
        {
            // Arrange
            var dateOfBirth = TimeOnly.FromDateTime(DateTime.UtcNow.AddSeconds(2));


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
            TimeOnly? dateOfBirth = null;


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
            TimeOnly? dateOfBirth = TimeOnly.FromDateTime(DateTime.UtcNow.AddSeconds(-2));


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcNow();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MIN:TIME_UTCNOW"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very old. The minimum is UTC NOW"
            );
        }

        [Fact]
        public void FutureDate_IfLessThanUtcNowNullable_NoErrors()
        {
            // Arrange
            TimeOnly? dateOfBirth = TimeOnly.FromDateTime(DateTime.UtcNow.AddSeconds(2));


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcNow();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ForbiddenError_IfLessThanUtcNow_OneError()
        {
            // Arrange
            var dateOfBirth = TimeOnly.FromDateTime(DateTime.UtcNow.AddSeconds(-2));

            var expectedProperty = "fake Prop date";
            var expectedCode = "fake Code date";
            var expectedDescription = $"Fake desc date > '{expectedProperty}'";


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcNow(
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
        public void ForbiddenError_IfLessThanUtcNowNullable_OneError()
        {
            // Arrange
            TimeOnly? dateOfBirth = TimeOnly.FromDateTime(DateTime.UtcNow.AddSeconds(-2));

            var expectedProperty = "fake Prop TimeOnly";
            var expectedCode = "fake Code TimeOnly";
            var expectedDescription = $"Fake desc TimeOnly > '{expectedProperty}'";


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcNow(
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
