using System;
using System.Globalization;
using FluentAssertions;
using Xunit;
namespace PowerUtils.Results.Validations.Tests.Conversions.Numerics
{
    public class ToNumberConversionsTests
    {
        [Fact]
        public void Invalid_ToNumberInt_OneError()
        {
            // Arrange
            var val = "sdf";
            var validatable = val
                .Validate();


            // Act
            var act = validatable.ToNumber<int>();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(val)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(val)}' is an invalid"
            );

            act.Value.Should().Be(default);
        }

        [Fact]
        public void Number_ToNumberInt_Int()
        {
            // Arrange
            var val = "45545434";
            var validatable = val
                .Validate();


            // Act
            var act = validatable.ToNumber<long>(out var result);


            // Assert
            act.Errors.Should().HaveCount(0);

            act.Value.Should().Be(45545434);
            result.Should().Be(45545434);

            act.Value.Should().BeOfType(typeof(long));
            result.Should().BeOfType(typeof(long));
        }

        [Fact]
        public void Number_ToNumberShort_Short()
        {
            // Arrange
            var val = "7";
            var validatable = val
                .Validate();


            // Act
            var act = validatable.ToNumber<short>(out var result);


            // Assert
            act.Errors.Should().HaveCount(0);

            act.Value.Should().Be(7);
            result.Should().Be(7);

            act.Value.Should().BeOfType(typeof(short));
            result.Should().BeOfType(typeof(short));
        }

        [Fact]
        public void Number_ToNumberDouble_Double()
        {
            // Arrange
            var val = $"45{CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator}545434";
            var validatable = val
                .Validate();


            // Act
            var act = validatable.ToNumber<double>(out var result);


            // Assert
            act.Errors.Should().HaveCount(0);

            act.Value.Should().Be(45.545434);
            result.Should().Be(45.545434);

            act.Value.Should().BeOfType(typeof(double));
            result.Should().BeOfType(typeof(double));
        }

        [Fact]
        public void Number_ToNumberFloat_Float()
        {
            // Arrange
            var val = $"43{CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator}54";
            var validatable = val
                .Validate();


            // Act
            var act = validatable.ToNumber<float>(out var result);


            // Assert
            act.Errors.Should().HaveCount(0);

            act.Value.Should().Be(43.54f);
            result.Should().Be(43.54f);

            act.Value.Should().BeOfType(typeof(float));
            result.Should().BeOfType(typeof(float));
        }

        [Fact]
        public void Number_ToNumberUshort_Ushort()
        {
            // Arrange
            var val = "742";
            var validatable = val
                .Validate();


            // Act
            var act = validatable.ToNumber<ushort>(out var result);


            // Assert
            act.Errors.Should().HaveCount(0);

            act.Value.Should().Be(742);
            result.Should().Be(742);

            act.Value.Should().BeOfType(typeof(ushort));
            result.Should().BeOfType(typeof(ushort));
        }

        [Fact]
        public void Guid_ToNumberGuid_OneError()
        {
            // Arrange
            var val = Guid.NewGuid().ToString();
            var validatable = val
                .Validate();


            // Act
            var act = Record.Exception(() => validatable.ToNumber<Guid>());


            // Assert
            act.Should().BeOfType<InvalidCastException>();
        }

        [Fact]
        public void String_ToNumberString_InvalidCastException()
        {
            // Arrange
            var val = "fake";
            var validatable = val
                .Validate();


            // Act
            var act = Record.Exception(() => validatable.ToNumber<string>());


            // Assert
            act.Should()
                .BeOfType<InvalidCastException>();

            act.Message.Should()
                .Be("Invalid type 'String'");
        }
    }
}
