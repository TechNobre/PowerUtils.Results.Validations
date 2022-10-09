using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.Conversions.DateTimes
{
    public class ToDateConversionsTests
    {
#if NET6_0_OR_GREATER
        [Fact]
        public void InvalidDateTimeString_ToDate_OneError()
        {
            // Arrange
            var format = "yyyy-MM-dd HH:mm";
            var date = "2022-53-12";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToDate(format);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(date)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(date)}' is an invalid 'Date'. The supported format is '{format}'"
            );

            act.Value.Should().Be(default);
        }

        [Fact]
        public void ValidDateTimeString_ToDate_DateTime()
        {
            // Arrange
            var date = "2022-03-22";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToDate("yyyy-MM-dd");


            // Assert
            act.Errors.Should().HaveCount(0);

            act.Value.Year.Should().Be(2022);
            act.Value.Month.Should().Be(03);
            act.Value.Day.Should().Be(22);
        }



        [Fact]
        public void InvalidDateTimeString_ToDateNullable_OneError()
        {
            // Arrange
            var format = "yyyy-MM-dd HH:mm";
            var date = "2022-53-12";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToDateNullable(format);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(date)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(date)}' is an invalid 'Date'. The supported format is '{format}'"
            );

            act.Value.Should().BeNull();
        }

        [Fact]
        public void ValidDateTimeString_ToDateNullable_DateTime()
        {
            // Arrange
            var date = "2021-12-22";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToDateNullable();


            // Assert
            act.Errors.Should().HaveCount(0);
            act.Value.Should().Be(new DateOnly(2021, 12, 22));
        }



        [Fact]
        public void InvalidDateTimeString_ToDateWithOut_OneError()
        {
            // Arrange
            var format = "yyyy-MM-dd HH:mm";
            var date = "2022-53-12";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToDate(out var result, format);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(date)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(date)}' is an invalid 'Date'. The supported format is '{format}'"
            );

            act.Value.Should().Be(default);
            result.Should().Be(default);
        }

        [Fact]
        public void ValidDateTimeString_ToDateWithOut_DateTime()
        {
            // Arrange
            var date = "2022-03-22";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToDate(out var result, "yyyy-MM-dd");


            // Assert
            act.Errors.Should().HaveCount(0);

            act.Value.Year.Should().Be(2022);
            act.Value.Month.Should().Be(03);
            act.Value.Day.Should().Be(22);

            result.Year.Should().Be(2022);
            result.Month.Should().Be(03);
            result.Day.Should().Be(22);
        }



        [Fact]
        public void InvalidDateTimeString_ToDateNullableWithOut_OneError()
        {
            // Arrange
            var format = "yyyy-MM-dd HH:mm";
            var date = "2022-53-12";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToDateNullable(out var result, format);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(date)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(date)}' is an invalid 'Date'. The supported format is '{format}'"
            );

            act.Value.Should().BeNull();
            result.Should().BeNull();
        }

        [Fact]
        public void ValidDateTimeString_ToDateNullableWithOut_DateTime()
        {
            // Arrange
            var date = "2021-12-22";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToDateNullable(out var result);


            // Assert
            act.Errors.Should().HaveCount(0);
            act.Value.Should().Be(new DateOnly(2021, 12, 22));
            result.Should().Be(new DateOnly(2021, 12, 22));
        }

        [Fact]
        public void Null_ToDateNullable_NullValueNoErrors()
        {
            // Arrange
            string date = null;

            var errors = new List<IError>();


            // Act
            var act = date.Validate(errors)
                .ToDateNullable(out var newDate)
                .IfOutOfRange(new DateOnly(2021, 1, 1), new DateOnly(2022, 12, 22));


            // Assert
            act.Errors.Should().HaveCount(0);

            act.Value.Should().BeNull();
            newDate.Should().BeNull();
        }
#endif
    }
}
