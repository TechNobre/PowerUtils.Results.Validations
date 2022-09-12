using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Strings
{
    public class IfNullOrEmptyValidationTests
    {
        [Fact]
        public void Null_IfNullOrEmpty_OneError()
        {
            // Arrange
            string client = null;


            // Act
            var act = client.Validate()
                .IfNullOrEmpty();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == ErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(client)}' cannot be null or empty"
            );
        }

        [Fact]
        public void Empty_IfNullOrEmpty_OneError()
        {
            // Arrange
            var client = "";


            // Act
            var act = client.Validate()
                .IfNullOrEmpty();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == ErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(client)}' cannot be null or empty"
            );
        }

        [Fact]
        public void Value_IfNullOrEmpty_NoErrors()
        {
            // Arrange
            var client = "fake";


            // Act
            var act = client.Validate()
                .IfNullOrEmpty();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Withspaces_IfNullOrEmpty_NoErrors()
        {
            // Arrange
            var client = "    ";


            // Act
            var act = client.Validate()
                .IfNullOrEmpty();


            // Assert
            act.Errors.Should().HaveCount(0);
        }
    }
}
