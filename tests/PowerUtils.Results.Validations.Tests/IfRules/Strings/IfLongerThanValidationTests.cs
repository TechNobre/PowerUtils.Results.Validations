﻿using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Strings
{
    public class IfLongerThanValidationTests
    {
        [Fact]
        public void Null_IfLongerThan_NoErrors()
        {
            // Arrange
            string client = null;


            // Act
            var act = client.Validate()
                .IfLongerThan(5);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void BigText_IfLongerThan_OneError()
        {
            // Arrange
            var client = "Fake fake fake";
            var max = 5;



            // Act
            var act = client.Validate()
                .IfLongerThan(max);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == $"MAX:{max}"
                &&
                c.Description == $"The '{nameof(client)}' is too long. The maximum length is {max}"
            );
        }

        [Fact]
        public void ShortText_IfLongerThan_NoErrors()
        {
            // Arrange
            var client = "fake";
            var max = 5;



            // Act
            var act = client.Validate()
                .IfLongerThan(max);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void WithSpace_IfLongerThan_OneError()
        {
            // Arrange
            var client = "        ";
            var max = 5;


            // Act
            var act = client.Validate()
                .IfLongerThan(max);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(client)
                &&
                c.Code == $"MAX:{max}"
                &&
                c.Description == $"The '{nameof(client)}' is too long. The maximum length is {max}"
            );
        }
    }
}
