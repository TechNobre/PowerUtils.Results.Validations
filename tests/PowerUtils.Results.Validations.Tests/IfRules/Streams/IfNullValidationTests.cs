using System;
using System.IO;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Streams
{
    public class IfNullValidationTests
    {
        [Fact]
        public void Null_IfNull_OneError()
        {
            // Arrange
            Stream val = null;


            // Act
            var act = val.Validate()
                .IfNull();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(val)
                &&
                c.Code == Errors.Codes.REQUIRED
                &&
                c.Description == $"The '{nameof(val)}' cannot be null"
            );
        }

        [Fact]
        public void Empty_IfNull_NoErrors()
        {
            // Arrange
            Stream val = new MemoryStream(Array.Empty<byte>());


            // Act
            var act = val.Validate()
                .IfNull();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void AnyValue_IfNull_NoErrors()
        {
            // Arrange
            Stream val = new MemoryStream(new byte[] { 1, 2, 3 });


            // Act
            var act = val.Validate()
                .IfNull();


            // Assert
            act.Errors.Should().HaveCount(0);
        }
    }
}
