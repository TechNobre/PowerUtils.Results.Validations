﻿using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.ShouldRules.Human
{
    public class ShouldBeGenderValidationTests
    {
        [Fact]
        public void NULL_ShouldBeGender_NoErrors()
        {
            // Arrange
            string gender = null;


            // Act
            var act = gender.Validate()
                .ShouldBeGender();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Empty_ShouldBeGender_OneError()
        {
            // Arrange
            var gender = "";


            // Act
            var act = gender.Validate()
                .ShouldBeGender();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(gender)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(gender)}' is invalid gender. The allowed values are 'MALE' and 'FEMALE'"
            );
        }

        [Fact]
        public void Invalid_ShouldBeGender_OneError()
        {
            // Arrange
            var gender = "xx";


            // Act
            var act = gender.Validate()
                .ShouldBeGender();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(gender)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(gender)}' is invalid gender. The allowed values are 'MALE' and 'FEMALE'"
            );
        }

        [Fact]
        public void Other_ShouldBeGender_OneError()
        {
            // Arrange
            var gender = "OTHER";


            // Act
            var act = gender.Validate()
                .ShouldBeGender();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(gender)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(gender)}' is invalid gender. The allowed values are 'MALE' and 'FEMALE'"
            );
        }

        [Theory]
        [InlineData("MALE")]
        [InlineData("FEMALE")]
        public void Valid_ShouldBeGender_OneError(string gender)
        {
            // Arrange && Act
            var act = gender.Validate()
                .ShouldBeGender();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Theory]
        [InlineData("male")]
        [InlineData("female")]
        public void ValidLowerCase_ShouldBeGender_NoErrors(string gender)
        {
            // Arrange && Act
            var act = gender.Validate()
                .ShouldBeGender();


            // Assert
            act.Errors.Should().HaveCount(0);
        }
    }
}
