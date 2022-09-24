using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Human
{
    public class IfNotGenderValidationTests
    {
        [Fact]
        public void NULL_IfNotGender_NoErrors()
        {
            // Arrange
            string gender = null;


            // Act
            var act = gender.Validate()
                .IfNotGender();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Empty_IfNotGender_OneError()
        {
            // Arrange
            var gender = "";


            // Act
            var act = gender.Validate()
                .IfNotGender();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(gender)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(gender)}' is invalid gender. The allowed values are 'MALE' and 'FEMALE'"
            );
        }

        [Fact]
        public void Invalid_IfNotGender_OneError()
        {
            // Arrange
            var gender = "xx";


            // Act
            var act = gender.Validate()
                .IfNotGender();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(gender)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(gender)}' is invalid gender. The allowed values are 'MALE' and 'FEMALE'"
            );
        }

        [Fact]
        public void Other_IfNotGender_OneError()
        {
            // Arrange
            var gender = "OTHER";


            // Act
            var act = gender.Validate()
                .IfNotGender();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(gender)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(gender)}' is invalid gender. The allowed values are 'MALE' and 'FEMALE'"
            );
        }

        [Theory]
        [InlineData("MALE")]
        [InlineData("FEMALE")]
        public void Valid_IfNotGender_OneError(string gender)
        {
            // Arrange && Act
            var act = gender.Validate()
                .IfNotGender();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Theory]
        [InlineData("male")]
        [InlineData("female")]
        public void ValidLowerCase_IfNotGender_NoErrors(string gender)
        {
            // Arrange && Act
            var act = gender.Validate()
                .IfNotGender();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ForbiddenError_IfNotGender_ErrorCode()
        {
            // Arrange
            var gender = "xx";

            var expectedProperty = "fakeProp Stream";
            var expectedCode = "fakeCode Stream";
            var expectedDescription = $"Fake description Stream > '{expectedProperty}'";


            // Act
            var act = gender.Validate()
                .IfNotGender(property =>
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
