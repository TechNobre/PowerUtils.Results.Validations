using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Numerics
{
    public class IfOutOfRangeValidationTests
    {
        [Fact]
        public void LargeNumber_IfOutOfRange_OneError()
        {
            // Arrange
            var quantity = 241;
            var min = 5;
            var max = 155;


            // Act
            var act = quantity.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(quantity)
                &&
                c.Code == $"MAX:{max}"
                &&
                c.Description == $"The '{nameof(quantity)}' is too big. The maximum is {max}"
            );
        }

        [Fact]
        public void SmallNumber_IfOutOfRange_OneError()
        {
            // Arrange
            var quantity = 4;
            var min = 5;
            var max = 155;


            // Act
            var act = quantity.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(quantity)
                &&
                c.Code == $"MIN:{min}"
                &&
                c.Description == $"The '{nameof(quantity)}' is too small. The minimum is {min}"
            );
        }

        [Fact]
        public void EqualsNumber_IfOutOfRange_NoErrors()
        {
            // Arrange
            var quantity = 4;
            var min = 4;
            var max = 155;


            // Act
            var act = quantity.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }



        [Fact]
        public void LargeNumber_IfOutOfRangeNullable_OneError()
        {
            // Arrange
            ulong? quantity = 241;
            var min = 5ul;
            var max = 155ul;


            // Act
            var act = quantity.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(quantity)
                &&
                c.Code == $"MAX:{max}"
                &&
                c.Description == $"The '{nameof(quantity)}' is too big. The maximum is {max}"
            );
        }

        [Fact]
        public void SmallNumber_IfOutOfRangeNullable_OneError()
        {
            // Arrange
            uint? quantity = 4;
            var min = 5u;
            var max = 155u;


            // Act
            var act = quantity.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(quantity)
                &&
                c.Code == $"MIN:{min}"
                &&
                c.Description == $"The '{nameof(quantity)}' is too small. The minimum is {min}"
            );
        }

        [Fact]
        public void EqualsNumber_IfOutOfRangeNullable_NoErrors()
        {
            // Arrange
            decimal? quantity = 4;
            var min = 4;
            var max = 155;


            // Act
            var act = quantity.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Null_IfOutOfRangeNullable_NoErrors()
        {
            // Arrange
            ushort? quantity = null;
            ushort min = 5;
            ushort max = 155;


            // Act
            var act = quantity.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }
    }
}
