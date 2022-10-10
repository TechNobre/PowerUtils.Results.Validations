using System.Linq;
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
                c.Code == ResultErrorCodes.INVALID
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
                c.Code == ResultErrorCodes.INVALID
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

        [Fact]
        public void ForbiddenError_IfZero_ErrorCode()
        {
            // Arrange
            short quantity = 0;

            var expectedProperty = "fakeProp";
            var expectedCode = "fakeCode";
            var expectedDescription = $"Fake description > '{expectedProperty}'";


            // Act
            var act = quantity.Validate()
                .IfZero(property =>
                    Error.Forbidden(
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
        public void ConflictError_IfZeroNullable_ErrorCode()
        {
            // Arrange
            double? quantity = 0;

            var expectedProperty = "fakeProp";
            var expectedCode = "fakeCode";
            var expectedDescription = $"Fake description > '{expectedProperty}'";


            // Act
            var act = quantity.Validate()
                .IfZero(property =>
                    Error.Conflict(
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
    }
}
