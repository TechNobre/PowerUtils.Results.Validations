using System;
using System.Runtime.CompilerServices;

namespace PowerUtils.Results
{
    public static class DateTimeValidations
    {
        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than
        /// </summary>
        public static IError IfGreaterThan(
            this DateTime value,
            DateTime max,
            Func<IProperty<DateTime>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value > max)
            {
                return onError(new Property<DateTime>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than. Error code 'MAX:{yyyy-MM-dd}'
        /// </summary>
        public static IError IfGreaterThan(
            this DateTime value,
            DateTime max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfGreaterThan(
            max,
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.CreateDateMax(max),
                $"The '{propertyName}' is very future. The maximum is {max:yyyy-MM-dd}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than and adds an error code 'MAX:{yyyy-MM-dd}' in error list
        /// </summary>
        public static IValidatable<DateTime> IfGreaterThan(
            this IValidatable<DateTime> validatable,
            DateTime max
        ) => validatable.Validator(property => property.Value.IfGreaterThan(max, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than and adds an error
        /// </summary>
        public static IValidatable<DateTime> IfGreaterThan(
            this IValidatable<DateTime> validatable,
            DateTime max,
            Func<IProperty<DateTime>, IError> onError
        ) => validatable.Validator(property => property.Value.IfGreaterThan(max, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than
        /// </summary>
        public static IError IfGreaterThan(
            this DateTime? value,
            DateTime max,
            Func<IProperty<DateTime?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is not null && value.Value > max)
            {
                return onError(new Property<DateTime?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than. Error code 'MAX:{yyyy-MM-dd}'
        /// </summary>
        public static IError IfGreaterThan(
            this DateTime? value,
            DateTime max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfGreaterThan(
            max,
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.CreateDateMax(max),
                $"The '{propertyName}' is very future. The maximum is {max:yyyy-MM-dd}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than and adds an error code 'MAX:{yyyy-MM-dd}' in error list
        /// </summary>
        public static IValidatable<DateTime?> IfGreaterThan(
            this IValidatable<DateTime?> validatable,
            DateTime max
        ) => validatable.Validator(property => property.Value.IfGreaterThan(max, property.Name));


        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than and adds an error
        /// </summary>
        public static IValidatable<DateTime?> IfGreaterThan(
            this IValidatable<DateTime?> validatable,
            DateTime max,
            Func<IProperty<DateTime?>, IError> onError
        ) => validatable.Validator(property => property.Value.IfGreaterThan(max, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than
        /// </summary>
        public static IError IfLessThan(
            this DateTime value,
            DateTime min,
            Func<IProperty<DateTime>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value < min)
            {
                return onError(new Property<DateTime>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than. Error code 'MIN:{yyyy-MM-dd}'
        /// </summary>
        public static IError IfLessThan(
            this DateTime value,
            DateTime min,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfLessThan(
            min,
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.CreateDateMin(min),
                $"The '{propertyName}' is very old. The minimum is {min:yyyy-MM-dd}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than and adds an error code 'MAX:{yyyy-MM-dd}' in error list
        /// </summary>
        public static IValidatable<DateTime> IfLessThan(
            this IValidatable<DateTime> validatable,
            DateTime min
        ) => validatable.Validator(property => property.Value.IfLessThan(min, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than and adds an error
        /// </summary>
        public static IValidatable<DateTime> IfLessThan(
            this IValidatable<DateTime> validatable,
            DateTime min,
            Func<IProperty<DateTime>, IError> onError
        ) => validatable.Validator(property => property.Value.IfLessThan(min, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than
        /// </summary>
        public static IError IfLessThan(
            this DateTime? value,
            DateTime min,
            Func<IProperty<DateTime?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is not null && value.Value < min)
            {
                return onError(new Property<DateTime?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than. Error code 'MIN:{yyyy-MM-dd}'
        /// </summary>
        public static IError IfLessThan(
            this DateTime? value,
            DateTime min,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfLessThan(
            min,
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.CreateDateMin(min),
                $"The '{propertyName}' is very old. The minimum is {min:yyyy-MM-dd}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than and adds an error code 'MAX:{yyyy-MM-dd}' in error list
        /// </summary>
        public static IValidatable<DateTime?> IfLessThan(
            this IValidatable<DateTime?> validatable,
            DateTime min
        ) => validatable.Validator(property => property.Value.IfLessThan(min, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than and adds an error
        /// </summary>
        public static IValidatable<DateTime?> IfLessThan(
            this IValidatable<DateTime?> validatable,
            DateTime min,
            Func<IProperty<DateTime?>, IError> onError
        ) => validatable.Validator(property => property.Value.IfLessThan(min, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> out of range
        /// </summary>
        public static IError IfOutOfRange(
            this DateTime value,
            DateTime min,
            DateTime max,
            Func<IProperty<DateTime>, IError> onErrorMin,
            Func<IProperty<DateTime>, IError> onErrorMax,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value < min)
            {
                return onErrorMin(new Property<DateTime>(value, propertyName));
            }

            if(value > max)
            {
                return onErrorMax(new Property<DateTime>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> out of range. Error code 'MIN:{X}' or 'MAX:{X}'
        /// </summary>
        public static IError IfOutOfRange(
            this DateTime value,
            DateTime min,
            DateTime max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfOutOfRange(
            min,
            max,
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.CreateDateMin(min),
                $"The '{propertyName}' is very old. The minimum is {min:yyyy-MM-dd}"
            ),
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.CreateDateMax(max),
                $"The '{propertyName}' is very future. The maximum is {max:yyyy-MM-dd}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> out of range and adds an error code 'MIN:{yyyy-MM-dd} or MAX:{yyyy-MM-dd}' in error list
        /// </summary>
        public static IValidatable<DateTime> IfOutOfRange(
            this IValidatable<DateTime> validatable,
            DateTime min,
            DateTime max
        ) => validatable.Validator(property => property.Value.IfOutOfRange(min, max, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> out of range and adds an error
        /// </summary>
        public static IValidatable<DateTime> IfOutOfRange(
            this IValidatable<DateTime> validatable,
            DateTime min,
            DateTime max,
            Func<IProperty<DateTime>, IError> onErrorMin,
            Func<IProperty<DateTime>, IError> onErrorMax
        ) => validatable.Validator(property => property.Value.IfOutOfRange(min, max, onErrorMin, onErrorMax));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> out of range
        /// </summary>
        public static IError IfOutOfRange(
            this DateTime? value,
            DateTime min,
            DateTime max,
            Func<IProperty<DateTime?>, IError> onErrorMin,
            Func<IProperty<DateTime?>, IError> onErrorMax,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            if(value.Value < min)
            {
                return onErrorMin(new Property<DateTime?>(value, propertyName));
            }

            if(value.Value > max)
            {
                return onErrorMax(new Property<DateTime?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> out of range. Error code 'MIN:{X}' or 'MAX:{X}'
        /// </summary>
        public static IError IfOutOfRange(
            this DateTime? value,
            DateTime min,
            DateTime max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfOutOfRange(
            min,
            max,
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.CreateDateMin(min),
                $"The '{propertyName}' is very old. The minimum is {min:yyyy-MM-dd}"
            ),
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.CreateDateMax(max),
                $"The '{propertyName}' is very future. The maximum is {max:yyyy-MM-dd}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> out of range and adds an error code 'MIN:{yyyy-MM-dd} or MAX:{yyyy-MM-dd}' in error list
        /// </summary>
        public static IValidatable<DateTime?> IfOutOfRange(
            this IValidatable<DateTime?> validatable,
            DateTime min,
            DateTime max
        ) => validatable.Validator(property => property.Value.IfOutOfRange(min, max, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> out of range and adds an error code 'MIN:{yyyy-MM-dd} or MAX:{yyyy-MM-dd}' in error list
        /// </summary>
        public static IValidatable<DateTime?> IfOutOfRange(
            this IValidatable<DateTime?> validatable,
            DateTime min,
            DateTime max,
            Func<IProperty<DateTime?>, IError> onErrorMin,
            Func<IProperty<DateTime?>, IError> onErrorMax
        ) => validatable.Validator(property => property.Value.IfOutOfRange(min, max, onErrorMin, onErrorMax));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to other value
        /// </summary>
        public static IError IfEquals(
            this DateTime? value,
            DateTime? otherValue,
            Func<IProperty<DateTime?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value == otherValue)
            {
                return onError(new Property<DateTime?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to other value. Error code 'INVALID'
        /// </summary>
        public static IError IfEquals(
            this DateTime? value,
            DateTime? otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfEquals(
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
        public static IValidatable<DateTime?> IfEquals(
            this IValidatable<DateTime?> validatable,
            DateTime? otherValue
        ) => validatable.Validator(property => property.Value.IfEquals(otherValue, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is equals to other value and adds an error
        /// </summary>
        public static IValidatable<DateTime?> IfEquals(
            this IValidatable<DateTime?> validatable,
            DateTime? otherValue,
            Func<IProperty<DateTime?>, IError> onError
        ) => validatable.Validator(property => property.Value.IfEquals(otherValue, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value
        /// </summary>
        public static IError IfDifferent(
            this DateTime? value,
            DateTime? otherValue,
            Func<IProperty<DateTime?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value != otherValue)
            {
                return onError(new Property<DateTime?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value. Error code 'INVALID'
        /// </summary>
        public static IError IfDifferent(
            this DateTime? value,
            DateTime? otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfDifferent(
            otherValue,
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.INVALID,
                $"The '{propertyName}' cannot be equal to '{otherValue}'"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<DateTime?> IfDifferent(
            this IValidatable<DateTime?> validatable,
            DateTime? otherValue
        ) => validatable.Validator(property => property.Value.IfDifferent(otherValue, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value and adds an error
        /// </summary>
        public static IValidatable<DateTime?> IfDifferent(
            this IValidatable<DateTime?> validatable,
            DateTime? otherValue,
            Func<IProperty<DateTime?>, IError> onError
        ) => validatable.Validator(property => property.Value.IfDifferent(otherValue, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than utc now
        /// </summary>
        public static IError IfGreaterThanUtcNow(
            this DateTime value,
            Func<IProperty<DateTime>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value > DateTime.UtcNow)
            {
                return onError(new Property<DateTime>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than utc now. Error code 'MAX:DATETIME_UTCNOW'
        /// </summary>
        public static IError IfGreaterThanUtcNow(
            this DateTime value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfGreaterThanUtcNow(
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.MAX_DATETIME_UTCNOW,
                $"The '{propertyName}' is very future. The maximum is UTC NOW"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than utc now and adds an error code 'MAX:DATETIME_UTCNOW' in error list
        /// </summary>
        public static IValidatable<DateTime> IfGreaterThanUtcNow(this IValidatable<DateTime> validatable)
            => validatable.Validator(property => property.Value.IfGreaterThanUtcNow(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than utc now and adds an error
        /// </summary>
        public static IValidatable<DateTime> IfGreaterThanUtcNow(
            this IValidatable<DateTime> validatable,
            Func<IProperty<DateTime>, IError> onError
        ) => validatable.Validator(property => property.Value.IfGreaterThanUtcNow(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than utc now
        /// </summary>
        public static IError IfGreaterThanUtcNow(
            this DateTime? value,
            Func<IProperty<DateTime?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }


            if(value.Value > DateTime.UtcNow)
            {
                return onError(new Property<DateTime?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than utc now. Error code 'MAX:DATETIME_UTCNOW'
        /// </summary>
        public static IError IfGreaterThanUtcNow(
            this DateTime? value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfGreaterThanUtcNow(
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.MAX_DATETIME_UTCNOW,
                $"The '{propertyName}' is very future. The maximum is UTC NOW"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than utc now and adds an error code 'MAX:DATETIME_UTCNOW' in error list
        /// </summary>
        public static IValidatable<DateTime?> IfGreaterThanUtcNow(this IValidatable<DateTime?> validatable)
            => validatable.Validator(property => property.Value.IfGreaterThanUtcNow(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than utc now and adds an error
        /// </summary>
        public static IValidatable<DateTime?> IfGreaterThanUtcNow(
            this IValidatable<DateTime?> validatable,
            Func<IProperty<DateTime?>, IError> onError
        ) => validatable.Validator(property => property.Value.IfGreaterThanUtcNow(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than utc today
        /// </summary>
        public static IError IfGreaterThanUtcToday(
            this DateTime value,
            Func<IProperty<DateTime>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value > DateTime.UtcNow.Date)
            {
                return onError(new Property<DateTime>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than utc today
        /// </summary>
        public static IError IfGreaterThanUtcToday(
            this DateTime value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfGreaterThanUtcToday(
            (_) => Error.Validation(
                propertyName,
                "MAX:DATETIME_UTCTODAY",
                $"The '{propertyName}' is very future. The maximum is UTC TODAY"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than utc today and adds an error code 'MAX:DATETIME_UTCTODAY' in error list
        /// </summary>
        public static IValidatable<DateTime> IfGreaterThanUtcToday(this IValidatable<DateTime> validatable)
            => validatable.Validator(property => property.Value.IfGreaterThanUtcToday(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than utc today and adds an error
        /// </summary>
        public static IValidatable<DateTime> IfGreaterThanUtcToday(
            this IValidatable<DateTime> validatable,
            Func<IProperty<DateTime>, IError> onError
        ) => validatable.Validator(property => property.Value.IfGreaterThanUtcToday(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than utc today
        /// </summary>
        public static IError IfGreaterThanUtcToday(
            this DateTime? value,
            Func<IProperty<DateTime?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            if(value.Value > DateTime.UtcNow.Date)
            {
                return onError(new Property<DateTime?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than utc today. Error code 'MAX:DATETIME_UTCTODAY'
        /// </summary>
        public static IError IfGreaterThanUtcToday(
            this DateTime? value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfGreaterThanUtcToday(
            (_) => Error.Validation(
                propertyName,
                "MAX:DATETIME_UTCTODAY",
                $"The '{propertyName}' is very future. The maximum is UTC TODAY"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than utc today and adds an error code 'MAX:DATETIME_UTCTODAY' in error list
        /// </summary>
        public static IValidatable<DateTime?> IfGreaterThanUtcToday(this IValidatable<DateTime?> validatable)
            => validatable.Validator(property => property.Value.IfGreaterThanUtcToday(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than utc today and adds an error
        /// </summary>
        public static IValidatable<DateTime?> IfGreaterThanUtcToday(
            this IValidatable<DateTime?> validatable,
            Func<IProperty<DateTime?>, IError> onError
        ) => validatable.Validator(property => property.Value.IfGreaterThanUtcToday(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than utc now
        /// </summary>
        public static IError IfLessThanUtcNow(
            this DateTime value,
            Func<IProperty<DateTime>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value < DateTime.UtcNow)
            {
                return onError(new Property<DateTime>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than utc now. Error code 'MIN:DATETIME_UTCNOW'
        /// </summary>
        public static IError IfLessThanUtcNow(
            this DateTime value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfLessThanUtcNow(
            (_) => Error.Validation(
                propertyName,
                "MIN:DATETIME_UTCNOW",
                $"The '{propertyName}' is very old. The minimum is UTC NOW"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than utc now and adds an error code 'MIN:DATETIME_UTCNOW' in error list
        /// </summary>
        public static IValidatable<DateTime> IfLessThanUtcNow(this IValidatable<DateTime> validatable)
            => validatable.Validator(property => property.Value.IfLessThanUtcNow(property.Name));


        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than utc now and adds an error
        /// </summary>
        public static IValidatable<DateTime> IfLessThanUtcNow(
            this IValidatable<DateTime> validatable,
            Func<IProperty<DateTime>, IError> onError
        ) => validatable.Validator(property => property.Value.IfLessThanUtcNow(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than utc now
        /// </summary>
        public static IError IfLessThanUtcNow(
            this DateTime? value,
            Func<IProperty<DateTime?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            if(value.Value < DateTime.UtcNow)
            {
                return onError(new Property<DateTime?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than utc now. Error code 'MIN:DATETIME_UTCNOW'
        /// </summary>
        public static IError IfLessThanUtcNow(
            this DateTime? value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfLessThanUtcNow(
            (_) => Error.Validation(
                propertyName,
                "MIN:DATETIME_UTCNOW",
                $"The '{propertyName}' is very old. The minimum is UTC NOW"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than utc now and adds an error code 'MIN:DATETIME_UTCNOW' in error list
        /// </summary>
        public static IValidatable<DateTime?> IfLessThanUtcNow(this IValidatable<DateTime?> validatable)
            => validatable.Validator(property => property.Value.IfLessThanUtcNow(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than utc now and adds an error
        /// </summary>
        public static IValidatable<DateTime?> IfLessThanUtcNow(
            this IValidatable<DateTime?> validatable,
            Func<IProperty<DateTime?>, IError> onError
        ) => validatable.Validator(property => property.Value.IfLessThanUtcNow(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than utc today
        /// </summary>
        public static IError IfLessThanUtcToday(
            this DateTime value,
            Func<IProperty<DateTime>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value < DateTime.UtcNow.Date)
            {
                return onError(new Property<DateTime>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than utc today. Error code 'MIN:DATETIME_UTCTODAY'
        /// </summary>
        public static IError IfLessThanUtcToday(
            this DateTime value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfLessThanUtcToday(
            (_) => Error.Validation(
                propertyName,
                "MIN:DATETIME_UTCTODAY",
                $"The '{propertyName}' is very old. The minimum is UTC TODAY"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than utc today and adds an error code 'MIN:DATETIME_UTCTODAY' in error list
        /// </summary>
        public static IValidatable<DateTime> IfLessThanUtcToday(this IValidatable<DateTime> validatable)
            => validatable.Validator(property => property.Value.IfLessThanUtcToday(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than utc today and adds an error
        /// </summary>
        public static IValidatable<DateTime> IfLessThanUtcToday(
            this IValidatable<DateTime> validatable,
            Func<IProperty<DateTime>, IError> onError
        ) => validatable.Validator(property => property.Value.IfLessThanUtcToday(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than utc today
        /// </summary>
        public static IError IfLessThanUtcToday(
            this DateTime? value,
            Func<IProperty<DateTime?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            if(value.Value < DateTime.UtcNow.Date)
            {
                return onError(new Property<DateTime?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than utc today. Error code 'MIN:DATETIME_UTCTODAY'
        /// </summary>
        public static IError IfLessThanUtcToday(
            this DateTime? value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfLessThanUtcToday(
            (_) => Error.Validation(
                propertyName,
                "MIN:DATETIME_UTCTODAY",
                $"The '{propertyName}' is very old. The minimum is UTC TODAY"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than utc today and adds an error code 'MIN:DATETIME_UTCTODAY' in error list
        /// </summary>
        public static IValidatable<DateTime?> IfLessThanUtcToday(this IValidatable<DateTime?> validatable)
            => validatable.Validator(property => property.Value.IfLessThanUtcToday(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than utc today and adds an error
        /// </summary>
        public static IValidatable<DateTime?> IfLessThanUtcToday(
            this IValidatable<DateTime?> validatable,
            Func<IProperty<DateTime?>, IError> onError
        ) => validatable.Validator(property => property.Value.IfLessThanUtcToday(onError));
    }
}
