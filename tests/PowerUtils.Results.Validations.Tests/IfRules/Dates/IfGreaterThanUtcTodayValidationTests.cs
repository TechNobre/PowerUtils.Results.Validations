using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Dates
{
    public class IfGreaterThanUtcTodayValidationTests
    {
#if NET6_0_OR_GREATER
        [Fact]
        public void UtcNowMore2Days_IfGreaterThanUtcToday_OneError()
        {
            // Arrange
            var dateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(2));


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MAX:DATE_UTCTODAY"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very future. The maximum is UTC TODAY"
            );
        }

        [Fact]
        public void UtcNowMinus2Seconds_IfGreaterThanUtcToday_NoErrors()
        {
            // Arrange
            var dateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-2));


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Null_IfGreaterThanUtcTodayNullable_NoErrors()
        {
            // Arrange
            DateOnly? dateOfBirth = null;


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Equals_IfGreaterThanUtcToday_NoErrors()
        {
            // Arrange
            var dateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow);


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Equals_IfGreaterThanUtcTodayNullable_NoErrors()
        {
            // Arrange
            DateOnly? dateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow);


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(0);
        }


        [Fact]
        public void UtcNowMore2Days_IfGreaterThanUtcTodayNullable_OneError()
        {
            // Arrange
            DateOnly? dateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(2));


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MAX:DATE_UTCTODAY"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very future. The maximum is UTC TODAY"
            );
        }

        [Fact]
        public void UtcNowMinus2Days_IfGreaterThanUtcTodayNullable_NoErrors()
        {
            // Arrange
            DateOnly? dateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-2));


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void UtcNowMinus1Day_IfGreaterThanUtcTodayNullable_NoErrors()
        {
            // Arrange
            DateOnly? dateOfBirth = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-1));


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcToday();


            // Assert
            act.Errors.Should().HaveCount(0);
        }


        [Fact]
        public void ForbiddenError_IfGreaterThanUtcToday_OneError()
        {
            // Arrange
            var dateOfBirth = new DateOnly(2874, 1, 1);

            var expectedProperty = "fake Prop diff";
            var expectedCode = "fake Code diff";
            var expectedDescription = $"Fake desc diff > '{expectedProperty}'";


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcToday(
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
        public void ForbiddenError_IfGreaterThanUtcTodayNullable_OneError()
        {
            // Arrange
            DateOnly? dateOfBirth = new DateOnly(2874, 1, 1);

            var expectedProperty = "fake Prop diff";
            var expectedCode = "fake Code diff";
            var expectedDescription = $"Fake desc diff > '{expectedProperty}'";


            // Act
            var act = dateOfBirth.Validate()
                .IfGreaterThanUtcToday(
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
