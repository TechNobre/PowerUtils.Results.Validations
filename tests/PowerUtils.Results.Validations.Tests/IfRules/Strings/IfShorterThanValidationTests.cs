using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Strings
{
    public class IfShorterThanValidationTests
    {
        [Fact]
        public void Null_IfShorterThan_NoErrors()
        {
            // Arrange
            string client = null;
            var min = 3;


            // Act
            var act = client.Validate()
                .IfShorterThan(min);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ShortText_IfShorterThan_OneError()
        {
            // Arrange
            var client = "Fk";
            var min = 3;


            // Act
            var act = client.Validate()
                .IfShorterThan(min);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == $"MIN:{min}"
                &&
                c.Description == $"The '{nameof(client)}' is too short. The minimum length is {min}"
            );
        }

        [Fact]
        public void BigText_IfShorterThan_NoErrors()
        {
            // Arrange
            var client = "Fake fake fake";
            var min = 3;


            // Act
            var act = client.Validate()
                .IfShorterThan(min);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void WithSpace_IfShorterThan_OneError()
        {
            // Arrange
            var client = " ";
            var min = 3;


            // Act
            var act = client.Validate()
                .IfShorterThan(min);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == $"MIN:{min}"
                &&
                c.Description == $"The '{nameof(client)}' is too short. The minimum length is {min}"
            );
        }
    }
}
