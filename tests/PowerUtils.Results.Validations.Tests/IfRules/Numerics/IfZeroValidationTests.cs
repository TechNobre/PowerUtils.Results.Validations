using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Numerics
{
    public class IfZeroValidationTests
    {
        [Fact]
        public void Different_IfZero_NoErrors()
        {
            // Arrange
            var quantity = 241;


            // Act
            var act = quantity.Validate()
                .IfZero();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Equals_IfZero_OneError()
        {
            // Arrange
            var quantity = 0;


            // Act
            var act = quantity.Validate()
                .IfZero();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(quantity)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(quantity)}' cannot be equal to '0'"
            );
        }



        [Fact]
        public void Different_IfZeroNullable_NoErrors()
        {
            // Arrange
            ulong? quantity = 241;


            // Act
            var act = quantity.Validate()
                .IfZero();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Equals_IfZeroNullable_OneError()
        {
            // Arrange
            decimal? quantity = 0;


            // Act
            var act = quantity.Validate()
                .IfZero();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(quantity)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(quantity)}' cannot be equal to '0'"
            );
        }

        [Fact]
        public void Null_IfZeroNullable_NoErrors()
        {
            // Arrange
            ushort? quantity = null;


            // Act
            var act = quantity.Validate()
                .IfZero();


            // Assert
            act.Errors.Should().HaveCount(0);
        }
    }
}
