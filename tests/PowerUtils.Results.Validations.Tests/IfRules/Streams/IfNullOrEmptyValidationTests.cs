using System;
using System.IO;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Streams
{
    public class IfNullOrEmptyValidationTests
    {
        [Fact]
        public void Null_IfNullOrEmpty_OneError()
        {
            // Arrange
            Stream val = null;


            // Act
            var act = val.Validate()
                .IfNullOrEmpty();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(val)
                &&
                c.Code == ErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(val)}' cannot be null or empty"
            );
        }

        [Fact]
        public void Empty_IfNullOrEmpty_OneError()
        {
            // Arrange
            Stream val = new MemoryStream(Array.Empty<byte>());


            // Act
            var act = val.Validate()
                .IfNullOrEmpty();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(val)
                &&
                c.Code == ErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(val)}' cannot be null or empty"
            );
        }

        [Fact]
        public void AnyValue_IfNullOrEmpty_NoErrors()
        {
            // Arrange
            Stream val = new MemoryStream(new byte[] { 1, 2, 3 });


            // Act
            var act = val.Validate()
                .IfNullOrEmpty();


            // Assert
            act.Errors.Should().HaveCount(0);
        }
    }
}
