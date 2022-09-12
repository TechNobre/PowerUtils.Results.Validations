using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests
{
    public class UtilsTests
    {
        [Fact]
        public void ParameterName_IfNull_AnErrorWithSpecificPropertyName()
        {
            // Arrange
            var errors = new List<IError>();
            string name = null;
            var propertyName = "FakeName";


            // Act
            name.Validate(errors, propertyName)
                .IfNull();


            // Assert
            errors.Should().HaveCount(1);

            errors.Should().Contain(c =>
                c.Property == propertyName
                &&
                c.Code == ErrorCodes.REQUIRED
                &&
                c.Description == $"The '{propertyName}' cannot be null"
            );
        }

        [Fact]
        public void MultiProperties_Validate_TwoErrors()
        {
            // Arrange
            var errors = new List<IError>();
            string firstName = null;
            string lastName = null;


            // Act
            var act1 = firstName.Validate(errors)
                .IfNull();
            var act2 = lastName.Validate(errors)
                .IfNull();


            // Assert
            errors.Should().HaveCount(2);

            errors.Should().ContainSingle(c =>
                c.Property == nameof(firstName)
                &&
                c.Code == ErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(firstName)}' cannot be null"
            );

            errors.Should().ContainSingle(c =>
                c.Property == nameof(lastName)
                &&
                c.Code == ErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(lastName)}' cannot be null"
            );

            act1.Errors.Should().BeEquivalentTo(errors);
            act2.Errors.Should().BeEquivalentTo(errors);
        }

        [Fact]
        public void WithoutErrorList_Validate_OneErrors()
        {
            // Arrange
            string address = null;


            // Act
            var act = address.Validate()
                .IfNull();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().ContainSingle(c =>
                c.Property == nameof(address)
                &&
                c.Code == ErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(address)}' cannot be null"
            );
        }

        [Fact]
        public void AnProperty_DirectValidation_ErrorCode()
        {
            // Arrange
            string address = null;


            // Act
            var act = address.IfNull();


            // Assert
            act.Property.Should().Be(nameof(address));
            act.Code.Should().Be(ErrorCodes.REQUIRED);
            act.Description.Should().Be($"The '{nameof(address)}' cannot be null");
        }

        [Fact]
        public void AnProperty_MultiValidations_ErrorCode()
        {
            // Arrange
            string address = null;


            // Act
            var act = address.Validate()
                .IfNullOrEmpty()
                .IfLongerThan(5);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().ContainSingle(c =>
                c.Property == nameof(address)
                &&
                c.Code == ErrorCodes.REQUIRED
                &&
                c.Description == $"The '{nameof(address)}' cannot be null or empty"
            );
        }


        [Fact]
        public void AnPropertyWithoutErrorList_Convert_IConvertible()
        {
            // Arrange
            var dateTime = "2022-05-12 12:15:23";


            // Act
            var act = dateTime.Validate()
                .ToDateTime();


            // Assert
            act.Errors.Should().HaveCount(0);

            act.Value.Should().Be(new DateTime(2022, 05, 12, 12, 15, 23));
        }

        [Fact]
        public void AnPropertyWithErrorList_Convert_DateTime()
        {
            // Arrange
            var errors = new List<IError>();
            var dateTime = "2022-05-12 12:15:23";


            // Act
            var act = dateTime.Validate(errors)
                .ToDateTime();


            // Assert
            act.Errors.Should().HaveCount(0);

            act.Value.Should().Be(new DateTime(2022, 05, 12, 12, 15, 23));
        }

        [Fact]
        public void InvalidValue_ConvertAndValidation_IConvertible()
        {
            // Arrange
            var dateTime = "2022-15-12 12:15:23";


            // Act
            var act = dateTime
                .Validate()
                .ToDateTime()
                .IfLessThanUtcNow();


            // Assert
            act.Errors.Should().HaveCount(2);

            act.Errors.Should().ContainSingle(c =>
                c.Property == nameof(dateTime)
                &&
                c.Code == ErrorCodes.INVALID
            );

            act.Errors.Should().ContainSingle(c =>
                c.Property == nameof(dateTime)
                &&
                c.Code == ErrorCodes.MIN_DATETIME_UTCNOW
            );
        }
    }
}
