using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.DateTimes
{
    public class IfLessThanUtcTodayValidationTests
    {
        [Fact]
        public void UtcNowMinus2Seconds_IfLessThanUtcToday_NoErrors()
        {
            // Arrange
            var dateOfBirth = DateTime.UtcNow.AddSeconds(-2);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Equals_IfLessThanUtcToday_NoErrors()
        {
            // Arrange
            var dateOfBirth = DateTime.UtcNow.Date;


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Equals_IfLessThanUtcTodayNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = DateTime.UtcNow.Date;


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void UtcNowMinus1Day_IfLessThanUtcToday_OneError()
        {
            // Arrange
            var dateOfBirth = DateTime.UtcNow.AddDays(-1);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MIN:DATETIME_UTCTODAY"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very old. The minimum is UTC TODAY"
            );
        }

        [Fact]
        public void UtcNowMore2Seconds_IfLessThanUtcToday_NoErrors()
        {
            // Arrange
            var dateOfBirth = DateTime.UtcNow.AddSeconds(2);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Null_IfLessThanUtcTodayNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = null;


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(0);
        }


        [Fact]
        public void UtcNowMinus2Seconds_IfLessThanUtcTodayNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = DateTime.UtcNow.AddMilliseconds(500);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(0);
        }


        [Fact]
        public void UtcNowMinus1Day_IfLessThanUtcTodayNullable_OneError()
        {
            // Arrange
            DateTime? dateOfBirth = DateTime.UtcNow.AddDays(-1);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MIN:DATETIME_UTCTODAY"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very old. The minimum is UTC TODAY"
            );
        }

        [Fact]
        public void UtcNowMore2Seconds_IfLessThanUtcTodayNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = DateTime.UtcNow.AddSeconds(2);


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ForbiddenError_IfLessThanUtcToday_OneError()
        {
            // Arrange
            var dateOfBirth = DateTime.UtcNow.AddDays(-2);

            var expectedProperty = "fake Prop date";
            var expectedCode = "fake Code date";
            var expectedDescription = $"Fake desc date > '{expectedProperty}'";


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcToday(
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
        public void ForbiddenError_IfLessThanUtcTodayNullable_OneError()
        {
            // Arrange
            DateTime? dateOfBirth = DateTime.UtcNow.AddDays(-20);

            var expectedProperty = "fake Prop dateTime";
            var expectedCode = "fake Code dateTime";
            var expectedDescription = $"Fake desc dateTime > '{expectedProperty}'";


            // Act
            var act = dateOfBirth.Validate()
                .IfLessThanUtcToday(
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
