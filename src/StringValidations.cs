using System;
using System.Runtime.CompilerServices;

namespace PowerUtils.Results
{
    public static class StringValidations
    {
        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is empty. Error code 'REQUIRED'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfEmpty(
            this string value,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value == "")
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.REQUIRED,
                    $"The '{propertyName}' cannot be empty"
                );
            }

            return null;
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is empty. Error code 'REQUIRED' in error list
        /// </summary>
        public static IValidatable<string> IfEmpty(this IValidatable<string> validatable)
            => validatable.Validator(property => property.Value.IfEmpty(property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is null or empty. Error code 'REQUIRED'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfNullOrEmpty(
            this string value,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(string.IsNullOrEmpty(value))
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.REQUIRED,
                    $"The '{propertyName}' cannot be null or empty"
                );
            }

            return null;
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is null or empty and adds an error code 'REQUIRED' in error list
        /// </summary>
        public static IValidatable<string> IfNullOrEmpty(this IValidatable<string> validatable)
            => validatable.Validator(property => property.Value.IfNullOrEmpty(property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is null or white spaces. Error code 'REQUIRED'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfNullOrWhiteSpace(
            this string value,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.REQUIRED,
                    $"The '{propertyName}' cannot be null or white spaces"
                );
            }

            return null;
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is null or white spaces and adds an error code 'REQUIRED' in error list
        /// </summary>
        public static IValidatable<string> IfNullOrWhiteSpace(this IValidatable<string> validatable)
            => validatable.Validator(property => property.Value.IfNullOrWhiteSpace(property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is longer than. Error code 'MAX:{X}'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="maxLength">Max length</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfLongerThan(
            this string value,
            int maxLength,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value?.Length > maxLength)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.CreateMax(maxLength),
                    $"The '{propertyName}' is too long. The maximum length is {maxLength}"
                );
            }

            return null;
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is longer than and adds an error code 'MAX:{X}' in error list
        /// </summary>
        public static IValidatable<string> IfLongerThan(
            this IValidatable<string> validatable,
            int maxLength
        ) => validatable.Validator(property => property.Value.IfLongerThan(maxLength, property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is shorter than. Error code 'MIN:{X}'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="minLength">Min length</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfShorterThan(
            this string value,
            int minLength,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value?.Length < minLength)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.CreateMin(minLength),
                    $"The '{propertyName}' is too short. The minimum length is {minLength}"
                );
            }

            return null;
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is shorter than and adds an error code 'MIN:{X}' in error list
        /// </summary>
        public static IValidatable<string> IfShorterThan(
            this IValidatable<string> validatable,
            int minLength
        ) => validatable.Validator(property => property.Value.IfShorterThan(minLength, property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> has a length equals to. Error code 'INVALID'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="length">Invalid length</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfLengthEquals(
            this string value,
            int length,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value?.Length == length)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.INVALID,
                    $"The '{propertyName}' is of an invalid length. The length cannot be {length}"
                );
            }

            return null;
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> has a length equals to and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<string> IfLengthEquals(
            this IValidatable<string> validatable,
            int length
        ) => validatable.Validator(property => property.Value.IfLengthEquals(length, property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> has a length different to. Error code 'INVALID'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="length">Valid length</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfLengthDifferent(
            this string value,
            int length,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value?.Length != length)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.INVALID,
                    $"The '{propertyName}' is of an invalid length. The length must be {length}"
                );
            }

            return null;
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> has a length different to and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<string> IfLengthDifferent(
            this IValidatable<string> validatable,
            int length
        ) => validatable.Validator(property => property.Value.IfLengthDifferent(length, property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> has a length out of range. Error code 'MIN:{X}' or 'MAX:{X}'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="minLength">Min length</param>
        /// <param name="maxLength">Max length</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfLengthOutOfRange(
            this string value,
            int minLength,
            int maxLength,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value == null)
            {
                return null;
            }

            if(value.Length < minLength)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.CreateMin(minLength),
                    $"The '{propertyName}' is too short. The minimum length is {minLength}"
                );
            }

            if(value.Length > maxLength)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.CreateMax(maxLength),
                    $"The '{propertyName}' is too long. The maximum length is {maxLength}"
                );
            }

            return null;
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> hhas a length out of range and adds an error code 'MIN:{X}' or 'MAX:{X}' in error list
        /// </summary>
        public static IValidatable<string> IfLengthOutOfRange(
            this IValidatable<string> validatable,
            int minLength,
            int maxLength
        ) => validatable.Validator(property => property.Value.IfLengthOutOfRange(minLength, maxLength, property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to other value. Error code 'INVALID'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="otherValue">Reference value for comparison</param>
        /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared [Default: 'CurrentCulture']</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfEquals(
            this string value,
            string otherValue,
            StringComparison comparisonType = StringComparison.CurrentCulture,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(
                (value is null && otherValue is null)
                ||
                (value is not null && value.Equals(otherValue, comparisonType))
            )
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
        public static IValidatable<string> IfEquals(
            this IValidatable<string> validatable,
            string otherValue,
            StringComparison comparisonType = StringComparison.CurrentCulture
        ) => validatable.Validator(property => property.Value.IfEquals(otherValue, comparisonType, property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value. Error code 'INVALID'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="otherValue">Reference value for comparison</param>
        /// <param name="comparisonType">One of the enumeration values that specifies how the strings will be compared [Default: 'CurrentCulture']</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfDifferent(
            this string value,
            string otherValue,
            StringComparison comparisonType = StringComparison.CurrentCulture,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(
                (value is not null && otherValue is null)
                ||
                (value is null && otherValue is not null)
                ||
                (value is not null && !value.Equals(otherValue, comparisonType)))
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
        public static IValidatable<string> IfDifferent(
            this IValidatable<string> validatable,
            string otherValue,
            StringComparison comparisonType = StringComparison.CurrentCulture
        ) => validatable.Validator(property => property.Value.IfDifferent(otherValue, comparisonType, property.Name));
    }
}
