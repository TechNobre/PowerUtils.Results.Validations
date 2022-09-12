using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Numerics
{
    public class IfLessThanValidationTests
    {
        [Fact]
        public void LargeNumber_IfLessThan_NoErrors()
        {
            // Arrange
            var quantity = 241;
            var min = 5;


            // Act
            var act = quantity.Validate()
                .IfLessThan(min);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void SmallNumber_IfLessThan_OneError()
        {
            // Arrange
            var quantity = 4;
            var min = 5;


            // Act
            var act = quantity.Validate()
                .IfLessThan(min);


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
        public void EqualsNumber_IfLessThan_NoErrors()
        {
            // Arrange
            var quantity = 4;
            var min = 4;


            // Act
            var act = quantity.Validate()
                .IfLessThan(min);


            // Assert
            act.Errors.Should().HaveCount(0);
        }



        [Fact]
        public void LargeNumber_IfLessThanNullable_NoErrors()
        {
            // Arrange
            ulong? quantity = 241;
            var min = 5ul;


            // Act
            var act = quantity.Validate()
                .IfLessThan(min);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void SmallNumber_IfLessThanNullable_OneError()
        {
            // Arrange
            uint? quantity = 4;
            var min = 5u;


            // Act
            var act = quantity.Validate()
                .IfLessThan(min);


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
        public void EqualsNumber_IfLessThanNullable_NoErrors()
        {
            // Arrange
            decimal? quantity = 4;
            var min = 4;


            // Act
            var act = quantity.Validate()
                .IfLessThan(min);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Null_IfLessThanNullable_NoErrors()
        {
            // Arrange
            ushort? quantity = null;
            ushort min = 5;


            // Act
            var act = quantity.Validate()
                .IfLessThan(min);


            // Assert
            act.Errors.Should().HaveCount(0);
        }
    }
}
