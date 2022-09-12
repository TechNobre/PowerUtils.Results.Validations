using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Collections
{
    public class IfEmptyValidationTests
    {
        [Fact]
        public void NullCollection_IfEmpty_NoErrors()
        {
            // Arrange
            ICollection<string> prodList = null;


            // Act
            var act = prodList.Validate()
                .IfEmpty();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void EmptyCollection_IfEmpty_OneError()
        {
            // Arrange
            ICollection<string> prodList = new List<string>();


            // Act
            var act = prodList.Validate()
                .IfEmpty();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(prodList)
                &&
                c.Code == ErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(prodList)}' cannot be empty"
            );
        }

        [Fact]
        public void WithItemsCollection_IfEmpty_NoErrors()
        {
            // Arrange
            ICollection<string> prodList = new List<string> { "fake", "fake2" };


            // Act
            var act = prodList.Validate()
                .IfEmpty();


            // Assert
            act.Errors.Should().HaveCount(0);
        }
    }
}
