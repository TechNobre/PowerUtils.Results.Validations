using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Strings
{
    public class IfEmptyValidationTests
    {
        [Fact]
        public void Null_IfEmpty_NoErrors()
        {
            // Arrange
            string client = null;


            // Act
            var act = client.Validate()
                .IfEmpty();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Empty_IfEmpty_OneError()
        {
            // Arrange
            var client = "";


            // Act
            var act = client.Validate()
                .IfEmpty();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == ErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(client)}' cannot be empty"
            );
        }

        [Fact]
        public void Withspaces_IfEmpty_NoErrors()
        {
            // Arrange
            var client = "    ";


            // Act
            var act = client.Validate()
                .IfEmpty();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Word_IfEmpty_NoErrors()
        {
            // Arrange
            var client = "fake";


            // Act
            var act = client.Validate()
                .IfEmpty();


            // Assert
            act.Errors.Should().HaveCount(0);
        }
    }
}
