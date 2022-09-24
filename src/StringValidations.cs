using System;
using System.Runtime.CompilerServices;

namespace PowerUtils.Results
{
    public static class StringValidations
    {
        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is empty
        /// </summary>
        public static IError IfEmpty(
            this string value,
            Func<IProperty<string>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is "")
            {
                return onError(new Property<string>(value, propertyName));
            }

            return null;
        }


        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is empty. Error code 'REQUIRED'
        /// </summary>
        public static IError IfEmpty(
            this string value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfEmpty(
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.REQUIRED,
                $"The '{propertyName}' cannot be empty"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is empty. Error code 'REQUIRED' in error list
        /// </summary>
        public static IValidatable<string> IfEmpty(this IValidatable<string> validatable)
            => validatable.Validator(property => property.Value.IfEmpty(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is empty
        /// </summary>
        public static IValidatable<string> IfEmpty(
            this IValidatable<string> validatable,
            Func<IProperty<string>, IError> onError
        ) => validatable.Validator(property => property.Value.IfEmpty(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is null or empty
        /// </summary>
        public static IError IfNullOrEmpty(
            this string value,
            Func<IProperty<string>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(string.IsNullOrEmpty(value))
            {
                return onError(new Property<string>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is null or empty. Error code 'REQUIRED'
        /// </summary>
        public static IError IfNullOrEmpty(
            this string value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfNullOrEmpty(
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.REQUIRED,
                $"The '{propertyName}' cannot be null or empty"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is null or empty and adds an error code 'REQUIRED' in error list
        /// </summary>
        public static IValidatable<string> IfNullOrEmpty(this IValidatable<string> validatable)
            => validatable.Validator(property => property.Value.IfNullOrEmpty(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is null or empty and adds an error
        /// </summary>
        public static IValidatable<string> IfNullOrEmpty(
            this IValidatable<string> validatable,
            Func<IProperty<string>, IError> onError
        ) => validatable.Validator(property => property.Value.IfNullOrEmpty(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is null or white spaces
        /// </summary>
        public static IError IfNullOrWhiteSpace(
            this string value,
            Func<IProperty<string>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                return onError(new Property<string>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is null or white spaces. Error code 'REQUIRED'
        /// </summary>
        public static IError IfNullOrWhiteSpace(
            this string value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfNullOrWhiteSpace(
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.REQUIRED,
                $"The '{propertyName}' cannot be null or white spaces"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is null or white spaces and adds an error code 'REQUIRED' in error list
        /// </summary>
        public static IValidatable<string> IfNullOrWhiteSpace(this IValidatable<string> validatable)
            => validatable.Validator(property => property.Value.IfNullOrWhiteSpace(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is null or white spaces and adds an error
        /// </summary>
        public static IValidatable<string> IfNullOrWhiteSpace(
            this IValidatable<string> validatable,
            Func<IProperty<string>, IError> onError
        ) => validatable.Validator(property => property.Value.IfNullOrWhiteSpace(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is longer than
        /// </summary>
        public static IError IfLongerThan(
            this string value,
            int maxLength,
            Func<IProperty<string>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value?.Length > maxLength)
            {
                return onError(new Property<string>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is longer than. Error code 'MAX:{X}'
        /// </summary>
        public static IError IfLongerThan(
            this string value,
            int maxLength,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfLongerThan(
            maxLength,
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.CreateMax(maxLength),
                $"The '{propertyName}' is too long. The maximum length is {maxLength}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is longer than and adds an error code 'MAX:{X}' in error list
        /// </summary>
        public static IValidatable<string> IfLongerThan(
            this IValidatable<string> validatable,
            int maxLength
        ) => validatable.Validator(property => property.Value.IfLongerThan(maxLength, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is longer than and adds an error
        /// </summary>
        public static IValidatable<string> IfLongerThan(
            this IValidatable<string> validatable,
            int maxLength,
            Func<IProperty<string>, IError> onError
        ) => validatable.Validator(property => property.Value.IfLongerThan(maxLength, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is shorter than
        /// </summary>
        public static IError IfShorterThan(
            this string value,
            int minLength,
            Func<IProperty<string>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value?.Length < minLength)
            {
                return onError(new Property<string>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is shorter than. Error code 'MIN:{X}'
        /// </summary>
        public static IError IfShorterThan(
            this string value,
            int minLength,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfShorterThan(
            minLength,
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.CreateMin(minLength),
                $"The '{propertyName}' is too short. The minimum length is {minLength}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is shorter than and adds an error code 'MIN:{X}' in error list
        /// </summary>
        public static IValidatable<string> IfShorterThan(
            this IValidatable<string> validatable,
            int minLength
        ) => validatable.Validator(property => property.Value.IfShorterThan(minLength, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is shorter than and adds an error
        /// </summary>
        public static IValidatable<string> IfShorterThan(
            this IValidatable<string> validatable,
            int minLength,
            Func<IProperty<string>, IError> onError
        ) => validatable.Validator(property => property.Value.IfShorterThan(minLength, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> has a length equals to. Error code 'INVALID'
        /// </summary>
        public static IError IfLengthEquals(
            this string value,
            int length,
            Func<IProperty<string>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value?.Length == length)
            {
                return onError(new Property<string>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> has a length equals to. Error code 'INVALID'
        /// </summary>
        public static IError IfLengthEquals(
            this string value,
            int length,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfLengthEquals(
            length,
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.INVALID,
                $"The '{propertyName}' is of an invalid length. The length cannot be {length}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> has a length equals to and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<string> IfLengthEquals(
            this IValidatable<string> validatable,
            int length
        ) => validatable.Validator(property => property.Value.IfLengthEquals(length, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> has a length equals to and adds an error
        /// </summary>
        public static IValidatable<string> IfLengthEquals(
            this IValidatable<string> validatable,
            int length,
            Func<IProperty<string>, IError> onError
        ) => validatable.Validator(property => property.Value.IfLengthEquals(length, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> has a length different to
        /// </summary>
        public static IError IfLengthDifferent(
            this string value,
            int length,
            Func<IProperty<string>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value?.Length != length)
            {
                return onError(new Property<string>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> has a length different to. Error code 'INVALID'
        /// </summary>
        public static IError IfLengthDifferent(
            this string value,
            int length,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfLengthDifferent(
            length,
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.INVALID,
                $"The '{propertyName}' is of an invalid length. The length must be {length}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> has a length different to and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<string> IfLengthDifferent(
            this IValidatable<string> validatable,
            int length
        ) => validatable.Validator(property => property.Value.IfLengthDifferent(length, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> has a length different to and adds an error
        /// </summary>
        public static IValidatable<string> IfLengthDifferent(
            this IValidatable<string> validatable,
            int length,
            Func<IProperty<string>, IError> onError
        ) => validatable.Validator(property => property.Value.IfLengthDifferent(length, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> has a length out of range
        /// </summary>
        public static IError IfLengthOutOfRange(
            this string value,
            int minLength,
            int maxLength,
            Func<IProperty<string>, IError> onErrorMin,
            Func<IProperty<string>, IError> onErrorMax,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            if(value.Length < minLength)
            {
                return onErrorMin(new Property<string>(value, propertyName));
            }

            if(value.Length > maxLength)
            {
                return onErrorMax(new Property<string>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> has a length out of range. Error code 'MIN:{X}' or 'MAX:{X}'
        /// </summary>
        public static IError IfLengthOutOfRange(
            this string value,
            int minLength,
            int maxLength,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfLengthOutOfRange(
            minLength,
            maxLength,
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.CreateMin(minLength),
                $"The '{propertyName}' is too short. The minimum length is {minLength}"
            ),
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.CreateMax(maxLength),
                $"The '{propertyName}' is too long. The maximum length is {maxLength}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> hhas a length out of range and adds an error code 'MIN:{X}' or 'MAX:{X}' in error list
        /// </summary>
        public static IValidatable<string> IfLengthOutOfRange(
            this IValidatable<string> validatable,
            int minLength,
            int maxLength
        ) => validatable.Validator(property => property.Value.IfLengthOutOfRange(minLength, maxLength, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> hhas a length out of range and adds an error
        /// </summary>
        public static IValidatable<string> IfLengthOutOfRange(
            this IValidatable<string> validatable,
            int minLength,
            int maxLength,
            Func<IProperty<string>, IError> onErrorMin,
            Func<IProperty<string>, IError> onErrorMax
        ) => validatable.Validator(property => property.Value.IfLengthOutOfRange(minLength, maxLength, onErrorMin, onErrorMax));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to other value
        /// </summary>
        public static IError IfEquals(
            this string value,
            string otherValue,
            Func<IProperty<string>, IError> onError,
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
                return onError(new Property<string>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to other value. Error code 'INVALID'
        /// </summary>
        public static IError IfEquals(
            this string value,
            string otherValue,
            StringComparison comparisonType = StringComparison.CurrentCulture,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfEquals(
            otherValue,
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.INVALID,
                $"The '{propertyName}' cannot be equal to '{otherValue}'"
            ),
            comparisonType,
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is equals to other value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<string> IfEquals(
            this IValidatable<string> validatable,
            string otherValue,
            StringComparison comparisonType = StringComparison.CurrentCulture
        ) => validatable.Validator(property => property.Value.IfEquals(otherValue, comparisonType, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is equals to other value and adds an error
        /// </summary>
        public static IValidatable<string> IfEquals(
            this IValidatable<string> validatable,
            string otherValue,
            Func<IProperty<string>, IError> onError,
            StringComparison comparisonType = StringComparison.CurrentCulture
        ) => validatable.Validator(property => property.Value.IfEquals(otherValue, onError, comparisonType));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value
        /// </summary>
        public static IError IfDifferent(
            this string value,
            string otherValue,
            Func<IProperty<string>, IError> onError,
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
                return onError(new Property<string>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value. Error code 'INVALID'
        /// </summary>
        public static IError IfDifferent(
            this string value,
            string otherValue,
            StringComparison comparisonType = StringComparison.CurrentCulture,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfDifferent(
            otherValue,
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.INVALID,
                $"The '{propertyName}' cannot be different to '{otherValue}'"
            ),
            comparisonType,
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<string> IfDifferent(
            this IValidatable<string> validatable,
            string otherValue,
            StringComparison comparisonType = StringComparison.CurrentCulture
        ) => validatable.Validator(property => property.Value.IfDifferent(otherValue, comparisonType, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value value and adds an error
        /// </summary>
        public static IValidatable<string> IfDifferent(
            this IValidatable<string> validatable,
            string otherValue,
            Func<IProperty<string>, IError> onError,
            StringComparison comparisonType = StringComparison.CurrentCulture
        ) => validatable.Validator(property => property.Value.IfDifferent(otherValue, onError, comparisonType));
    }
}
