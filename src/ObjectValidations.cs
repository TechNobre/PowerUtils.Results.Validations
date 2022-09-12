using System.Runtime.CompilerServices;

namespace PowerUtils.Results
{
    public static class ObjectValidations
    {
        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is null with the error code 'REQUIRED'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfNull<TValue>(
            this TValue value,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value == null)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.REQUIRED,
                    $"The '{propertyName}' cannot be null"
                );
            }

            return null;
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is null and adds an error code 'REQUIRED' in error list
        /// </summary>
        public static IValidatable<TValue> IfNull<TValue>(this IValidatable<TValue> validatable)
            => validatable.Validator(property => property.Value.IfNull(property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to other value. Error code 'INVALID'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="otherValue">Reference value for comparison</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfEquals<TValue>(
            this TValue value,
            TValue otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : class
        {
            if(value == otherValue)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.INVALID,
                    $"The '{propertyName}' cannot be equal to '{otherValue}'"
                );
            }

            return null;
        }


        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is equals to other value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<TValue> IfEquals<TValue>(
            this IValidatable<TValue> validatable,
            TValue otherValue
        ) where TValue : class
            => validatable.Validator(property => property.Value.IfEquals(otherValue, property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value. Error code 'INVALID'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="otherValue">Reference value for comparison</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfDifferent<TValue>(
            this TValue value,
            TValue otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : class
        {
            if(value != otherValue)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.INVALID,
                    $"The '{propertyName}' cannot be different to '{otherValue}'"
                );
            }

            return null;
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<TValue> IfDifferent<TValue>(
            this IValidatable<TValue> validatable,
            TValue otherValue
        ) where TValue : class
            => validatable.Validator(property => property.Value.IfDifferent(otherValue, property.Name));
    }
}
