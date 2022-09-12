using System;
using Xunit;
using FluentAssertions;

namespace PowerUtils.Results.Validations.Tests.IfRules.Guids
{
    public class IfEmptyValidationTests
    {
        [Fact]
        public void Empty_IfEmpty_OneError()
        {
            // Arrange
            var id = Guid.Empty;


            // Act
            var act = id.Validate()
                .IfEmpty();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(id)
                &&
                c.Code == ErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(id)}' cannot be empty"
            );
        }

        [Fact]
        public void NotEmpty_IfEmpty_NoErrors()
        {
            // Arrange
            var id = Guid.NewGuid();


            // Act
            var act = id.Validate()
                .IfEmpty();


            // Assert
            act.Errors.Should().HaveCount(0);
        }
    }
}
