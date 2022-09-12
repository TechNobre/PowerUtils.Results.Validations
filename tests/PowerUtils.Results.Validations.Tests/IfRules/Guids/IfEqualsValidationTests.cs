using System;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Guids
{
    public class IfEqualsValidationTests
    {
        [Fact]
        public void Null_IfEquals_NoErrors()
        {
            // Arrange
            var id = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");
            Guid? otherValue = null;


            // Act
            var act = id.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void OtherEqulasNullable_IfEquals_OneError()
        {
            // Arrange
            var id = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");
            Guid? otherValue = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");


            // Act
            var act = id.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(id)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(id)}' cannot be equal to '{otherValue}'"
            );
        }



        [Fact]
        public void OtherDifferentNullable_IfEquals_NoErrors()
        {
            // Arrange
            var id = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");
            Guid? otherValue = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");


            // Act
            var act = id.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }



        [Fact]
        public void Different_IfEqualsNullable_NoErrors()
        {
            // Arrange
            Guid? id = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");
            var otherValue = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");


            // Act
            var act = id.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }


        [Fact]
        public void Equals_IfEqualsNullable_OneError()
        {
            // Arrange
            Guid? id = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");
            var otherValue = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");


            // Act
            var act = id.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(id)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(id)}' cannot be equal to '{otherValue}'"
            );
        }



        [Fact]
        public void Null_IfEqualsNullable_NoErrors()
        {
            // Arrange
            Guid? id = null;
            var otherValue = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");


            // Act
            var act = id.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }



        [Fact]
        public void Equals_IfEquals_OneError()
        {
            // Arrange
            var id = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");
            var otherValue = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");


            // Act
            var act = id.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(id)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(id)}' cannot be equal to '{otherValue}'"
            );
        }

        [Fact]
        public void Different_IfEquals_NoErrors()
        {
            // Arrange
            var id = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");
            var otherValue = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");


            // Act
            var act = id.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }


        [Fact]
        public void BothNull_IfEqualsNullable_OneError()
        {
            // Arrange
            Guid? id = null;
            Guid? otherValue = null;


            // Act
            var act = id.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(id)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(id)}' cannot be equal to '{otherValue}'"
            );
        }

        [Fact]
        public void OtherNullEquals_IfEqualsNullable_OneError()
        {
            // Arrange
            Guid? id = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");
            Guid? otherValue = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");


            // Act
            var act = id.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(id)
                &&
                c.Code == ErrorCodes.INVALID
                &&
                c.Description == $"The '{nameof(id)}' cannot be equal to '{otherValue}'"
            );
        }
        [Fact]
        public void OtherNull_IfEqualsNullable_NoErrors()
        {
            // Arrange
            Guid? id = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");
            Guid? otherValue = null;


            // Act
            var act = id.Validate()
                .IfEquals(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }
    }
}
