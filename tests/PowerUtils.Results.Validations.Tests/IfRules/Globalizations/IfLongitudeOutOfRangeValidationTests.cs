using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Globalizations
{
    public class IfLongitudeOutOfRangeValidationTests
    {
        [Fact]
        public void Small_IfLongitudeOutOfRange_OneError()
        {
            // Arrange
            var degree = -180.1f;


            // Act
            var act = degree.Validate()
                .IfLongitudeOutOfRange();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(degree)
                &&
                c.Code == ErrorCodes.MIN_LONGITUDE
                &&
                c.Description == $"The '{nameof(degree)}' is invalid. The minimum longitude is -180"
            );
        }

        [Fact]
        public void Large_IfLongitudeOutOfRange_OneError()
        {
            // Arrange
            var degree = 180.1;


            // Act
            var act = degree.Validate()
                .IfLongitudeOutOfRange();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(degree)
                &&
                c.Code == ErrorCodes.MAX_LONGITUDE
                &&
                 c.Description == $"The '{nameof(degree)}' is invalid. The maximum longitude is 180"
            );
        }

        [Fact]
        public void Valid_IfLongitudeOutOfRange_NoErrors()
        {
            // Arrange
            var degree = 18.1f;


            // Act
            var act = degree.Validate()
                .IfLongitudeOutOfRange();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Small_IfLongitudeOutOfRangeNullable_OneError()
        {
            // Arrange
            long? degree = -191;


            // Act
            var act = degree.Validate()
                .IfLongitudeOutOfRange();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(degree)
                &&
                c.Code == ErrorCodes.MIN_LONGITUDE
                &&
                c.Description == $"The '{nameof(degree)}' is invalid. The minimum longitude is -180"
            );
        }

        [Fact]
        public void Large_IfLongitudeOutOfRangeNullable_OneError()
        {
            // Arrange
            decimal? degree = 180.1m;


            // Act
            var act = degree.Validate()
                .IfLongitudeOutOfRange();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(degree)
                &&
                c.Code == ErrorCodes.MAX_LONGITUDE
                &&
                 c.Description == $"The '{nameof(degree)}' is invalid. The maximum longitude is 180"
            );
        }

        [Fact]
        public void Valid_IfLongitudeOutOfRangeNullable_NoErrors()
        {
            // Arrange
            float? degree = 18.1f;


            // Act
            var act = degree.Validate()
                .IfLongitudeOutOfRange();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Null_IfLongitudeOutOfRangeNullable_NoErrors()
        {
            // Arrange
            double? degree = null;


            // Act
            var act = degree.Validate()
                .IfLongitudeOutOfRange();


            // Assert
            act.Errors.Should().HaveCount(0);
        }



        [Fact]
        public void ForbiddenError_IfLongitudeOutOfRange_ErrorCode()
        {
            // Arrange
            var degree = 180.1m;

            var expectedProperty = "fakeProp coor";
            var expectedCode = "fakeCode coor";
            var expectedDescription = $"Fake description coor > '{expectedProperty}'";


            // Act
            var act = degree.Validate()
                .IfLongitudeOutOfRange(
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
        public void ForbiddenError_IfLongitudeOutOfRangeNullable_ErrorCode()
        {
            // Arrange
            double? degree = 180.1;

            var expectedProperty = "fakeProp lat";
            var expectedCode = "fakeCode lat";
            var expectedDescription = $"Fake description lat > '{expectedProperty}'";


            // Act
            var act = degree.Validate()
                .IfLongitudeOutOfRange(
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
