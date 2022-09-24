using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.DateTimes
{
    public class IfOutOfRangeValidationTests
    {
        [Fact]
        public void InRange_IfOutOfRange_NoErrors()
        {
            // Arrange
            var dateOfBirth = new DateTime(2021, 1, 1);
            var min = new DateTime(2000, 12, 31);
            var max = new DateTime(2021, 1, 2);


            // Act
            var act = dateOfBirth.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void EqualsMin_IfOutOfRange_NoErrors()
        {
            // Arrange
            var dateOfBirth = new DateTime(1557, 4, 17);
            var min = new DateTime(1557, 4, 17);
            var max = new DateTime(2021, 1, 2);


            // Act
            var act = dateOfBirth.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void EqualsMax_IfOutOfRange_NoErrors()
        {
            // Arrange
            var dateOfBirth = new DateTime(1998, 11, 21);
            var min = new DateTime(1557, 4, 17);
            var max = new DateTime(1998, 11, 21);


            // Act
            var act = dateOfBirth.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void EqualsMin_IfOutOfRangeNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = new DateTime(1557, 4, 17);
            var min = new DateTime(1557, 4, 17);
            var max = new DateTime(2021, 1, 2);


            // Act
            var act = dateOfBirth.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void EqualsMax_IfOutOfRangeNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = new DateTime(1998, 11, 21);
            var min = new DateTime(1557, 4, 17);
            var max = new DateTime(1998, 11, 21);


            // Act
            var act = dateOfBirth.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Past_IfOutOfRange_OneError()
        {
            // Arrange
            var dateOfBirth = new DateTime(1999, 1, 1);
            var min = new DateTime(2000, 12, 31);
            var max = new DateTime(2021, 1, 2);


            // Act
            var act = dateOfBirth.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MIN:2000-12-31"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very old. The minimum is 2000-12-31"
            );
        }

        [Fact]
        public void Future_IfOutOfRange_OneError()
        {
            // Arrange
            var dateOfBirth = new DateTime(2022, 1, 1);
            var min = new DateTime(2000, 12, 31);
            var max = new DateTime(2021, 1, 2);


            // Act
            var act = dateOfBirth.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MAX:2021-01-02"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very future. The maximum is 2021-01-02"
            );
        }


        [Fact]
        public void ForbiddenError_IfOutOfRange_ErrorCode()
        {
            // Arrange
            var dateOfBirth = new DateTime(2022, 1, 1);
            var min = new DateTime(2000, 12, 31);
            var max = new DateTime(2021, 1, 2);

            var expectedProperty = "fakeProp lat";
            var expectedCode = "fakeCode lat";
            var expectedDescription = $"Fake description lat > '{expectedProperty}'";


            // Act
            var act = dateOfBirth.Validate()
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
        public void NULL_IfOutOfRangeNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = null;
            var min = new DateTime(2000, 12, 31);
            var max = new DateTime(2021, 1, 2);


            // Act
            var act = dateOfBirth.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void InRange_IfOutOfRangeNullable_NoErrors()
        {
            // Arrange
            DateTime? dateOfBirth = new DateTime(2021, 1, 1);
            var min = new DateTime(2000, 12, 31);
            var max = new DateTime(2021, 1, 2);


            // Act
            var act = dateOfBirth.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Past_IfOutOfRangeNullable_OneError()
        {
            // Arrange
            DateTime? dateOfBirth = new DateTime(1999, 1, 1);
            var min = new DateTime(2000, 12, 31);
            var max = new DateTime(2021, 1, 2);


            // Act
            var act = dateOfBirth.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MIN:2000-12-31"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very old. The minimum is 2000-12-31"
            );
        }

        [Fact]
        public void Future_IfOutOfRangeNullable_OneError()
        {
            // Arrange
            DateTime? dateOfBirth = new DateTime(2022, 1, 1);
            var min = new DateTime(2000, 12, 31);
            var max = new DateTime(2021, 1, 2);


            // Act
            var act = dateOfBirth.Validate()
                .IfOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(dateOfBirth)
                &&
                c.Code == "MAX:2021-01-02"
                &&
                c.Description == $"The '{nameof(dateOfBirth)}' is very future. The maximum is 2021-01-02"
            );
        }


        [Fact]
        public void ForbiddenError_IfOutOfRangeNullable_ErrorCode()
        {
            // Arrange
            DateTime? dateOfBirth = new DateTime(2022, 1, 1);
            var min = new DateTime(2000, 12, 31);
            var max = new DateTime(2021, 1, 2);

            var expectedProperty = "fakeProp lat";
            var expectedCode = "fakeCode lat";
            var expectedDescription = $"Fake description lat > '{expectedProperty}'";


            // Act
            var act = dateOfBirth.Validate()
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
    }
}
