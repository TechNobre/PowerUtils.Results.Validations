using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Strings
{
    public class IfLengthOutOfRangeValidationTests
    {
        [Fact]
        public void Null_IfLengthOutOfRange_NoErrors()
        {
            // Arrange
            string name = null;
            var min = 4;
            var max = 7;


            // Act
            var act = name.Validate()
                .IfLengthOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Short_IfLengthOutOfRange_OneMinError()
        {
            // Arrange
            var name = "ola";
            var min = 4;
            var max = 7;


            // Act
            var act = name.Validate()
                .IfLengthOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(name)
                &&
                c.Code == $"MIN:{min}"
                &&
                c.Description == $"The '{nameof(name)}' is too short. The minimum length is {min}"
            );
        }

        [Fact]
        public void Longer_IfLengthOutOfRange_OneMaxError()
        {
            // Arrange
            var name = "Vel ut gubergren est ut sed blandit ipsum";
            var min = 4;
            var max = 7;


            // Act
            var act = name.Validate()
                .IfLengthOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(name)
                &&
                c.Code == $"MAX:{max}"
                &&
                c.Description == $"The '{nameof(name)}' is too long. The maximum length is {max}"
            );
        }

        [Fact]
        public void ValidText_IfLengthOutOfRange_NoErrors()
        {
            // Arrange
            var name = "Power";
            var min = 4;
            var max = 7;


            // Act
            var act = name.Validate()
                .IfLengthOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ForbiddenError_IfLengthOutOfRange_ErrorCode()
        {
            // Arrange
            var client = "faker";
            var min = 40;
            var max = 70;

            var expectedProperty = "fakeProp fake range";
            var expectedCode = "fakeCode fake range";
            var expectedDescription = $"Fake description fake range > '{expectedProperty}'";


            // Act
            var act = client.Validate()
                .IfLengthOutOfRange(
                    min,
                    max,
                    property => Error.Forbidden(
                        expectedProperty,
                        expectedCode,
                        expectedDescription
                    ),
                    property => Error.Unauthorized(
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
