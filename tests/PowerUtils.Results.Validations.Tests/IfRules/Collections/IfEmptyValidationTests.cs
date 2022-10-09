using System.Collections.Generic;
using System.Linq;
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
                c.Code == Errors.Codes.REQUIRED
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

        [Fact]
        public void ForbiddenError_IfEmpty_ErrorCode()
        {
            // Arrange
            var list = new List<string>();

            var expectedProperty = "fakeProp";
            var expectedCode = "fakeCode";
            var expectedDescription = $"Fake description > '{expectedProperty}'";


            // Act
            var act = list.Validate()
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
