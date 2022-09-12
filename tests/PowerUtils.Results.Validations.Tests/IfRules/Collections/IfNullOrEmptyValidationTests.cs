using System;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Collections
{
    public class IfNullOrEmptyValidationTests
    {
        [Fact]
        public void NullArray_IfNullOrEmpty_OneError()
        {
            // Arrange
            string[] prodList = null;


            // Act
            var act = prodList.Validate()
                .IfNullOrEmpty();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(prodList)
                &&
                c.Code == ErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(prodList)}' cannot be null or empty"
            );
        }

        [Fact]
        public void EmptyArray_IfNullOrEmpty_OneError()
        {
            // Arrange
            var prodList = Array.Empty<string>();


            // Act
            var act = prodList.Validate()
                .IfNullOrEmpty();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(prodList)
                &&
                c.Code == ErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(prodList)}' cannot be null or empty"
            );
        }

        [Fact]
        public void WithItemsArray_IfNullOrEmpty_NoErrors()
        {
            // Arrange
            var prodList = new string[] { "fake", "fake2" };


            // Act
            var act = prodList.Validate()
                .IfNullOrEmpty();


            // Assert
            act.Errors.Should().HaveCount(0);
        }
    }
}
