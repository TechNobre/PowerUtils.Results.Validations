using System.Linq;
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

        [Fact]
        public void UnauthorizedError_IfLessThan_ErrorCode()
        {
            // Arrange
            float quantity = -65460;
            float min = -425;

            var expectedProperty = "fakeProp";
            var expectedCode = "fakeCode";
            var expectedDescription = $"Fake description > '{expectedProperty}'";


            // Act
            var act = quantity.Validate()
                .IfLessThan(
                    min,
                    property => Error.Unauthorized(
                        expectedProperty,
                        expectedCode,
                        expectedDescription
                    )
                );


            // Assert
            act.Errors.Should().HaveCount(1);
            act.Errors.First().Should().BeOfType<UnauthorizedError>();

            act.Errors.Should().OnlyContain(c =>
                c.Property == expectedProperty
                &&
                c.Code == expectedCode
                &&
                c.Description == expectedDescription
            );
        }

        [Fact]
        public void Error_IfLessThanNullable_ErrorCode()
        {
            // Arrange
            decimal? quantity = -650;
            decimal min = 425;

            var expectedProperty = "fakeProp";
            var expectedCode = "fakeCode";
            var expectedDescription = $"Fake description > '{expectedProperty}'";


            // Act
            var act = quantity.Validate()
                .IfLessThan(
                    min,
                    property => Error.Failure(
                        expectedProperty,
                        expectedCode,
                        expectedDescription
                    )
                );


            // Assert
            act.Errors.Should().HaveCount(1);
            act.Errors.First().Should().BeOfType<Error>();

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
