using System;
using System.IO;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Streams
{
    public class IfEmptyValidationTests
    {
        [Fact]
        public void Null_IfEmpty_NoErrors()
        {
            // Arrange
            Stream val = null;


            // Act
            var act = val.Validate()
                .IfEmpty();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Empty_IfEmpty_OneError()
        {
            // Arrange
            Stream val = new MemoryStream(Array.Empty<byte>());


            // Act
            var act = val.Validate()
                .IfEmpty();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(val)
                &&
                c.Code == ErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(val)}' cannot be empty"
            );
        }

        [Fact]
        public void AnyValue_IfEmpty_NoErrors()
        {
            // Arrange
            Stream val = new MemoryStream(new byte[] { 1, 2, 3 });


            // Act
            var act = val.Validate()
                .IfEmpty();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ForbiddenError_IfEmpty_ErrorCode()
        {
            // Arrange
            Stream val = new MemoryStream(Array.Empty<byte>());

            var expectedProperty = "fakeProp Stream";
            var expectedCode = "fakeCode Stream";
            var expectedDescription = $"Fake description Stream > '{expectedProperty}'";


            // Act
            var act = val.Validate()
                .IfEmpty(property =>
                    Error.Forbidden(
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
