using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Strings
{
    public class IfNullValidationTests
    {
        [Fact]
        public void Null_IfNull_OneError()
        {
            // Arrange
            var errors = new List<IError>();
            string name = null;


            // Act
            name.Validate(errors)
                .IfNull();


            // Assert
            errors.Should().HaveCount(1);

            errors.Should().OnlyContain(c =>
                c.Property == nameof(name)
                &&
                c.Code == Errors.Codes.REQUIRED
                &&
                c.Description == $"The '{nameof(name)}' cannot be null"
            );
        }

        [Fact]
        public void AnString_IfNull_NoErrors()
        {
            // Arrange
            var errors = new List<IError>();
            var name = "fake";


            // Act
            name.Validate(errors)
                .IfNull();


            // Assert
            errors.Should().HaveCount(0);
        }

        [Fact]
        public void Empty_IfNull_NoErrors()
        {
            // Arrange
            var errors = new List<IError>();
            var name = "";


            // Act
            name.Validate(errors)
                .IfNull();


            // Assert
            errors.Should().HaveCount(0);
        }
    }
}
