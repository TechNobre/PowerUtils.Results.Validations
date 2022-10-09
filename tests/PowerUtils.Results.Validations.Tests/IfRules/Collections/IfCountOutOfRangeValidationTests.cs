using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Collections
{
    public class IfCountOutOfRangeValidationTests
    {
        [Fact]
        public void NullEnumerable_IfCountOutOfRange_NoErrors()
        {
            // Arrange
            IEnumerable<string> prodList = null;
            var min = 3;
            var max = 6;


            // Act
            var act = prodList.Validate()
                .IfCountOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void FewItems_IfCountOutOfRange_NoErrors()
        {
            // Arrange
            IEnumerable<string> prodList = new string[] { "fake", "fake2" };
            var min = 3;
            var max = 6;


            // Act
            var act = prodList.Validate()
                .IfCountOutOfRange(min, max);


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
        public void EqualsMin_IfCountOutOfRange_NoErrors()
        {
            // Arrange
            IEnumerable<string> prodList = new string[] { "fake", "fake2" };
            var min = 2;
            var max = 6;


            // Act
            var act = prodList.Validate()
                .IfCountOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void EqualsMax_IfCountOutOfRange_NoErrors()
        {
            // Arrange
            IEnumerable<string> prodList = new string[] { "fake1", "fake2", "fake3", "fake4" };
            var min = 3;
            var max = 4;


            // Act
            var act = prodList.Validate()
                .IfCountOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ManyItems_IfCountOutOfRange_OneError()
        {
            // Arrange
            IEnumerable<string> prodList = new string[] { "fake", "fake2", "fake3", "fake4", "fake5" };
            var min = 3;
            var max = 4;


            // Act
            var act = prodList.Validate()
                .IfCountOutOfRange(min, max);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(prodList)
                &&
                c.Code == $"MAX:{max}"
                &&
                c.Description == $"The '{nameof(prodList)}' contains a lot of items. The maximum is {max}"
            );
        }

        [Fact]
        public void UnexpectedError_IfCountGreaterThan_ErrorCode()
        {
            // Arrange
            var list = new string[] { "fake" };
            var min = 2;
            var max = 3;

            var expectedProperty = "fakeProp";
            var expectedCode = "fakeCode";
            var expectedDescription = $"Fake description > '{expectedProperty}'";


            // Act
            var act = list.Validate()
                .IfCountOutOfRange(
                    min,
                    max,
                    property => Error.Unexpected(
                        expectedProperty,
                        expectedCode,
                        expectedDescription
                    ),
                    property => Error.Forbidden(
                        expectedProperty,
                        expectedCode,
                        expectedDescription
                    )
                );


            // Assert
            act.Errors.Should().HaveCount(1);
            act.Errors.First().Should().BeOfType<UnexpectedError>();

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
