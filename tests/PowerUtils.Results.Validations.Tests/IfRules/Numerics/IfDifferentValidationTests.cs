using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Numerics
{
    public class IfDifferentValidationTests
    {
        [Fact]
        public void LargeNumber_IfDifferent_OneError()
        {
            // Arrange
            var quantity = 241;
            var otherValue = 5;


            // Act
            var act = quantity.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(quantity)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(quantity)}' cannot be different to '{otherValue}'"
            );
        }

        [Fact]
        public void SmallNumber_IfDifferent_OneError()
        {
            // Arrange
            var quantity = 4;
            var otherValue = 5;


            // Act
            var act = quantity.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(quantity)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(quantity)}' cannot be different to '{otherValue}'"
            );
        }

        [Fact]
        public void EqualsNumber_IfDifferent_NoErrors()
        {
            // Arrange
            var quantity = 4;
            var otherValue = 4;


            // Act
            var act = quantity.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }



        [Fact]
        public void LargeNumber_IfDifferentNullable_OneError()
        {
            // Arrange
            ulong? quantity = 241;
            var otherValue = 5ul;


            // Act
            var act = quantity.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(quantity)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(quantity)}' cannot be different to '{otherValue}'"
            );
        }

        [Fact]
        public void SmallNumber_IfDifferentNullable_OneError()
        {
            // Arrange
            uint? quantity = 4;
            var otherValue = 5u;


            // Act
            var act = quantity.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(quantity)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(quantity)}' cannot be different to '{otherValue}'"
            );
        }

        [Fact]
        public void EqualsNumber_IfDifferentNullable_NoErrors()
        {
            // Arrange
            decimal? quantity = 4;
            var otherValue = 4;


            // Act
            var act = quantity.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Null_IfDifferentNullable_OneError()
        {
            // Arrange
            ushort? quantity = null;
            ushort otherValue = 5;


            // Act
            var act = quantity.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(quantity)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(quantity)}' cannot be different to '{otherValue}'"
            );
        }

        [Fact]
        public void ConflictError_IfDifferent_ErrorCode()
        {
            // Arrange
            double quantity = -42340;
            double otherValue = 42340;

            var expectedProperty = "fakeProp";
            var expectedCode = "fakeCode";
            var expectedDescription = $"Fake description > '{expectedProperty}'";


            // Act
            var act = quantity.Validate()
                .IfDifferent(
                    otherValue,
                    property => Error.Conflict(
                        expectedProperty,
                        expectedCode,
                        expectedDescription
                    )
                );


            // Assert
            act.Errors.Should().HaveCount(1);
            act.Errors.First().Should().BeOfType<ConflictError>();

            act.Errors.Should().OnlyContain(c =>
                c.Property == expectedProperty
                &&
                c.Code == expectedCode
                &&
                c.Description == expectedDescription
            );
        }


        [Fact]
        public void NotFoundError_IfDifferentNullable_ErrorCode()
        {
            // Arrange
            int? quantity = -234;
            var otherValue = -423423;

            var expectedProperty = "fakeProp";
            var expectedCode = "fakeCode";
            var expectedDescription = $"Fake description > '{expectedProperty}'";


            // Act
            var act = quantity.Validate()
                .IfDifferent(
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
