using System;
using System.Runtime.CompilerServices;

namespace PowerUtils.Results
{
    public static class NumericValidations
    {
        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is zero
        /// </summary>
        public static IError IfZero<TValue>(
            this TValue value,
            Func<IProperty<TValue>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value.CompareTo(Convert.ChangeType(0, typeof(TValue))) == 0)
            {
                return onError(new Property<TValue>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is zero. Error code 'INVALID'
        /// </summary>
        public static IError IfZero<TValue>(
            this TValue value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
            => value.IfZero(
            (_) => Error.Validation(
                propertyName,
                ResultErrorCodes.INVALID,
                $"The '{propertyName}' cannot be equal to '0'"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is zero and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<TValue> IfZero<TValue>(this IValidatable<TValue> validatable)
            where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfZero(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is zero and adds an error
        /// </summary>
        public static IValidatable<TValue> IfZero<TValue>(
            this IValidatable<TValue> validatable,
            Func<IProperty<TValue>, IError> onError
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfZero(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is zero
        /// </summary>
        public static IError IfZero<TValue>(
            this TValue? value,
            Func<IProperty<TValue?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value is null)
            {
                return null;
            }

            if(value.Value.CompareTo(Convert.ChangeType(0, typeof(TValue))) == 0)
            {
                return onError(new Property<TValue?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is zero. Error code 'INVALID'
        /// </summary>
        public static IError IfZero<TValue>(
            this TValue? value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
            => value.IfZero(
            (_) => Error.Validation(
                propertyName,
                ResultErrorCodes.INVALID,
                $"The '{propertyName}' cannot be equal to '0'"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is zero and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<TValue?> IfZero<TValue>(this IValidatable<TValue?> validatable)
            where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfZero(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is zero and adds an error
        /// </summary>
        public static IValidatable<TValue?> IfZero<TValue>(
            this IValidatable<TValue?> validatable,
            Func<IProperty<TValue?>, IError> onError
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfZero(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than
        /// </summary>
        public static IError IfGreaterThan<TValue>(
            this TValue value,
            TValue max,
            Func<IProperty<TValue>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value.CompareTo(max) > 0)
            {
                return onError(new Property<TValue>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than. Error code 'MAX:{X}'
        /// </summary>
        public static IError IfGreaterThan<TValue>(
            this TValue value,
            TValue max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
            => value.IfGreaterThan(
                max,
                (_) => Error.Validation(
                    propertyName,
                    ErrorCodeFactory.CreateMax(max),
                    $"The '{propertyName}' is too big. The maximum is {max}"
                ),
                propertyName
            );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than and adds an error code 'MAX:{X}' in error list
        /// </summary>
        public static IValidatable<TValue> IfGreaterThan<TValue>(
            this IValidatable<TValue> validatable,
            TValue max
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfGreaterThan(max, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than and adds an error
        /// </summary>
        public static IValidatable<TValue> IfGreaterThan<TValue>(
            this IValidatable<TValue> validatable,
            TValue max,
            Func<IProperty<TValue>, IError> onError
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfGreaterThan(max, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than
        /// </summary>
        public static IError IfGreaterThan<TValue>(
            this TValue? value,
            TValue max,
            Func<IProperty<TValue?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value is null)
            {
                return null;
            }

            if(value.Value.CompareTo(max) > 0)
            {
                return onError(new Property<TValue?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than. Error code 'MAX:{X}'
        /// </summary>
        public static IError IfGreaterThan<TValue>(
            this TValue? value,
            TValue max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
            => value.IfGreaterThan(
                max,
                (_) => Error.Validation(
                    propertyName,
                    ErrorCodeFactory.CreateMax(max),
                    $"The '{propertyName}' is too big. The maximum is {max}"
                ),
                propertyName
            );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than and adds an error code 'MAX:{X}' in error list
        /// </summary>
        public static IValidatable<TValue?> IfGreaterThan<TValue>(
            this IValidatable<TValue?> validatable,
            TValue max
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfGreaterThan(max, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than and adds an error
        /// </summary>
        public static IValidatable<TValue?> IfGreaterThan<TValue>(
            this IValidatable<TValue?> validatable,
            TValue max,
            Func<IProperty<TValue?>, IError> onError
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfGreaterThan(max, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than
        /// </summary>
        public static IError IfLessThan<TValue>(
            this TValue value,
            TValue min,
            Func<IProperty<TValue>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value.CompareTo(min) < 0)
            {
                return onError(new Property<TValue>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than. Error code 'MIN:{X}'
        /// </summary>
        public static IError IfLessThan<TValue>(
            this TValue value,
            TValue min,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
            => value.IfLessThan(
                min,
                (_) => Error.Validation(
                    propertyName,
                    ErrorCodeFactory.CreateMin(min),
                    $"The '{propertyName}' is too small. The minimum is {min}"
                ),
                propertyName
            );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than and adds an error code 'MIN:{X}' in error list
        /// </summary>
        public static IValidatable<TValue> IfLessThan<TValue>(
            this IValidatable<TValue> validatable,
            TValue min
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfLessThan(min, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than and adds an error
        /// </summary>
        public static IValidatable<TValue> IfLessThan<TValue>(
            this IValidatable<TValue> validatable,
            TValue min,
            Func<IProperty<TValue>, IError> onError
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfLessThan(min, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than
        /// </summary>
        public static IError IfLessThan<TValue>(
            this TValue? value,
            TValue min,
            Func<IProperty<TValue?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value is null)
            {
                return null;
            }

            if(value.Value.CompareTo(min) < 0)
            {
                return onError(new Property<TValue?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than. Error code 'MIN:{X}'
        /// </summary>
        public static IError IfLessThan<TValue>(
            this TValue? value,
            TValue min,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
            => value.IfLessThan(
                min,
                (_) => Error.Validation(
                    propertyName,
                    ErrorCodeFactory.CreateMin(min),
                    $"The '{propertyName}' is too small. The minimum is {min}"
                ),
                propertyName
            );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than and adds an error code 'MIN:{X}' in error list
        /// </summary>
        public static IValidatable<TValue?> IfLessThan<TValue>(
            this IValidatable<TValue?> validatable,
            TValue min
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfLessThan(min, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than and adds an error
        /// </summary>
        public static IValidatable<TValue?> IfLessThan<TValue>(
            this IValidatable<TValue?> validatable,
            TValue min,
            Func<IProperty<TValue?>, IError> onError
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfLessThan(min, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to to other value
        /// </summary>
        public static IError IfEquals<TValue>(
            this TValue value,
            TValue otherValue,
            Func<IProperty<TValue>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value.CompareTo(otherValue) == 0)
            {
                return onError(new Property<TValue>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to to other value. Error code 'INVALID'
        /// </summary>
        public static IError IfEquals<TValue>(
            this TValue value,
            TValue otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
            => value.IfEquals(
                otherValue,
                (_) => Error.Validation(
                    propertyName,
                    ResultErrorCodes.INVALID,
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
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfEquals(otherValue, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is equals to other value and adds an error
        /// </summary>
        public static IValidatable<TValue> IfEquals<TValue>(
            this IValidatable<TValue> validatable,
            TValue otherValue,
            Func<IProperty<TValue>, IError> onError
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfEquals(otherValue, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to to other value
        /// </summary>
        public static IError IfEquals<TValue>(
            this TValue? value,
            TValue otherValue,
            Func<IProperty<TValue?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value is null)
            {
                return null;
            }

            if(value.Value.CompareTo(otherValue) == 0)
            {
                return onError(new Property<TValue?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to to other value. Error code 'INVALID'
        /// </summary>
        public static IError IfEquals<TValue>(
            this TValue? value,
            TValue otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
            => value.IfEquals(
                otherValue,
                (_) => Error.Validation(
                    propertyName,
                    ResultErrorCodes.INVALID,
                    $"The '{propertyName}' cannot be equal to '{otherValue}'"
                ),
                propertyName
            );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is equals to other value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<TValue?> IfEquals<TValue>(
            this IValidatable<TValue?> validatable,
            TValue otherValue
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfEquals(otherValue, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is equals to other value and adds an error
        /// </summary>
        public static IValidatable<TValue?> IfEquals<TValue>(
            this IValidatable<TValue?> validatable,
            TValue otherValue,
            Func<IProperty<TValue?>, IError> onError
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfEquals(otherValue, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value
        /// </summary>
        public static IError IfDifferent<TValue>(
            this TValue value,
            TValue otherValue,
            Func<IProperty<TValue>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value.CompareTo(otherValue) != 0)
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
        ) where TValue : struct, IComparable<TValue>, IComparable
            => value.IfDifferent(
                otherValue,
                (_) => Error.Validation(
                    propertyName,
                    ResultErrorCodes.INVALID,
                    $"The '{propertyName}' cannot be different to '{otherValue}'"
                ),
                propertyName
            );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<TValue> IfDifferent<TValue>(
            this IValidatable<TValue> validatable,
            TValue otherValue
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfDifferent(otherValue, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value and adds an error
        /// </summary>
        public static IValidatable<TValue> IfDifferent<TValue>(
            this IValidatable<TValue> validatable,
            TValue otherValue,
            Func<IProperty<TValue>, IError> onError
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfDifferent(otherValue, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value
        /// </summary>
        public static IError IfDifferent<TValue>(
            this TValue? value,
            TValue otherValue,
            Func<IProperty<TValue?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value is null)
            {
                return onError(new Property<TValue?>(value, propertyName));
            }

            if(value.Value.CompareTo(otherValue) != 0)
            {
                return onError(new Property<TValue?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value. Error code 'INVALID'
        /// </summary>
        public static IError IfDifferent<TValue>(
            this TValue? value,
            TValue otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
            => value.IfDifferent(
                otherValue,
                (_) => Error.Validation(
                    propertyName,
                    ResultErrorCodes.INVALID,
                    $"The '{propertyName}' cannot be different to '{otherValue}'"
                ),
                propertyName
            );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<TValue?> IfDifferent<TValue>(
            this IValidatable<TValue?> validatable,
            TValue otherValue
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfDifferent(otherValue, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value and adds an error
        /// </summary>
        public static IValidatable<TValue?> IfDifferent<TValue>(
            this IValidatable<TValue?> validatable,
            TValue otherValue,
            Func<IProperty<TValue?>, IError> onError
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfDifferent(otherValue, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> out of range
        /// </summary>
        public static IError IfOutOfRange<TValue>(
            this TValue value,
            TValue min,
            TValue max,
            Func<IProperty<TValue>, IError> onErrorMin,
            Func<IProperty<TValue>, IError> onErrorMax,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value.CompareTo(min) < 0)
            {
                return onErrorMin(new Property<TValue>(value, propertyName));
            }

            if(value.CompareTo(max) > 0)
            {
                return onErrorMax(new Property<TValue>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> out of range. Error code 'MIN:{X}' or 'MAX:{X}'
        /// </summary>
        public static IError IfOutOfRange<TValue>(
            this TValue value,
            TValue min,
            TValue max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
            => value.IfOutOfRange(
                min,
                max,
                (_) => Error.Validation(
                    propertyName,
                    ErrorCodeFactory.CreateMin(min),
                    $"The '{propertyName}' is too small. The minimum is {min}"
                ),
                (_) => Error.Validation(
                    propertyName,
                    ErrorCodeFactory.CreateMax(max),
                    $"The '{propertyName}' is too big. The maximum is {max}"
                ),
                propertyName
            );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> out of range and adds an error code 'MIN:{X}' or 'MAX:{X}' in error list
        /// </summary>
        public static IValidatable<TValue> IfOutOfRange<TValue>(
            this IValidatable<TValue> validatable,
            TValue min,
            TValue max
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfOutOfRange(min, max, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> out of range and adds an error
        /// </summary>
        public static IValidatable<TValue> IfOutOfRange<TValue>(
            this IValidatable<TValue> validatable,
            TValue min,
            TValue max,
            Func<IProperty<TValue>, IError> onErrorMin,
            Func<IProperty<TValue>, IError> onErrorMax
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfOutOfRange(min, max, onErrorMin, onErrorMax));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> out of range
        /// </summary>
        public static IError IfOutOfRange<TValue>(
            this TValue? value,
            TValue min,
            TValue max,
            Func<IProperty<TValue?>, IError> onErrorMin,
            Func<IProperty<TValue?>, IError> onErrorMax,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value is null)
            {
                return null;
            }

            if(value.Value.CompareTo(min) < 0)
            {
                return onErrorMin(new Property<TValue?>(value, propertyName));
            }

            if(value.Value.CompareTo(max) > 0)
            {
                return onErrorMax(new Property<TValue?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> out of range. Error code 'MIN:{X}' or 'MAX:{X}'
        /// </summary>
        public static IError IfOutOfRange<TValue>(
            this TValue? value,
            TValue min,
            TValue max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
            => value.IfOutOfRange(
                min,
                max,
                (_) => Error.Validation(
                    propertyName,
                    ErrorCodeFactory.CreateMin(min),
                    $"The '{propertyName}' is too small. The minimum is {min}"
                ),
                (_) => Error.Validation(
                    propertyName,
                    ErrorCodeFactory.CreateMax(max),
                    $"The '{propertyName}' is too big. The maximum is {max}"
                ),
                propertyName
            );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> out of range and adds an error code 'MIN:{X}' or 'MAX:{X}' in error list
        /// </summary>
        public static IValidatable<TValue?> IfOutOfRange<TValue>(
            this IValidatable<TValue?> validatable,
            TValue min,
            TValue max
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfOutOfRange(min, max, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> out of range and adds an error
        /// </summary>
        public static IValidatable<TValue?> IfOutOfRange<TValue>(
            this IValidatable<TValue?> validatable,
            TValue min,
            TValue max,
            Func<IProperty<TValue?>, IError> onErrorMin,
            Func<IProperty<TValue?>, IError> onErrorMax
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfOutOfRange(min, max, onErrorMin, onErrorMax));
    }
}
