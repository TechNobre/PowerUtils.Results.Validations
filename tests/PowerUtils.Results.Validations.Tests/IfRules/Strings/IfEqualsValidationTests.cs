using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Strings
{
    public class IfEqualsValidationTests
    {
        [Fact]
        public void Equals_IfEquals_OneError()
        {
            // Arrange
            var client = "Fake";
            var otherValue = "Fake";


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
        public void Different_IfEquals_NoErrors()
        {
            // Arrange
            var client = "Fake";
            var otherValue = "fake";


            // Act
            var act = client.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void DifferentText_IfEquals_NoErrors()
        {
            // Arrange
            var client = "no Fake";
            var otherValue = "Fake";


            // Act
            var act = client.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ValueNullOtherNotNull_IfEquals_NoErrors()
        {
            // Arrange
            string client = null;
            var otherValue = "Fake";


            // Act
            var act = client.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }



        [Fact]
        public void ValueNotNullOtherNull_IfEquals_NoErrors()
        {
            // Arrange
            var client = "Fake";
            string otherValue = null;


            // Act
            var act = client.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ValueNullOtherNull_IfEquals_OneError()
        {
            // Arrange
            string client = null;
            string otherValue = null;


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
        public void Equals_IfEqualsIgnoreCase_OneError()
        {
            // Arrange
            var client = "Fake";
            var otherValue = "Fake";


            // Act
            var act = client.Validate()
                .IfEquals(otherValue, StringComparison.InvariantCultureIgnoreCase);


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
        public void Equals_IfEqualsIgnoreCase_NoErrors()
        {
            // Arrange
            var client = "Fake";
            var otherValue = "fake";


            // Act
            var act = client.Validate()
                .IfEquals(otherValue, StringComparison.InvariantCultureIgnoreCase);


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
        public void DifferentText_IfEqualsIgnoreCase_NoErrors()
        {
            // Arrange
            var client = "no Fake";
            var otherValue = "Fake";


            // Act
            var act = client.Validate()
                .IfEquals(otherValue, StringComparison.InvariantCultureIgnoreCase);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ValueNullOtherNotNull_IfEqualsIgnoreCase_NoErrors()
        {
            // Arrange
            string client = null;
            var otherValue = "Fake";


            // Act
            var act = client.Validate()
                .IfEquals(otherValue, StringComparison.InvariantCultureIgnoreCase);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ValueNotNullOtherNull_IfEqualsIgnoreCase_NoErrors()
        {
            // Arrange
            var client = "Fake";
            string otherValue = null;


            // Act
            var act = client.Validate()
                .IfEquals(otherValue, StringComparison.InvariantCultureIgnoreCase);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ValueNullOtherNull_IfEqualsIgnoreCase_OneError()
        {
            // Arrange
            string client = null;
            string otherValue = null;


            // Act
            var act = client.Validate()
                .IfEquals(otherValue, StringComparison.InvariantCultureIgnoreCase);


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
            var client = "faker";
            var val = "FAKER";

            var expectedProperty = "fakeProp fake";
            var expectedCode = "fakeCode fake";
            var expectedDescription = $"Fake description fake > '{expectedProperty}'";


            // Act
            var act = client.Validate()
                .IfEquals(
                    val,
                    property => Error.Forbidden(
                        expectedProperty,
                        expectedCode,
                        expectedDescription
                    ),
                    StringComparison.InvariantCultureIgnoreCase
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
