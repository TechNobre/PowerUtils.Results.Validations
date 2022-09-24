using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Objects
{
    public class IfEqualsValidationTests
    {
        [Fact]
        public void BothNull_IfEquals_OneError()
        {
            // Arrange
            object client = null;
            object otherValue = null;


            // Act
            var act = client.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(client)}' cannot be equal to '{otherValue}'"
            );
        }

        [Fact]
        public void ValueNull_IfEquals_NoErrors()
        {
            // Arrange
            object client = null;
            var otherValue = new object();


            // Act
            var act = client.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void OtherNull_IfEquals_NoErrors()
        {
            // Arrange
            var client = new object();
            object otherValue = null;


            // Act
            var act = client.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Equals_IfEquals_OneError()
        {
            // Arrange
            var client = new object();
            var otherValue = client;


            // Act
            var act = client.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(client)}' cannot be equal to '{otherValue}'"
            );
        }

        [Fact]
        public void ForbiddenError_IfEquals_ErrorCode()
        {
            // Arrange
            var client = new object();
            var otherValue = client;

            var expectedProperty = "fakeProp";
            var expectedCode = "fakeCode";
            var expectedDescription = $"Fake description > '{expectedProperty}'";


            // Act
            var act = client.Validate()
                .IfEquals(
                    otherValue,
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
