using System;
using System.Runtime.CompilerServices;

namespace PowerUtils.Results
{
    public static class DateTimeValidations
    {
        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than. Error code 'MAX:{yyyy-MM-dd}'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="max">Max value</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfGreaterThan(
            this DateTime value,
            DateTime max,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value > max)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.CreateDateMax(max),
                    $"The '{propertyName}' is very future. The maximum is {max:yyyy-MM-dd}"
                );
            }

            return null;
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than and adds an error code 'MAX:{yyyy-MM-dd}' in error list
        /// </summary>
        public static IValidatable<DateTime> IfGreaterThan(
            this IValidatable<DateTime> validatable,
            DateTime max
        ) => validatable.Validator(property => property.Value.IfGreaterThan(max, property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than. Error code 'MAX:{yyyy-MM-dd}'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="max">Max value</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfGreaterThan(
            this DateTime? value,
            DateTime max,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            return value.Value.IfGreaterThan(max, propertyName);
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than and adds an error code 'MAX:{yyyy-MM-dd}' in error list
        /// </summary>
        public static IValidatable<DateTime?> IfGreaterThan(
            this IValidatable<DateTime?> validatable,
            DateTime max
        ) => validatable.Validator(property => property.Value.IfGreaterThan(max, property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than. Error code 'MIN:{yyyy-MM-dd}'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="min">Min value</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfLessThan(
            this DateTime value,
            DateTime min,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value < min)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.CreateDateMin(min),
                    $"The '{propertyName}' is very old. The minimum is {min:yyyy-MM-dd}"
                );
            }

            return null;
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than and adds an error code 'MAX:{yyyy-MM-dd}' in error list
        /// </summary>
        public static IValidatable<DateTime> IfLessThan(
            this IValidatable<DateTime> validatable,
            DateTime min
        ) => validatable.Validator(property => property.Value.IfLessThan(min, property.Name));

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than. Error code 'MIN:{yyyy-MM-dd}'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="min">Min value</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfLessThan(
            this DateTime? value,
            DateTime min,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            return value.Value.IfLessThan(min, propertyName);
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than and adds an error code 'MAX:{yyyy-MM-dd}' in error list
        /// </summary>
        public static IValidatable<DateTime?> IfLessThan(
            this IValidatable<DateTime?> validatable,
            DateTime min
        ) => validatable.Validator(property => property.Value.IfLessThan(min, property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> out of range. Error code 'MIN:{X}' or 'MAX:{X}'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="min">Min dateTime</param>
        /// <param name="max">Max dateTime</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfOutOfRange(
            this DateTime value,
            DateTime min,
            DateTime max,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            var validation = value.IfLessThan(min, propertyName);
            if(validation is not null)
            {
                return validation;
            }

            return value.IfGreaterThan(max, propertyName);
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> out of range and adds an error code 'MIN:{yyyy-MM-dd} or MAX:{yyyy-MM-dd}' in error list
        /// </summary>
        public static IValidatable<DateTime> IfOutOfRange(
            this IValidatable<DateTime> validatable,
            DateTime min,
            DateTime max
        ) => validatable.Validator(property => property.Value.IfOutOfRange(min, max, property.Name));

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> out of range. Error code 'MIN:{X}' or 'MAX:{X}'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="min">Min dateTime</param>
        /// <param name="max">Max dateTime</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfOutOfRange(
            this DateTime? value,
            DateTime min,
            DateTime max,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            return value.Value.IfOutOfRange(min, max, propertyName);
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> out of range and adds an error code 'MIN:{yyyy-MM-dd} or MAX:{yyyy-MM-dd}' in error list
        /// </summary>
        public static IValidatable<DateTime?> IfOutOfRange(
            this IValidatable<DateTime?> validatable,
            DateTime min,
            DateTime max
        ) => validatable.Validator(property => property.Value.IfOutOfRange(min, max, property.Name));


        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to other value. Error code 'INVALID'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="otherValue">Reference value for comparison</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfEquals(
            this DateTime? value,
            DateTime? otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        )
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
        public static IValidatable<DateTime?> IfEquals(
            this IValidatable<DateTime?> validatable,
            DateTime? otherValue
        ) => validatable.Validator(property => property.Value.IfEquals(otherValue, property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value. Error code 'INVALID'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="otherValue">Reference value for comparison</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfDifferent(
            this DateTime? value,
            DateTime? otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value != otherValue)
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
        /// Validates if <paramref name="validatable.Value"/> is different to other value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<DateTime?> IfDifferent(
            this IValidatable<DateTime?> validatable,
            DateTime? otherValue
        ) => validatable.Validator(property => property.Value.IfDifferent(otherValue, property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than utc now. Error code 'MAX:DATETIME_UTCNOW'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfGreaterThanUtcNow(
            this DateTime value,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value > DateTime.UtcNow)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.MAX_DATETIME_UTCNOW,
                    $"The '{propertyName}' is very future. The maximum is UTC NOW"
                );
            }

            return null;
        }
        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than utc now and adds an error code 'MAX:DATETIME_UTCNOW' in error list
        /// </summary>
        public static IValidatable<DateTime> IfGreaterThanUtcNow(this IValidatable<DateTime> validatable)
            => validatable.Validator(property => property.Value.IfGreaterThanUtcNow(property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than utc now. Error code 'MAX:DATETIME_UTCNOW'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfGreaterThanUtcNow(
            this DateTime? value,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            return value.Value.IfGreaterThanUtcNow(propertyName);
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than utc now and adds an error code 'MAX:DATETIME_UTCNOW' in error list
        /// </summary>
        public static IValidatable<DateTime?> IfGreaterThanUtcNow(this IValidatable<DateTime?> validatable)
            => validatable.Validator(property => property.Value.IfGreaterThanUtcNow(property.Name));

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than utc today. Error code 'MAX:DATETIME_UTCTODAY'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfGreaterThanUtcToday(
            this DateTime value,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value > DateTime.UtcNow.Date)
            {
                return Error.Validation(
                    propertyName,
                    "MAX:DATETIME_UTCTODAY",
                    $"The '{propertyName}' is very future. The maximum is UTC TODAY"
                );
            }

            return null;
        }
        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than utc today and adds an error code 'MAX:DATETIME_UTCTODAY' in error list
        /// </summary>
        public static IValidatable<DateTime> IfGreaterThanUtcToday(this IValidatable<DateTime> validatable)
            => validatable.Validator(property => property.Value.IfGreaterThanUtcToday(property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than utc today. Error code 'MAX:DATETIME_UTCTODAY'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfGreaterThanUtcToday(
            this DateTime? value,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            return value.Value.IfGreaterThanUtcToday(propertyName);
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than utc today and adds an error code 'MAX:DATETIME_UTCTODAY' in error list
        /// </summary>
        public static IValidatable<DateTime?> IfGreaterThanUtcToday(this IValidatable<DateTime?> validatable)
            => validatable.Validator(property => property.Value.IfGreaterThanUtcToday(property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than utc now. Error code 'MIN:DATETIME_UTCNOW'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfLessThanUtcNow(
            this DateTime value,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value < DateTime.UtcNow)
            {
                return Error.Validation(
                   propertyName,
                   ErrorCodes.MIN_DATETIME_UTCNOW,
                   $"The '{propertyName}' is very old. The minimum is UTC NOW"
               );
            }

            return null;
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than utc now and adds an error code 'MIN:DATETIME_UTCNOW' in error list
        /// </summary>
        public static IValidatable<DateTime> IfLessThanUtcNow(this IValidatable<DateTime> validatable)
            => validatable.Validator(property => property.Value.IfLessThanUtcNow(property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than utc now. Error code 'MIN:DATETIME_UTCNOW'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfLessThanUtcNow(
            this DateTime? value,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            return value.Value.IfLessThanUtcNow(propertyName);
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than utc now and adds an error code 'MIN:DATETIME_UTCNOW' in error list
        /// </summary>
        public static IValidatable<DateTime?> IfLessThanUtcNow(this IValidatable<DateTime?> validatable)
            => validatable.Validator(property => property.Value.IfLessThanUtcNow(property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than utc today. Error code 'MIN:DATETIME_UTCTODAY'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfLessThanUtcToday(
            this DateTime value,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value < DateTime.UtcNow.Date)
            {
                return Error.Validation(
                   propertyName,
                   "MIN:DATETIME_UTCTODAY",
                   $"The '{propertyName}' is very old. The minimum is UTC TODAY"
               );
            }

            return null;
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than utc today and adds an error code 'MIN:DATETIME_UTCTODAY' in error list
        /// </summary>
        public static IValidatable<DateTime> IfLessThanUtcToday(this IValidatable<DateTime> validatable)
            => validatable.Validator(property => property.Value.IfLessThanUtcToday(property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than utc today. Error code 'MIN:DATETIME_UTCTODAY'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfLessThanUtcToday(
            this DateTime? value,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            return value.Value.IfLessThanUtcToday(propertyName);
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than utc today and adds an error code 'MIN:DATETIME_UTCTODAY' in error list
        /// </summary>
        public static IValidatable<DateTime?> IfLessThanUtcToday(this IValidatable<DateTime?> validatable)
            => validatable.Validator(property => property.Value.IfLessThanUtcToday(property.Name));
    }
}
