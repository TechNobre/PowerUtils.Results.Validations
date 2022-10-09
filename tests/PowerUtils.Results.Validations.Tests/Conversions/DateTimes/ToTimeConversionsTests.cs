using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.Conversions.DateTimes
{
    public class ToTimeConversionsTests
    {
#if NET6_0_OR_GREATER
        [Fact]
        public void InvalidDateTimeString_ToTime_OneError()
        {
            // Arrange
            var format = "yyyy-MM-dd HH:mm";
            var date = "2022-53-12";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToTime(format);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(date)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(date)}' is an invalid 'Time'. The supported format is '{format}'"
            );

            act.Value.Should().Be(default);
        }

        [Fact]
        public void ValidDateTimeString_ToTime_DateTime()
        {
            // Arrange
            var date = "21:24";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToTime("HH:mm");


            // Assert
            act.Errors.Should().HaveCount(0);

            act.Value.Hour.Should().Be(21);
            act.Value.Minute.Should().Be(24);
            act.Value.Second.Should().Be(0);
        }



        [Fact]
        public void InvalidDateTimeString_ToTimeNullable_OneError()
        {
            // Arrange
            var format = "yyyy-MM-dd HH:mm";
            var date = "2022-53-12";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToTimeNullable(format);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(date)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(date)}' is an invalid 'Time'. The supported format is '{format}'"
            );

            act.Value.Should().BeNull();
        }

        [Fact]
        public void ValidDateTimeString_ToTimeNullable_DateTime()
        {
            // Arrange
            var date = "11:12:13";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToTimeNullable();


            // Assert
            act.Errors.Should().HaveCount(0);
            act.Value.Should().Be(new TimeOnly(11, 12, 13));
        }



        [Fact]
        public void InvalidDateTimeString_ToTimeWithOut_OneError()
        {
            // Arrange
            var format = "yyyy-MM-dd HH:mm";
            var date = "2022-53-12";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToTime(out var result, format);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(date)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(date)}' is an invalid 'Time'. The supported format is '{format}'"
            );

            act.Value.Should().Be(default);
            result.Should().Be(default);
        }

        [Fact]
        public void ValidDateTimeString_ToTimeWithOut_DateTime()
        {
            // Arrange
            var date = "21:24";
            var validatable = date
                .Validate();

            // Act
            var act = validatable.ToTime(out var result, "HH:mm");


            // Assert
            act.Errors.Should().HaveCount(0);

            act.Value.Hour.Should().Be(21);
            act.Value.Minute.Should().Be(24);
            act.Value.Second.Should().Be(0);

            result.Hour.Should().Be(21);
            result.Minute.Should().Be(24);
            result.Second.Should().Be(0);
        }



        [Fact]
        public void InvalidDateTimeString_ToTimeNullableWithOut_OneError()
        {
            // Arrange
            var format = "yyyy-MM-dd HH:mm";
            var date = "2022-53-12";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToTimeNullable(out var result, format);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(date)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(date)}' is an invalid 'Time'. The supported format is '{format}'"
            );

            act.Value.Should().BeNull();
            result.Should().BeNull();
        }

        [Fact]
        public void ValidDateTimeString_ToTimeNullableWithOut_DateTime()
        {
            // Arrange
            var date = "11:12:13";
            var validatable = date
                .Validate();


            // Act
            var act = validatable.ToTimeNullable(out var result);


            // Assert
            act.Errors.Should().HaveCount(0);
            act.Value.Should().Be(new TimeOnly(11, 12, 13));
            result.Should().Be(new TimeOnly(11, 12, 13));
        }

        [Fact]
        public void Null_ToTimeNullable_NullValueNoErrors()
        {
            // Arrange
            string time = null;

            var errors = new List<IError>();


            // Act
            var act = time.Validate(errors)
                .ToTimeNullable(out var newTime)
                .IfOutOfRange(new TimeOnly(11, 12, 13), new TimeOnly(21, 12, 13));


            // Assert
            act.Errors.Should().HaveCount(0);

            act.Value.Should().BeNull();
            newTime.Should().BeNull();
        }
#endif
    }
}
