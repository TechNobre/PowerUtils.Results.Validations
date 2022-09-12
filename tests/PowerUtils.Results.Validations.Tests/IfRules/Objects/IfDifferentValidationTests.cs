using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Objects
{
    public class IfDifferentValidationTests
    {
        [Fact]
        public void BothNull_IfDifferent_NoErrors()
        {
            // Arrange
            object client = null;
            object otherValue = null;


            // Act
            var act = client.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ValueNull_IfDifferent_OneError()
        {
            // Arrange
            object client = null;
            var otherValue = new object();


            // Act
            var act = client.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(client)}' cannot be different to '{otherValue}'"
            );
        }

        [Fact]
        public void OtherNull_IfDifferent_OneError()
        {
            // Arrange
            var client = new object();
            object otherValue = null;


            // Act
            var act = client.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(client)}' cannot be different to '{otherValue}'"
            );
        }

        [Fact]
        public void Equals_IfDifferent_NoErrors()
        {
            // Arrange
            var client = new object();
            var otherValue = client;


            // Act
            var act = client.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }
    }
}
