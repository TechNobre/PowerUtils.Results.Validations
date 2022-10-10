using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.Conversions.DateTimes
{
    public class ToDateTimeConversionsTests
    {
        [Fact]
        public void InvalidDateTimeString_ToDateTime_OneError()
        {
            // Arrange
            var format = "yyyy-MM-dd HH:mm";
            var date = "2022-53-12";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToDateTime(format);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(date)
                &&
                c.Code == ResultErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(date)}' is an invalid 'DateTime'. The supported format is '{format}'"
            );

            act.Value.Should().Be(default);
        }

        [Fact]
        public void ValidDateTimeString_ToDateTime_DateTime()
        {
            // Arrange
            var date = "2022-12-22";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToDateTime("yyyy-MM-dd");


            // Assert
            act.Errors.Should().HaveCount(0);

            act.Value.Year.Should().Be(2022);
            act.Value.Month.Should().Be(12);
            act.Value.Day.Should().Be(22);
        }



        [Fact]
        public void InvalidDateTimeString_ToDateTimeNullable_OneError()
        {
            // Arrange
            var format = "yyyy-MM-dd HH:mm";
            var date = "2022-53-12";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToDateTimeNullable(format);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(date)
                &&
                c.Code == ResultErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(date)}' is an invalid 'DateTime'. The supported format is '{format}'"
            );

            act.Value.Should().BeNull();
        }

        [Fact]
        public void ValidDateTimeString_ToDateTimeNullable_DateTime()
        {
            // Arrange
            var date = "2022-12-22 01:02:03";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToDateTimeNullable();


            // Assert
            act.Errors.Should().HaveCount(0);
            act.Value.Should().Be(new DateTime(2022, 12, 22, 01, 02, 03));
        }



        [Fact]
        public void InvalidDateTimeString_ToDateTimeWithOut_OneError()
        {
            // Arrange
            var format = "yyyy-MM-dd HH:mm";
            var date = "2022-53-12";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToDateTime(out var dateTime, format);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(date)
                &&
                c.Code == ResultErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(date)}' is an invalid 'DateTime'. The supported format is '{format}'"
            );

            act.Value.Should().Be(default);
            dateTime.Should().Be(default);
        }

        [Fact]
        public void ValidDateTimeString_ToDateTimeWithOut_DateTime()
        {
            // Arrange
            var date = "2022-12-22";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToDateTime(out var dateTime, "yyyy-MM-dd");


            // Assert
            act.Errors.Should().HaveCount(0);

            act.Value.Year.Should().Be(2022);
            act.Value.Month.Should().Be(12);
            act.Value.Day.Should().Be(22);

            dateTime.Year.Should().Be(2022);
            dateTime.Month.Should().Be(12);
            dateTime.Day.Should().Be(22);
        }



        [Fact]
        public void InvalidDateTimeString_ToDateTimeNullableWithOut_OneError()
        {
            // Arrange
            var format = "yyyy-MM-dd HH:mm";
            var date = "2022-53-12";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToDateTimeNullable(out var dateTime, format);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(date)
                &&
                c.Code == ResultErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(date)}' is an invalid 'DateTime'. The supported format is '{format}'"
            );

            act.Value.Should().BeNull();
            dateTime.Should().BeNull();
        }

        [Fact]
        public void ValidDateTimeString_ToDateTimeNullableWithOut_DateTime()
        {
            // Arrange
            var date = "2022-12-22 01:02:03";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToDateTimeNullable(out var dateTime);


            // Assert
            act.Errors.Should().HaveCount(0);
            act.Value.Should().Be(new DateTime(2022, 12, 22, 01, 02, 03));
            dateTime.Should().Be(new DateTime(2022, 12, 22, 01, 02, 03));
        }

        [Fact]
        public void Null_ToDateTimeNullable_NullValueNoErrors()
        {
            // Arrange
            string dateTime = null;

            var errors = new List<IError>();


            // Act
            var act = dateTime.Validate(errors)
                .ToDateTimeNullable(out var newDateTime)
                .IfOutOfRange(new DateTime(2021, 1, 1, 01, 02, 03), new DateTime(2022, 12, 22, 01, 02, 03));


            // Assert
            act.Errors.Should().HaveCount(0);

            act.Value.Should().BeNull();
            newDateTime.Should().BeNull();
        }
    }
}
