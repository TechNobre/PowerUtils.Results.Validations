using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Human
{
    public class IfNotGenderOrOtherValidationTests
    {
        [Fact]
        public void NULL_IfNotGenderOrOther_NoErrors()
        {
            // Arrange
            string gender = null;


            // Act
            var act = gender.Validate()
                .IfNotGenderOrOther();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Empty_IfNotGenderOrOther_OneError()
        {
            // Arrange
            var gender = "";


            // Act
            var act = gender.Validate()
                .IfNotGenderOrOther();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(gender)
                &&
                c.Code == ResultErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(gender)}' is invalid gender. The allowed values are 'MALE', 'FEMALE' or 'OTHER'"
            );
        }

        [Fact]
        public void Invalid_IfNotGenderOrOther_OneError()
        {
            // Arrange
            var gender = "xx";


            // Act
            var act = gender.Validate()
                .IfNotGenderOrOther();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(gender)
                &&
                c.Code == ResultErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(gender)}' is invalid gender. The allowed values are 'MALE', 'FEMALE' or 'OTHER'"
            );
        }

        [Theory]
        [InlineData("MALE")]
        [InlineData("FEMALE")]
        [InlineData("OTHER")]
        public void Valid_IfNotGenderOrOther_OneError(string gender)
        {
            // Arrange && Act
            var act = gender.Validate()
                .IfNotGenderOrOther();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Theory]
        [InlineData("male")]
        [InlineData("female")]
        [InlineData("other")]
        public void ValidLowerCase_IfNotGenderOrOther_NoErrors(string gender)
        {
            // Arrange && Act
            var act = gender.Validate()
                .IfNotGenderOrOther();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ForbiddenError_IfNotGenderOrOther_ErrorCode()
        {
            // Arrange
            var gender = "xx";

            var expectedProperty = "fakeProp Stream";
            var expectedCode = "fakeCode Stream";
            var expectedDescription = $"Fake description Stream > '{expectedProperty}'";


            // Act
            var act = gender.Validate()
                .IfNotGenderOrOther(property =>
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
    }
}
