using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Times
{
    public class IfGreaterThanUtcNowValidationTests
    {
#if NET6_0_OR_GREATER
        [Fact]
        public void FutureDate_IfGreaterThanUtcNow_OneError()
        {
            // Arrange
            var dateOfBirth = TimeOnly.FromDateTime(DateTime.UtcNow.AddSeconds(2));


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcNow();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MAX:DATETIME_UTCNOW"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very future. The maximum is UTC NOW"
            );
        }

        [Fact]
        public void PastDate_IfGreaterThanUtcNow_NoErrors()
        {
            // Arrange
            var dateOfBirth = TimeOnly.FromDateTime(DateTime.UtcNow.AddDays(-2));


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcNow();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Equals_IfGreaterThanUtcNowNullable_NoErrors()
        {
            // Arrange
            TimeOnly? now = TimeOnly.FromDateTime(DateTime.UtcNow);


            // Act
            var act = now.Validate()
                .IfGreaterThanUtcNow();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Null_IfGreaterThanUtcNowNullable_NoErrors()
        {
            // Arrange
            TimeOnly? dateOfBirth = null;


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcNow();


            // Assert
            act.Errors.Should().HaveCount(0);
        }


        [Fact]
        public void FutureDate_IfGreaterThanUtcNowNullable_OneError()
        {
            // Arrange
            TimeOnly? dateOfBirth = TimeOnly.FromDateTime(DateTime.UtcNow.AddSeconds(2));


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcNow();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MAX:DATETIME_UTCNOW"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very future. The maximum is UTC NOW"
            );
        }

        [Fact]
        public void PastDate_IfGreaterThanUtcNowNullable_NoErrors()
        {
            // Arrange
            TimeOnly? dateOfBirth = TimeOnly.FromDateTime(DateTime.UtcNow.AddSeconds(-2));


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcNow();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ForbiddenError_IfGreaterThanUtcNow_ErrorCode()
        {
            // Arrange
            var dateOfBirth = TimeOnly.FromDateTime(DateTime.UtcNow.AddSeconds(5));

            var expectedProperty = "fakeProp lat";
            var expectedCode = "fakeCode lat";
            var expectedDescription = $"Fake description lat > '{expectedProperty}'";


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcNow(
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
        public void ForbiddenError_IfGreaterThanUtcNowNullable_ErrorCode()
        {
            // Arrange
            TimeOnly? dateOfBirth = TimeOnly.FromDateTime(DateTime.UtcNow.AddSeconds(5));

            var expectedProperty = "fakeProp lat";
            var expectedCode = "fakeCode lat";
            var expectedDescription = $"Fake description lat > '{expectedProperty}'";


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcNow(
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
