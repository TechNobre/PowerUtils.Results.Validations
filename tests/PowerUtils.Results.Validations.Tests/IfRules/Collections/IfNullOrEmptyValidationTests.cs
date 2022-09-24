using System;
using System.Collections.Generic;
using System.Linq;
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

        [Fact]
        public void ConflictError_IfNullOrEmpty_ErrorCode()
        {
            // Arrange
            List<string> list = null;

            var expectedProperty = "fakeProp conf";
            var expectedCode = "fakeCode conf";
            var expectedDescription = $"Fake description conf > '{expectedProperty}'";


            // Act
            var act = list.Validate()
                .IfNullOrEmpty(property =>
                    Error.Conflict(
                        expectedProperty,
                        expectedCode,
                        expectedDescription
                    )
                );


            // Assert
            act.Errors.Should().HaveCount(1);
            act.Errors.First().Should().BeOfType<ConflictError>();

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
