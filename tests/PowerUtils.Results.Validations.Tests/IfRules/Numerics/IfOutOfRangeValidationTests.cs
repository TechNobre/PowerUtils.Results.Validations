using System.Linq;
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


        [Fact]
        public void ForbiddenError_IfOutOfRange_ErrorCode()
        {
            // Arrange
            double quantity = 878979;
            double min = 5;
            double max = 155;

            var expectedProperty = "fakeProp";
            var expectedCode = "fakeCode";
            var expectedDescription = $"Fake description > '{expectedProperty}'";


            // Act
            var act = quantity.Validate()
                .IfOutOfRange(
                    min,
                    max,
                    property => Error.Forbidden(
                        expectedProperty,
                        expectedCode,
                        expectedDescription
                    ),
                    property => Error.Forbidden(
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
        public void ValidationError_IfOutOfRangeNullable_ErrorCode()
        {
            // Arrange
            decimal? quantity = 42;
            decimal min = -5;
            decimal max = -3155;

            var expectedProperty = "fakeProp";
            var expectedCode = "fakeCode";
            var expectedDescription = $"Fake description > '{expectedProperty}'";


            // Act
            var act = quantity.Validate()
                .IfOutOfRange(
                    min,
                    max,
                    property => Error.Validation(
                        expectedProperty,
                        expectedCode,
                        expectedDescription
                    ),
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
    }
}
