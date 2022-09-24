using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Collections
{
    public class IfCountLessThanValidationTests
    {
        [Fact]
        public void NullEnumerable_IfCountLessThan_NoErrors()
        {
            // Arrange
            IEnumerable<string> prodList = null;
            var min = 3;


            // Act
            var act = prodList.Validate()
                .IfCountLessThan(min);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void FewItems_IfCountLessThan_OneError()
        {
            // Arrange
            var prodList = new List<string> { "fake", "fake2", "moq1", "moq2" };
            var min = 6;



            // Act
            var act = prodList.Validate()
                .IfCountLessThan(min);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(prodList)
                &&
                c.Code == $"MIN:{min}"
                &&
                c.Description == $"The '{nameof(prodList)}' contains few items. The minimum is {min}"
            );
        }

        [Fact]
        public void ManyItemsInArray_IfCountLessThan_NoErrors()
        {
            // Arrange
            var prodList = new string[] { "fake", "fake2", "fake3", "fake4" };
            var min = 3;



            // Act
            var act = prodList.Validate()
                .IfCountLessThan(min);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void SomeItemsInIEnumerable_IfCountLessThan_NoErrors()
        {
            // Arrange
            var list = Enumerable.Range(0, 5);
            var min = 3;


            // Act
            var act = list.Validate()
                .IfCountLessThan(min);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ForbiddenError_IfCountLessThan_ErrorCode()
        {
            // Arrange
            var list = new string[] { "fake", "fake2", "fake3", "fake4" };
            var min = 6;

            var expectedProperty = "fakeProp less";
            var expectedCode = "fakeCode less";
            var expectedDescription = $"Fake description less > '{expectedProperty}'";


            // Act
            var act = list.Validate()
                .IfCountLessThan(
                    min,
                    property =>
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
