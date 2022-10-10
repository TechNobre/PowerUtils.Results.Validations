using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.ShouldRules.Human
{
    public class ShouldBeGenderOrOtherValidationTests
    {
        [Fact]
        public void NULL_ShouldBeGenderOrOther_NoErrors()
        {
            // Arrange
            string gender = null;


            // Act
            var act = gender.Validate()
                .ShouldBeGenderOrOther();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Empty_ShouldBeGenderOrOther_OneError()
        {
            // Arrange
            var gender = "";


            // Act
            var act = gender.Validate()
                .ShouldBeGenderOrOther();


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
        public void Invalid_ShouldBeGenderOrOther_OneError()
        {
            // Arrange
            var gender = "xx";


            // Act
            var act = gender.Validate()
                .ShouldBeGenderOrOther();


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
        public void Valid_ShouldBeGenderOrOther_OneError(string gender)
        {
            // Arrange && Act
            var act = gender.Validate()
                .ShouldBeGenderOrOther();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Theory]
        [InlineData("male")]
        [InlineData("female")]
        [InlineData("other")]
        public void ValidLowerCase_ShouldBeGenderOrOther_NoErrors(string gender)
        {
            // Arrange && Act
            var act = gender.Validate()
                .ShouldBeGenderOrOther();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ForbiddenError_ShouldBeGenderOrOther_ErrorCode()
        {
            // Arrange
            var gender = "xx";

            var expectedProperty = "fakeProp other";
            var expectedCode = "fakeCode other";
            var expectedDescription = $"Fake description other > '{expectedProperty}'";


            // Act
            var act = gender.Validate()
                .ShouldBeGenderOrOther(property =>
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
