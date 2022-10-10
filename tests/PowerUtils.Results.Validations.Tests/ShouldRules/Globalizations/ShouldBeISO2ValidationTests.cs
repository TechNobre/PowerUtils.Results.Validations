using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.ShouldRules.Globalizations
{
    public class ShouldBeISO2ValidationTests
    {
        [Fact]
        public void NULL_ShouldBeISO2_NoErrors()
        {
            // Arrange
            string countryCode = null;


            // Act
            var act = countryCode.Validate()
                .ShouldBeISO2();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Empty_ShouldBeISO2_OneError()
        {
            // Arrange
            var countryCode = "";


            // Act
            var act = countryCode.Validate()
                .ShouldBeISO2();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(countryCode)
                &&
                c.Code == ResultErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(countryCode)}' is invalid country code. ISO2 formats are allowed"
            );
        }

        [Fact]
        public void Invalid_ShouldBeISO2_OneError()
        {
            // Arrange
            var countryCode = "xx";


            // Act
            var act = countryCode.Validate()
                .ShouldBeISO2();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(countryCode)
                &&
                c.Code == ResultErrorCodes.INVALID
                &&
                 c.Description == $"The '{nameof(countryCode)}' is invalid country code. ISO2 formats are allowed"
            );
        }

        [Fact]
        public void Valid_ShouldBeISO2_NoErrors()
        {
            // Arrange
            var countryCode = "PT";


            // Act
            var act = countryCode.Validate()
                .ShouldBeISO2();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ValidLowerCase_ShouldBeISO2_NoErrors()
        {
            // Arrange
            var countryCode = "pt";


            // Act
            var act = countryCode.Validate()
                .ShouldBeISO2();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ISO3_ShouldBeISO2_OneError()
        {
            // Arrange
            var countryCode = "ptr";


            // Act
            var act = countryCode.Validate()
                .ShouldBeISO2();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(countryCode)
                &&
                c.Code == ResultErrorCodes.INVALID
                &&
                 c.Description == $"The '{nameof(countryCode)}' is invalid country code. ISO2 formats are allowed"
            );
        }

        [Fact]
        public void ForbiddenError_ShouldBeISO2_ErrorCode()
        {
            // Arrange
            var countryCode = "ptr";

            var expectedProperty = "fakeProp iso";
            var expectedCode = "fakeCode iso";
            var expectedDescription = $"Fake description iso > '{expectedProperty}'";


            // Act
            var act = countryCode.Validate()
                .ShouldBeISO2(
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
