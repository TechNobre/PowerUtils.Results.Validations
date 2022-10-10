using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Collections
{
    public class IfNullValidationTests
    {
        [Fact]
        public void NullEnumerable_IfNull_OneError()
        {
            // Arrange
            IEnumerable<string> prodList = null;


            // Act
            var act = prodList.Validate()
                .IfNull();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(prodList)
                &&
                c.Code == ResultErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(prodList)}' cannot be null"
            );
        }

        [Fact]
        public void EmptyEnumerable_IfNull_NoErrors()
        {
            // Arrange
            IEnumerable<string> prodList = new List<string>();


            // Act
            var act = prodList.Validate()
                .IfNull();


            // Assert
            act.Errors.Should().HaveCount(0);
        }
    }
}
