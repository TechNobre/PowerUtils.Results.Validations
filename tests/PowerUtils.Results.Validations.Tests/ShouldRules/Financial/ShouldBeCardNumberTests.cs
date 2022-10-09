using System.Linq;
using FluentAssertions;
using Xunit;

namespace PowerUtils.Results.Validations.Tests.ShouldRules.Financial
{
    public class ShouldBeCardNumberTests
    {
        [Fact]
        public void NULL_ShouldBeCardNumber_NoErrors()
        {
            // Arrange
            string number = null;


            // Act
            var act = number.Validate()
                .ShouldBeCardNumber();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData("das")]
        [InlineData("4242f4242 4242 4242")]
        [InlineData("4242_4242_4242_4242")]
        [InlineData("4242 4242 4242 4243")]
        [InlineData("4")]
        [InlineData("0")]
        [InlineData("44")]
        [InlineData("44534534")]
        [InlineData("4000007240000008")]
        [InlineData("445345344000007240000008")]
        [InlineData("40000000000a9")]
        public void Invalid_ShouldBeCardNumber_OneError(string cardNumber)
        {
            // Arrange && Act
            var act = cardNumber.Validate()
                .ShouldBeCardNumber();


            // Assert
            act.Errors.Should().HaveCount(1);

            act.Errors.Should().OnlyContain(c =>
                c.Property == nameof(cardNumber)
                &&
                c.Code == Errors.Codes.INVALID
                &&
                c.Description == $"The '{nameof(cardNumber)}' is an invalid card number format"
            );
        }

        [Theory]
        [InlineData("4242 4242 4242 4242")] // Visa (stripe)
        [InlineData("4242424242424242")] // (stripe)
        [InlineData("4242-4242-4242-4242")]
        [InlineData("4000056655665556")] // Visa (debit) (stripe)
        [InlineData("5555555555554444")] // Mastercard (stripe)
        [InlineData("2223003122003222")] // Mastercard (2-series) (stripe)
        [InlineData("5200828282828210")] // Mastercard (debit) (stripe)
        [InlineData("5105105105105100")] // Mastercard (prepaid) (stripe)
        [InlineData("378282246310005")] // American Express (stripe)
        [InlineData("371449635398431")] // American Express (stripe)
        [InlineData("6011111111111117")] // Discover (stripe)
        [InlineData("6011000990139424")] // Discover (stripe)
        [InlineData("6011981111111113")] // Discover (debit) (stripe)
        [InlineData("3056930009020004")] // Diners Club (stripe)
        [InlineData("36227206271667")] // Diners Club (14-digit card) (stripe)
        [InlineData("3566002020360505")] // JCB (stripe)
        [InlineData("6200000000000005")] // UnionPay (stripe)
        [InlineData("4000002500001001")] // Cartes Bancaires/Visa (stripe)
        [InlineData("5555552500001001")] // Cartes Bancaires/Mastercard (stripe)
        [InlineData("4000000760000002")] // Brazil (BR) - Visa (stripe)
        [InlineData("4000001240000000")] // Canada (CA) - Visa (stripe)
        [InlineData("4000004840008001")] // Mexico (MX) - Visa (stripe)
        [InlineData("4000006200000007")] // Portugal (PT) - Visa (stripe)
        [InlineData("4000007240000007")] // Spain (ES) - Visa (stripe)
        [InlineData("4000000000006")] // 13 Digits
        [InlineData("4000000000000000006")] // 19 Digits
        [InlineData("4624929915080855")]
        [InlineData("4000000000014")]
        [InlineData("3080000000017")]
        public void Valid_ShouldBeCardNumber_OneError(string cardNumber)
        {
            // Arrange && Act
            var act = cardNumber.Validate()
                .ShouldBeCardNumber();


            // Assert
            act.Errors.Should().HaveCount(0);
        }

        [Fact]
        public void UnauthorizedError_ShouldBeCardNumber_ErrorCode()
        {
            // Arrange
            var number = "4564 456 465 d";

            var expectedProperty = "fakeProp card";
            var expectedCode = "fakeCode card";
            var expectedDescription = $"Fake description card > '{expectedProperty}'";


            // Act
            var act = number.Validate()
                .ShouldBeCardNumber(
                    property => Error.Unauthorized(
                        expectedProperty,
                        expectedCode,
                        expectedDescription
                    )
                );


            // Assert
            act.Errors.Should().HaveCount(1);
            act.Errors.First().Should().BeOfType<UnauthorizedError>();

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
