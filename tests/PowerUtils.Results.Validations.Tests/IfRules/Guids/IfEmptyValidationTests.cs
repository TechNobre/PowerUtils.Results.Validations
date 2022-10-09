using System;
using System.Linq;
using FluentAssertions;
using Xunit;

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
                c.Code == Errors.Codes.REQUIRED
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

        [Fact]
        public void ForbiddenError_IfEmpty_ErrorCode()
        {
            // Arrange
            var guid = Guid.Empty;

            var expectedProperty = "fakeProp";
            var expectedCode = "fakeCode";
            var expectedDescription = $"Fake description > '{expectedProperty}'";


            // Act
            var act = guid.Validate()
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
