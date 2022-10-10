using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Globalizations
{
    public class IfLatitudeOutOfRangeValidationTests
    {
        [Fact]
        public void Small_IfLatitudeOutOfRange_OneError()
        {
            // Arrange
            var degree = -90.1f;


            // Act
            var act = degree.Validate()
                .IfLatitudeOutOfRange();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(degree)
                &&
                c.Code == ErrorCodeFactory.MIN_LATITUDE
                &&
                c.Description == $"The '{nameof(degree)}' is invalid. The minimum latitude is -90"
            );
        }

        [Fact]
        public void Large_IfLatitudeOutOfRange_OneError()
        {
            // Arrange
            var degree = 90.1;


            // Act
            var act = degree.Validate()
                .IfLatitudeOutOfRange();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(degree)
                &&
                c.Code == ErrorCodeFactory.MAX_LATITUDE
                &&
                 c.Description == $"The '{nameof(degree)}' is invalid. The maximum latitude is 90"
            );
        }

        [Fact]
        public void Valid_IfLatitudeOutOfRange_NoErrors()
        {
            // Arrange
            var degree = 18.1f;


            // Act
            var act = degree.Validate()
                .IfLatitudeOutOfRange();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void EqualsMin_IfLatitudeOutOfRange_NoErrors()
        {
            // Arrange
            var degree = -90;


            // Act
            var act = degree.Validate()
                .IfLatitudeOutOfRange();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void EqualsMax_IfLatitudeOutOfRange_NoErrors()
        {
            // Arrange
            var degree = 90;


            // Act
            var act = degree.Validate()
                .IfLatitudeOutOfRange();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void EqualsMin_IfLatitudeOutOfRangeNullable_NoErrors()
        {
            // Arrange
            float? degree = -90;


            // Act
            var act = degree.Validate()
                .IfLatitudeOutOfRange();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void EqualsMax_IfLatitudeOutOfRangeNullable_NoErrors()
        {
            // Arrange
            float? degree = 90;


            // Act
            var act = degree.Validate()
                .IfLatitudeOutOfRange();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Small_IfLatitudeOutOfRangeNullable_OneError()
        {
            // Arrange
            long? degree = -91;


            // Act
            var act = degree.Validate()
                .IfLatitudeOutOfRange();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(degree)
                &&
                c.Code == ErrorCodeFactory.MIN_LATITUDE
                &&
                c.Description == $"The '{nameof(degree)}' is invalid. The minimum latitude is -90"
            );
        }

        [Fact]
        public void Large_IfLatitudeOutOfRangeNullable_OneError()
        {
            // Arrange
            decimal? degree = 90.1m;


            // Act
            var act = degree.Validate()
                .IfLatitudeOutOfRange();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(degree)
                &&
                c.Code == ErrorCodeFactory.MAX_LATITUDE
                &&
                 c.Description == $"The '{nameof(degree)}' is invalid. The maximum latitude is 90"
            );
        }

        [Fact]
        public void Valid_IfLatitudeOutOfRangeNullable_NoErrors()
        {
            // Arrange
            float? degree = 18.1f;


            // Act
            var act = degree.Validate()
                .IfLatitudeOutOfRange();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Null_IfLatitudeOutOfRangeNullable_NoErrors()
        {
            // Arrange
            double? degree = null;


            // Act
            var act = degree.Validate()
                .IfLatitudeOutOfRange();


            // Assert
            act.Errors.Should().HaveCount(0);
        }


        [Fact]
        public void ForbiddenError_IfLatitudeOutOfRange_ErrorCode()
        {
            // Arrange
            var degree = 90.1m;

            var expectedProperty = "fakeProp coor";
            var expectedCode = "fakeCode coor";
            var expectedDescription = $"Fake description coor > '{expectedProperty}'";


            // Act
            var act = degree.Validate()
                .IfLatitudeOutOfRange(
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
        public void ForbiddenError_IfLatitudeOutOfRangeNullable_ErrorCode()
        {
            // Arrange
            double? degree = 90.1;

            var expectedProperty = "fakeProp lat";
            var expectedCode = "fakeCode lat";
            var expectedDescription = $"Fake description lat > '{expectedProperty}'";


            // Act
            var act = degree.Validate()
                .IfLatitudeOutOfRange(
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
    }
}
