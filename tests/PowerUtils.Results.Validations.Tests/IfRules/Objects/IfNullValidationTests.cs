﻿using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using PowerUtils.Results.Validations.Tests.IfRules.Fakes;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Objects
{
    public class IfNullValidationTests
    {
        [Fact]
        public void NullObject_IfNull_OneError()
        {
            // Arrange
            object client = null;


            // Act
            var act = client.Validate()
                .IfNull();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == ResultErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(client)}' cannot be null"
            );
        }

        [Fact]
        public void NullList_IfNull_OneError()
        {
            // Arrange
            List<string> list = null;


            // Act
            var act = list.Validate()
                .IfNull();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(list)
                &&
                c.Code == ResultErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(list)}' cannot be null"
            );
        }

        [Fact]
        public void NullArray_IfNull_OneError()
        {
            // Arrange
            string[] array = null;


            // Act
            var act = array.Validate()
                .IfNull();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(array)
                &&
                c.Code == ResultErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(array)}' cannot be null"
            );
        }

        [Fact]
        public void NotNull_IfNull_NoErrors()
        {
            // Arrange
            var client = new object();


            // Act
            var act = client.Validate()
                .IfNull();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void NullClass_IfNull_OneError()
        {
            // Arrange
            FakeObj fakeObj = null;


            // Act
            var act = fakeObj.Validate()
                .IfNull();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(fakeObj)
                &&
                c.Code == ResultErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(fakeObj)}' cannot be null"
            );
        }

        [Fact]
        public void NotNullClass_IfNull_NoErrors()
        {
            // Arrange
            var fakeObj = new FakeObj();


            // Act
            var act = fakeObj.Validate()
                .IfNull();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ForbiddenError_IfNull_ErrorCode()
        {
            // Arrange
            FakeObj fakeObj = null;

            var expectedProperty = "fakeProp";
            var expectedCode = "fakeCode";
            var expectedDescription = $"Fake description > '{expectedProperty}'";


            // Act
            var act = fakeObj.Validate()
                .IfNull(property =>
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
