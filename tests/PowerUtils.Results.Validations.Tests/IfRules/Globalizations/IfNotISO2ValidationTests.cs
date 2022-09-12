﻿using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Globalizations
{
    public class IfNotISO2ValidationTests
    {
        [Fact]
        public void NULL_IfNotISO2_NoErrors()
        {
            // Arrange
            string countryCode = null;


            // Act
            var act = countryCode.Validate()
                .IfNotISO2();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Empty_IfNotISO2_OneError()
        {
            // Arrange
            var countryCode = "";


            // Act
            var act = countryCode.Validate()
                .IfNotISO2();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(countryCode)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                 c.Description == $"The '{nameof(countryCode)}' is invalid country code. ISO2 formats are allowed"
            );
        }

        [Fact]
        public void Invalid_IfNotISO2_OneError()
        {
            // Arrange
            var countryCode = "xx";


            // Act
            var act = countryCode.Validate()
                .IfNotISO2();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(countryCode)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                 c.Description == $"The '{nameof(countryCode)}' is invalid country code. ISO2 formats are allowed"
            );
        }

        [Fact]
        public void Valid_IfNotISO2_NoErrors()
        {
            // Arrange
            var countryCode = "PT";


            // Act
            var act = countryCode.Validate()
                .IfNotISO2();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ValidLowerCase_IfNotISO2_NoErrors()
        {
            // Arrange
            var countryCode = "pt";


            // Act
            var act = countryCode.Validate()
                .IfNotISO2();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void ISO3_IfNotISO2_OneError()
        {
            // Arrange
            var countryCode = "ptr";


            // Act
            var act = countryCode.Validate()
                .IfNotISO2();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(countryCode)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                 c.Description == $"The '{nameof(countryCode)}' is invalid country code. ISO2 formats are allowed"
            );
        }
    }
}
