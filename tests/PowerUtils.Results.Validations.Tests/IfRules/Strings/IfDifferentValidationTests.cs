using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Strings
{
    public class IfDifferentValidationTests
    {
        [Fact]
        public void Equals_IfDifferent_NoErrors()
        {
            // Arrange
            var client = "Fake";
            var otherValue = "Fake";


            // Act
            var act = client.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Different_IfDifferent_OneError()
        {
            // Arrange
            var client = "Fake";
            var otherValue = "fake";


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
        public void DifferentText_IfDifferent_OneError()
        {
            // Arrange
            var client = "no Fake";
            var otherValue = "Fake";


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
        public void ValueNullOtherNotNull_IfDifferent_OneError()
        {
            // Arrange
            string client = null;
            var otherValue = "Fake";


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
        public void ValueNotNullOtherNull_IfDifferent_OneError()
        {
            // Arrange
            var client = "Fake";
            string otherValue = null;


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
        public void ValueNullOtherNull_IfDifferent_NoErrors()
        {
            // Arrange
            string client = null;
            string otherValue = null;


            // Act
            var act = client.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }



        [Fact]
        public void Equals_IfDifferentIgnoreCase_NoErrors()
        {
            // Arrange
            var client = "Fake";
            var otherValue = "Fake";


            // Act
            var act = client.Validate()
                .IfDifferent(otherValue, StringComparison.InvariantCultureIgnoreCase);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Different_IfDifferentIgnoreCase_NoErrors()
        {
            // Arrange
            var client = "Fake";
            var otherValue = "fake";


            // Act
            var act = client.Validate()
                .IfDifferent(otherValue, StringComparison.InvariantCultureIgnoreCase);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void DifferentText_IfDifferentIgnoreCase_OneError()
        {
            // Arrange
            var client = "no Fake";
            var otherValue = "Fake";


            // Act
            var act = client.Validate()
                .IfDifferent(otherValue, StringComparison.InvariantCultureIgnoreCase);


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
        public void ValueNullOtherNotNull_IfDifferentIgnoreCase_OneError()
        {
            // Arrange
            string client = null;
            var otherValue = "Fake";


            // Act
            var act = client.Validate()
                .IfDifferent(otherValue, StringComparison.InvariantCultureIgnoreCase);


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
        public void ValueNotNullOtherNull_IfDifferentIgnoreCase_OneError()
        {
            // Arrange
            var client = "Fake";
            string otherValue = null;


            // Act
            var act = client.Validate()
                .IfDifferent(otherValue, StringComparison.InvariantCultureIgnoreCase);


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
        public void ValueNullOtherNull_IfDifferentIgnoreCase_NoErrors()
        {
            // Arrange
            string client = null;
            string otherValue = null;


            // Act
            var act = client.Validate()
                .IfDifferent(otherValue, StringComparison.InvariantCultureIgnoreCase);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ForbiddenError_IfDifferent_ErrorCode()
        {
            // Arrange
            var client = "faker";
            var val = "faker__";

            var expectedProperty = "fakeProp fake";
            var expectedCode = "fakeCode fake";
            var expectedDescription = $"Fake description fake > '{expectedProperty}'";


            // Act
            var act = client.Validate()
                .IfDifferent(
                    val,
                    property => Error.Forbidden(
                        expectedProperty,
                        expectedCode,
                        expectedDescription
                    ),
                    StringComparison.CurrentCulture
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
