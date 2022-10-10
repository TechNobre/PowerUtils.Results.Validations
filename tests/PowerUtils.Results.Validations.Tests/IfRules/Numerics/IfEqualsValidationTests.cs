using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Numerics
{
    public class IfEqualsValidationTests
    {
        [Fact]
        public void LargeNumber_IfEquals_NoErrors()
        {
            // Arrange
            var quantity = 241;
            var otherValue = 5;


            // Act
            var act = quantity.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void SmallNumber_IfEquals_NoErrors()
        {
            // Arrange
            var quantity = 4;
            var otherValue = 5;


            // Act
            var act = quantity.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void EqualsNumber_IfEquals_OneError()
        {
            // Arrange
            var quantity = 4;
            var otherValue = 4;


            // Act
            var act = quantity.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(quantity)
                &&
                c.Code == ResultErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(quantity)}' cannot be equal to '{otherValue}'"
            );
        }



        [Fact]
        public void LargeNumber_IfEqualsNullable_NoErrors()
        {
            // Arrange
            ulong? quantity = 241;
            var otherValue = 5ul;


            // Act
            var act = quantity.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void SmallNumber_IfEqualsNullable_NoErrors()
        {
            // Arrange
            uint? quantity = 4;
            var otherValue = 5u;


            // Act
            var act = quantity.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void EqualsNumber_IfEqualsNullable_OneError()
        {
            // Arrange
            decimal? quantity = 4;
            var otherValue = 4;


            // Act
            var act = quantity.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(quantity)
                &&
                c.Code == ResultErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(quantity)}' cannot be equal to '{otherValue}'"
            );
        }

        [Fact]
        public void Null_IfEqualsNullable_NoErrors()
        {
            // Arrange
            ushort? quantity = null;
            ushort otherValue = 5;


            // Act
            var act = quantity.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }


        [Fact]
        public void ValidationError_IfEquals_ErrorCode()
        {
            // Arrange
            double quantity = 42340;
            double otherValue = 42340;

            var expectedProperty = "fakeProp";
            var expectedCode = "fakeCode";
            var expectedDescription = $"Fake description > '{expectedProperty}'";


            // Act
            var act = quantity.Validate()
                .IfEquals(
                    otherValue,
                    property => Error.Validation(
                        expectedProperty,
                        expectedCode,
                        expectedDescription
                    )
                );


            // Assert
            act.Errors.Should().HaveCount(1);
            act.Errors.First().Should().BeOfType<ValidationError>();

            act.Errors.Should().OnlyContain(c =>
                c.Property == expectedProperty
                &&
                c.Code == expectedCode
                &&
                c.Description == expectedDescription
            );
        }


        [Fact]
        public void NotFoundError_IfEqualsNullable_ErrorCode()
        {
            // Arrange
            float? quantity = -124;
            float otherValue = -124;

            var expectedProperty = "fakeProp";
            var expectedCode = "fakeCode";
            var expectedDescription = $"Fake description > '{expectedProperty}'";


            // Act
            var act = quantity.Validate()
                .IfEquals(
                    otherValue,
                    property => Error.NotFound(
                        expectedProperty,
                        expectedCode,
                        expectedDescription
                    )
                );


            // Assert
            act.Errors.Should().HaveCount(1);
            act.Errors.First().Should().BeOfType<NotFoundError>();

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
