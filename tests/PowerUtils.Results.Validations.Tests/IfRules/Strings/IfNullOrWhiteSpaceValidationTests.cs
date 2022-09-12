using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Strings
{
    public class IfNullOrWhiteSpaceValidationTests
    {
        [Fact]
        public void Null_IfNullOrWhiteSpace_OneError()
        {
            // Arrange
            string client = null;


            // Act
            var act = client.Validate()
                .IfNullOrWhiteSpace();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == ErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(client)}' cannot be null or white spaces"
            );
        }

        [Fact]
        public void Empty_IfNullOrWhiteSpace_OneError()
        {
            // Arrange
            var client = "";


            // Act
            var act = client.Validate()
                .IfNullOrWhiteSpace();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == ErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(client)}' cannot be null or white spaces"
            );
        }

        [Fact]
        public void WithSpace_IfNullOrWhiteSpace_OneError()
        {
            // Arrange
            var client = "      ";


            // Act
            var act = client.Validate()
                .IfNullOrWhiteSpace();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == ErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(client)}' cannot be null or white spaces"
            );
        }

        [Fact]
        public void Value_IfNullOrWhiteSpace_Valid()
        {
            // Arrange
            var client = "fake";


            // Act
            var act = client.Validate()
                .IfNullOrWhiteSpace();


            // Assert
            act.Errors.Should().HaveCount(0);
        }
    }
}
