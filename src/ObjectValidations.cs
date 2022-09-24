using System;
using System.Runtime.CompilerServices;

namespace PowerUtils.Results
{
    public static class ObjectValidations
    {
        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is null
        /// </summary>
        public static IError IfNull<TValue>(
            this TValue value,
            Func<IProperty<TValue>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return onError(new Property<TValue>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is null with the error code 'REQUIRED'
        /// </summary>
        public static IError IfNull<TValue>(
            this TValue value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfNull(
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.REQUIRED,
                $"The '{propertyName}' cannot be null"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is null and adds an error code 'REQUIRED' in error list
        /// </summary>
        public static IValidatable<TValue> IfNull<TValue>(this IValidatable<TValue> validatable)
            => validatable.Validator(property => property.Value.IfNull(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is null and adds an error
        /// </summary>
        public static IValidatable<TValue> IfNull<TValue>(
            this IValidatable<TValue> validatable,
            Func<IProperty<TValue>, IError> onError
        ) => validatable.Validator(property => property.Value.IfNull(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to other value
        /// </summary>
        public static IError IfEquals<TValue>(
            this TValue value,
            TValue otherValue,
            Func<IProperty<TValue>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : class
        {
            if(value == otherValue)
            {
                return onError(new Property<TValue>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to other value. Error code 'INVALID'
        /// </summary>
        public static IError IfEquals<TValue>(
            this TValue value,
            TValue otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : class
            => value.IfEquals(
                otherValue,
                (_) => Error.Validation(
                    propertyName,
                    ErrorCodes.INVALID,
                    $"The '{propertyName}' cannot be equal to '{otherValue}'"
                ),
                propertyName
            );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is equals to other value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<TValue> IfEquals<TValue>(
            this IValidatable<TValue> validatable,
            TValue otherValue
        ) where TValue : class
            => validatable.Validator(property => property.Value.IfEquals(otherValue, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is equals to other value and adds an error
        /// </summary>
        public static IValidatable<TValue> IfEquals<TValue>(
            this IValidatable<TValue> validatable,
            TValue otherValue,
            Func<IProperty<TValue>, IError> onError
        ) where TValue : class
            => validatable.Validator(property => property.Value.IfEquals(otherValue, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value
        /// </summary>
        public static IError IfDifferent<TValue>(
            this TValue value,
            TValue otherValue,
            Func<IProperty<TValue>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : class
        {
            if(value != otherValue)
            {
                return onError(new Property<TValue>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value. Error code 'INVALID'
        /// </summary>
        public static IError IfDifferent<TValue>(
            this TValue value,
            TValue otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : class
            => value.IfDifferent(
                otherValue,
                (_) => Error.Validation(
                    propertyName,
                    ErrorCodes.INVALID,
                    $"The '{propertyName}' cannot be different to '{otherValue}'"
                ),
                propertyName
            );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<TValue> IfDifferent<TValue>(
            this IValidatable<TValue> validatable,
            TValue otherValue
        ) where TValue : class
            => validatable.Validator(property => property.Value.IfDifferent(otherValue, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value value and adds an error
        /// </summary>
        public static IValidatable<TValue> IfDifferent<TValue>(
            this IValidatable<TValue> validatable,
            TValue otherValue,
            Func<IProperty<TValue>, IError> onError
        ) where TValue : class
            => validatable.Validator(property => property.Value.IfDifferent(otherValue, onError));
    }
}
