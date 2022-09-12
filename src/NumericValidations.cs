using System;
using System.Runtime.CompilerServices;

namespace PowerUtils.Results
{
    public static class NumericValidations
    {
        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is zero. Error code 'INVALID'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfZero<TValue>(
            this TValue value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value.CompareTo(Convert.ChangeType(0, typeof(TValue))) == 0)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.INVALID,
                    $"The '{propertyName}' cannot be equal to '0'"
                );
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is zero. Error code 'INVALID'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfZero<TValue>(
            this TValue? value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value is null)
            {
                return null;
            }

            return value.Value.IfZero(propertyName);
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is zero and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<TValue> IfZero<TValue>(this IValidatable<TValue> validatable)
            where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfZero(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is zero and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<TValue?> IfZero<TValue>(this IValidatable<TValue?> validatable)
            where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfZero(property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than. Error code 'MAX:{X}'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="max">Max value</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfGreaterThan<TValue>(
            this TValue value,
            TValue max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value.CompareTo(max) > 0)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.CreateMax(max),
                    $"The '{propertyName}' is too big. The maximum is {max}"
                );
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than. Error code 'MAX:{X}'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="max">Max value</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfGreaterThan<TValue>(
            this TValue? value,
            TValue max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value is null)
            {
                return null;
            }

            return value.Value.IfGreaterThan(max, propertyName);
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than and adds an error code 'MAX:{X}' in error list
        /// </summary>
        public static IValidatable<TValue> IfGreaterThan<TValue>(
            this IValidatable<TValue> validatable,
            TValue max
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfGreaterThan(max, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than and adds an error code 'MAX:{X}' in error list
        /// </summary>
        public static IValidatable<TValue?> IfGreaterThan<TValue>(
            this IValidatable<TValue?> validatable,
            TValue max
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfGreaterThan(max, property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than. Error code 'MIN:{X}'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="min">Min value</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfLessThan<TValue>(
            this TValue value,
            TValue min,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value.CompareTo(min) < 0)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.CreateMin(min),
                    $"The '{propertyName}' is too small. The minimum is {min}"
                );
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than. Error code 'MIN:{X}'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="min">Min value</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfLessThan<TValue>(
            this TValue? value,
            TValue min,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value is null)
            {
                return null;
            }

            return value.Value.IfLessThan(min, propertyName);
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than and adds an error code 'MIN:{X}' in error list
        /// </summary>
        public static IValidatable<TValue> IfLessThan<TValue>(
            this IValidatable<TValue> validatable,
            TValue min
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfLessThan(min, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than and adds an error code 'MIN:{X}' in error list
        /// </summary>
        public static IValidatable<TValue?> IfLessThan<TValue>(
            this IValidatable<TValue?> validatable,
            TValue min
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfLessThan(min, property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to to other value. Error code 'INVALID'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="otherValue">Reference value for comparison</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfEquals<TValue>(
            this TValue value,
            TValue otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value.CompareTo(otherValue) == 0)
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
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to to other value. Error code 'INVALID'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="otherValue">Reference value for comparison</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfEquals<TValue>(
            this TValue? value,
            TValue otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value is null)
            {
                return null;
            }

            return value.Value.IfEquals(otherValue, propertyName);
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is equals to other value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<TValue> IfEquals<TValue>(
            this IValidatable<TValue> validatable,
            TValue otherValue
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfEquals(otherValue, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is equals to other value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<TValue?> IfEquals<TValue>(
            this IValidatable<TValue?> validatable,
            TValue otherValue
        ) where TValue : struct, IComparable<TValue>, IComparable
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
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value.CompareTo(otherValue) != 0)
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
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value. Error code 'INVALID'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="otherValue">Reference value for comparison</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfDifferent<TValue>(
            this TValue? value,
            TValue otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value is null)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.INVALID,
                    $"The '{propertyName}' cannot be different to '{otherValue}'"
                );
            }

            return value.Value.IfDifferent(otherValue, propertyName);
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<TValue> IfDifferent<TValue>(
            this IValidatable<TValue> validatable,
            TValue otherValue
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfDifferent(otherValue, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<TValue?> IfDifferent<TValue>(
            this IValidatable<TValue?> validatable,
            TValue otherValue
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfDifferent(otherValue, property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> out of range. Error code 'MIN:{X}' or 'MAX:{X}'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="min">Min value</param>
        /// <param name="max">Max value</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfOutOfRange<TValue>(
            this TValue value,
            TValue min,
            TValue max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            var validation = value.IfLessThan(min, propertyName);
            if(validation is not null)
            {
                return validation;
            }

            return value.IfGreaterThan(max, propertyName);
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> out of range. Error code 'MIN:{X}' or 'MAX:{X}'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="min">Min value</param>
        /// <param name="max">Max value</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfOutOfRange<TValue>(
            this TValue? value,
            TValue min,
            TValue max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value is null)
            {
                return null;
            }

            return value.Value.IfOutOfRange(min, max, propertyName);
        }

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
        /// Validates if <paramref name="validatable.Value"/> out of range and adds an error code 'MIN:{X}' or 'MAX:{X}' in error list
        /// </summary>
        public static IValidatable<TValue?> IfOutOfRange<TValue>(
            this IValidatable<TValue?> validatable,
            TValue min,
            TValue max
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfOutOfRange(min, max, property.Name));
    }
}
