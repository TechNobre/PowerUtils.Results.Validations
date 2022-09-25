using System;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace PowerUtils.Results
{
    public static class FinancialValidations
    {
        private const int CARD_NUMBER_MIN_LENGTH = 13;
        private const int CARD_NUMBER_MAX_LENGTH = 19;

        private const string DEFAULT_CARD_EXPIRY_DATE_FORMAT = "yy/MM";


        /// <summary>
        /// Most CVVs are 3 digits, but for example American Express has 4 digits
        /// </summary>
        private static readonly Regex _cvvRegex = new(@"^\d{3,4}$", RegexOptions.Compiled);

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is not a CVV card
        /// </summary>
        public static IError ShouldBeCVV(
            this string value,
            Func<IProperty<string>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            if(!_cvvRegex.IsMatch(value))
            {
                return onError(new Property<string>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is not a CVV card. Error code 'INVALID'
        /// </summary>
        public static IError ShouldBeCVV(
            this string value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.ShouldBeCVV(
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.INVALID,
                $"The '{propertyName}' is an invalid CVV format"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is not a CVV card and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<string> ShouldBeCVV(this IValidatable<string> validatable)
            => validatable.Validator(property => property.Value.ShouldBeCVV(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is not a CVV card and adds an error
        /// </summary>
        public static IValidatable<string> ShouldBeCVV(
            this IValidatable<string> validatable,
            Func<IProperty<string>, IError> onError
        ) => validatable.Validator(property => property.Value.ShouldBeCVV(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is not a card number
        /// </summary>
        public static IError ShouldBeCardNumber(
            this string value,
            Func<IProperty<string>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            var carNumber = value
                .Replace(" ", "")
                .Replace("-", "");

            if(
                carNumber.Length < CARD_NUMBER_MIN_LENGTH
                ||
                carNumber.Length > CARD_NUMBER_MAX_LENGTH
                ||
                !_checksum(carNumber))
            {
                return onError(new Property<string>(value, propertyName));
            }

            return null;


            static bool _checksum(string carNumber)
            {
                var checksum = 0;
                var even = false;
                foreach(var digit in carNumber.ToCharArray().Reverse())
                {
                    if(!char.IsDigit(digit))
                    {
                        return false;
                    }

                    var value = (digit - '0') * (even ? 2 : 1);
                    even = !even;

                    while(value > 0)
                    {
                        checksum += value % 10;
                        value /= 10;
                    }
                }

                return (checksum % 10) == 0;
            }
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is not a card number. Error code 'INVALID'
        /// </summary>
        public static IError ShouldBeCardNumber(
            this string value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.ShouldBeCardNumber(
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.INVALID,
                $"The '{propertyName}' is an invalid card number format"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is not a CVV card and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<string> ShouldBeCardNumber(this IValidatable<string> validatable)
            => validatable.Validator(property => property.Value.ShouldBeCardNumber(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is not a card number and adds an error
        /// </summary>
        public static IValidatable<string> ShouldBeCardNumber(
            this IValidatable<string> validatable,
            Func<IProperty<string>, IError> onError
        ) => validatable.Validator(property => property.Value.ShouldBeCardNumber(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is not a valid card expiry date
        /// </summary>
        public static IError ShouldBeValidCardExpiryDate(
            this string value,
            Func<IProperty<string>, IError> onErrorExpired,
            Func<IProperty<string>, IError> onErrorInvalid,
            string format = DEFAULT_CARD_EXPIRY_DATE_FORMAT,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            if(DateTime.TryParseExact(
                value,
                format,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var expiryDate
            ))
            {
                var currentMonth = DateTime.UtcNow;
                currentMonth = new DateTime(currentMonth.Year, currentMonth.Month, 1);

                if(expiryDate < currentMonth)
                {
                    return onErrorExpired(new Property<string>(value, propertyName));
                }

                return null;
            }


            return onErrorInvalid(new Property<string>(value, propertyName));
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is not a valid card expiry date. Error code 'MIN:CURRENT_MONTH'
        /// </summary>
        public static IError ShouldBeValidCardExpiryDate(
            this string value,
            string format = DEFAULT_CARD_EXPIRY_DATE_FORMAT,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.ShouldBeValidCardExpiryDate(
            (_) => Error.Validation(
                propertyName,
                "MIN:CURRENT_MONTH",
                $"The '{propertyName}' is an expiry date"
            ),
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.INVALID,
                $"The '{propertyName}' is an invalid expiry date format"
            ),
            format,
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is not a CVV card and adds an error code 'MIN:CURRENT_MONTH' in error list
        /// </summary>
        public static IValidatable<string> ShouldBeValidCardExpiryDate(
            this IValidatable<string> validatable,
            string format = DEFAULT_CARD_EXPIRY_DATE_FORMAT
        ) => validatable.Validator(property => property.Value.ShouldBeValidCardExpiryDate(format, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is not a valid card expiry date and adds an error
        /// </summary>
        public static IValidatable<string> ShouldBeValidCardExpiryDate(
            this IValidatable<string> validatable,
            Func<IProperty<string>, IError> onErrorExpired,
            Func<IProperty<string>, IError> onErrorInvalid,
            string format = DEFAULT_CARD_EXPIRY_DATE_FORMAT
        ) => validatable.Validator(property => property.Value.ShouldBeValidCardExpiryDate(onErrorExpired, onErrorInvalid, format));
    }
}
