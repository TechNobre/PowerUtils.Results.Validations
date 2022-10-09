using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.IfRules.Guids
{
    public class IfDifferentValidationTests
    {
        [Fact]
        public void Null_IfDifferent_OneError()
        {
            // Arrange
            var id = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");
            Guid? otherValue = null;


            // Act
            var act = id.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(id)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(id)}' cannot be different to '{otherValue}'"
            );
        }

        [Fact]
        public void OtherNullableEquals_IfDifferent_NoErrors()
        {
            // Arrange
            var id = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");
            Guid? otherValue = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");


            // Act
            var act = id.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }


        [Fact]
        public void OtherNullableDifferent_IfDifferent_OneError()
        {
            // Arrange
            var id = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");
            Guid? otherValue = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");


            // Act
            var act = id.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(id)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(id)}' cannot be different to '{otherValue}'"
            );
        }



        [Fact]
        public void Equals_IfDifferent_NoErrors()
        {
            // Arrange
            var id = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");
            var otherValue = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");


            // Act
            var act = id.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void Different_IfDifferent_OneError()
        {
            // Arrange
            var id = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");
            var otherValue = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");


            // Act
            var act = id.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(id)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(id)}' cannot be different to '{otherValue}'"
            );
        }



        [Fact]
        public void Null_IfDifferentNullable_OneError()
        {
            // Arrange
            Guid? id = null;
            var otherValue = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");


            // Act
            var act = id.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(id)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(id)}' cannot be different to '{otherValue}'"
            );
        }

        [Fact]
        public void Different_IfDifferentNullable_OneError()
        {
            // Arrange
            Guid? id = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");
            var otherValue = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");


            // Act
            var act = id.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(id)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(id)}' cannot be different to '{otherValue}'"
            );
        }

        [Fact]
        public void Equals_IfDifferentNullable_NoErrors()
        {
            // Arrange
            Guid? id = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");
            var otherValue = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");


            // Act
            var act = id.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void BothEmpty_IfDifferentNullable_NoErrors()
        {
            // Arrange
            Guid? id = Guid.Empty;
            var otherValue = Guid.Empty;


            // Act
            var act = id.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }



        [Fact]
        public void BothNull_IfDifferentNullable_NoErrors()
        {
            // Arrange
            Guid? id = null;
            Guid? otherValue = null;


            // Act
            var act = id.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void OtherNullableEquals_IfDifferentNullable_NoErrors()
        {
            // Arrange
            Guid? id = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");
            Guid? otherValue = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");


            // Act
            var act = id.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void OtherNullableDifferent_IfDifferentNullable_OneError()
        {
            // Arrange
            Guid? id = Guid.Parse("ec243094-2d85-41a5-bd15-ce8f3af96b96");
            Guid? otherValue = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");


            // Act
            var act = id.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(id)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(id)}' cannot be different to '{otherValue}'"
            );
        }

        [Fact]
        public void OtherNull_IfDifferentNullable_OneError()
        {
            // Arrange
            Guid? id = null;
            Guid? otherValue = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");


            // Act
            var act = id.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(id)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(id)}' cannot be different to '{otherValue}'"
            );
        }

        [Fact]
        public void ValueNullOtherNullable_IfDifferentNullable_OneError()
        {
            // Arrange
            Guid? id = Guid.Parse("dd348c71-3115-493f-873c-03bd4ccfae02");
            Guid? otherValue = null;


            // Act
            var act = id.Validate()
                .IfDifferent(otherValue);


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(id)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(id)}' cannot be different to '{otherValue}'"
            );
        }

        [Fact]
        public void ConflictError_IfDifferent_ErrorCode()
        {
            // Arrange
            var value = Guid.NewGuid();
            var otherValue = Guid.NewGuid();

            var expectedProperty = "fake Prop diff";
            var expectedCode = "fake Code diff";
            var expectedDescription = $"Fake desc diff > '{expectedProperty}'";


            // Act
            var act = value.Validate()
                .IfDifferent(
                    otherValue,
                    property => Error.Conflict(
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

        [Fact]
        public void ForbiddenError_IfDifferentNullableOtherNullable_ErrorCode()
        {
            // Arrange
            Guid? value = Guid.NewGuid();
            Guid? otherValue = Guid.NewGuid();

            var expectedProperty = "fake Prop diff";
            var expectedCode = "fake Code diff";
            var expectedDescription = $"Fake desc diff > '{expectedProperty}'";


            // Act
            var act = value.Validate()
                .IfDifferent(
                    otherValue,
                    property => Error.Forbidden(
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

        [Fact]
        public void ForbiddenError_IfDifferentNullable_ErrorCode()
        {
            // Arrange
            var value = Guid.NewGuid();
            Guid? otherValue = Guid.NewGuid();

            var expectedProperty = "fake Prop diff";
            var expectedCode = "fake Code diff";
            var expectedDescription = $"Fake desc diff > '{expectedProperty}'";


            // Act
            var act = value.Validate()
                .IfDifferent(
                    otherValue,
                    property => Error.Forbidden(
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
