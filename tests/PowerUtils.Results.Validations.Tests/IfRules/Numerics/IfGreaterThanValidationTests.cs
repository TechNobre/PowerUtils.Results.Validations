using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Numerics
{
    public class IfGreaterThanValidationTests
    {
        [Fact]
        public void LargeNumber_IfGreaterThan_OneError()
        {
            // Arrange
            var quantity = 241;
            var max = 5;


            // Act
            var act = quantity.Validate()
                .IfGreaterThan(max);


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
        public void SmallNumber_IfGreaterThan_NoErrors()
        {
            // Arrange
            var quantity = 4;
            var max = 5;


            // Act
            var act = quantity.Validate()
                .IfGreaterThan(max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void EqualsNumber_IfGreaterThan_NoErrors()
        {
            // Arrange
            var quantity = 4;
            var max = 4;


            // Act
            var act = quantity.Validate()
                .IfGreaterThan(max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }



        [Fact]
        public void LargeNumber_IfGreaterThanNullable_OneError()
        {
            // Arrange
            double? quantity = 241.45;
            var max = 5;


            // Act
            var act = quantity.Validate()
                .IfGreaterThan(max);


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
        public void SmallNumber_IfGreaterThanNullable_NoErrors()
        {
            // Arrange
            ulong? quantity = 4;
            var max = 5ul;


            // Act
            var act = quantity.Validate()
                .IfGreaterThan(max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void EqualsNumber_IfGreaterThanNullable_NoErrors()
        {
            // Arrange
            float? quantity = 4;
            var max = 4;


            // Act
            var act = quantity.Validate()
                .IfGreaterThan(max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Null_IfGreaterThanNullable_NoErrors()
        {
            // Arrange
            short? quantity = null;
            short max = 5;


            // Act
            var act = quantity.Validate()
                .IfGreaterThan(max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void UnauthorizedError_IfGreaterThan_ErrorCode()
        {
            // Arrange
            long quantity = 0;
            long max = -4575125;

            var expectedProperty = "fakeProp";
            var expectedCode = "fakeCode";
            var expectedDescription = $"Fake description > '{expectedProperty}'";


            // Act
            var act = quantity.Validate()
                .IfGreaterThan(
                    max,
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
        public void UnexpectedError_IfGreaterThanNullable_ErrorCode()
        {
            // Arrange
            uint? quantity = 654650;
            uint max = 425;

            var expectedProperty = "fakeProp";
            var expectedCode = "fakeCode";
            var expectedDescription = $"Fake description > '{expectedProperty}'";


            // Act
            var act = quantity.Validate()
                .IfGreaterThan(
                    max,
                    property => Error.Unexpected(
                        expectedProperty,
                        expectedCode,
                        expectedDescription
                    )
                );


            // Assert
            act.Errors.Should().HaveCount(1);
            act.Errors.First().Should().BeOfType<UnexpectedError>();

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
