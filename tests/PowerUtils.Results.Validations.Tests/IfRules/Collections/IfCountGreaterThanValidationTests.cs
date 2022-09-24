using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Collections
{
    public class IfCountGreaterThanValidationTests
    {
        [Fact]
        public void NullEnumerable_IfCountGreaterThan_NoErrors()
        {
            // Arrange
            IEnumerable<string> prodList = null;
            var max = 3;


            // Act
            var act = prodList.Validate()
                .IfCountGreaterThan(max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void FewItems_IfCountGreaterThan_NoErrors()
        {
            // Arrange
            IEnumerable<string> prodList = new string[] { "fake", "fake2" };
            var max = 3;


            // Act
            var act = prodList.Validate()
                .IfCountGreaterThan(max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ManyItems_IfCountGreaterThan_OneError()
        {
            // Arrange
            IEnumerable<string> prodList = new string[] { "fake", "fake2", "fake3", "fake4" };
            var max = 3;


            // Act
            var act = prodList.Validate()
                .IfCountGreaterThan(max);


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
        public void ForbiddenError_IfCountGreaterThan_ErrorCode()
        {
            // Arrange
            var list = new string[] { "fake", "fake2", "fake3", "fake4" };
            var max = 3;

            var expectedProperty = "fakeProp greater";
            var expectedCode = "fakeCode greater";
            var expectedDescription = $"Fake description greater > '{expectedProperty}'";


            // Act
            var act = list.Validate()
                .IfCountGreaterThan(
                    max,
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
