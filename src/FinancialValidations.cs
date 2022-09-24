using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace PowerUtils.Results
{
    public static class FinancialValidations
    {
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
    }
}
