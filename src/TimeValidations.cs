using System;
using System.Runtime.CompilerServices;

namespace PowerUtils.Results
{
    public static class TimeValidations
    {
        public const string MIN_TIME_UTCNOW = "MIN:TIME_UTCNOW";
        public const string MAX_TIME_UTCNOW = "MAX:TIME_UTCNOW";


#if NET6_0_OR_GREATER
        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than
        /// </summary>
        public static IError IfGreaterThan(
            this TimeOnly value,
            TimeOnly max,
            Func<IProperty<TimeOnly>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value > max)
            {
                return onError(new Property<TimeOnly>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than. Error code 'MAX:{HH:mm:ss}'
        /// </summary>
        public static IError IfGreaterThan(
            this TimeOnly value,
            TimeOnly max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfGreaterThan(
            max,
            (_) => Error.Validation(
                propertyName,
                Temporary.CreateMax(max),
                $"The '{propertyName}' is very future. The maximum is {max:HH:mm:ss}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than and adds an error code 'MAX:{HH:mm:ss}' in error list
        /// </summary>
        public static IValidatable<TimeOnly> IfGreaterThan(
            this IValidatable<TimeOnly> validatable,
            TimeOnly max
        ) => validatable.Validator(property => property.Value.IfGreaterThan(max, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than and adds an error
        /// </summary>
        public static IValidatable<TimeOnly> IfGreaterThan(
            this IValidatable<TimeOnly> validatable,
            TimeOnly max,
            Func<IProperty<TimeOnly>, IError> onError
        ) => validatable.Validator(property => property.Value.IfGreaterThan(max, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than
        /// </summary>
        public static IError IfGreaterThan(
            this TimeOnly? value,
            TimeOnly max,
            Func<IProperty<TimeOnly?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is not null && value.Value > max)
            {
                return onError(new Property<TimeOnly?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than. Error code 'MAX:{HH:mm:ss}'
        /// </summary>
        public static IError IfGreaterThan(
            this TimeOnly? value,
            TimeOnly max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfGreaterThan(
            max,
            (_) => Error.Validation(
                propertyName,
                Temporary.CreateMax(max),
                $"The '{propertyName}' is very future. The maximum is {max:HH:mm:ss}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than and adds an error code 'MAX:{HH:mm:ss}' in error list
        /// </summary>
        public static IValidatable<TimeOnly?> IfGreaterThan(
            this IValidatable<TimeOnly?> validatable,
            TimeOnly max
        ) => validatable.Validator(property => property.Value.IfGreaterThan(max, property.Name));


        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than and adds an error
        /// </summary>
        public static IValidatable<TimeOnly?> IfGreaterThan(
            this IValidatable<TimeOnly?> validatable,
            TimeOnly max,
            Func<IProperty<TimeOnly?>, IError> onError
        ) => validatable.Validator(property => property.Value.IfGreaterThan(max, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than
        /// </summary>
        public static IError IfLessThan(
            this TimeOnly value,
            TimeOnly min,
            Func<IProperty<TimeOnly>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value < min)
            {
                return onError(new Property<TimeOnly>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than. Error code 'MIN:{HH:mm:ss}'
        /// </summary>
        public static IError IfLessThan(
            this TimeOnly value,
            TimeOnly min,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfLessThan(
            min,
            (_) => Error.Validation(
                propertyName,
                Temporary.CreateMin(min),
                $"The '{propertyName}' is very old. The minimum is {min:HH:mm:ss}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than and adds an error code 'MAX:{HH:mm:ss}' in error list
        /// </summary>
        public static IValidatable<TimeOnly> IfLessThan(
            this IValidatable<TimeOnly> validatable,
            TimeOnly min
        ) => validatable.Validator(property => property.Value.IfLessThan(min, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than and adds an error
        /// </summary>
        public static IValidatable<TimeOnly> IfLessThan(
            this IValidatable<TimeOnly> validatable,
            TimeOnly min,
            Func<IProperty<TimeOnly>, IError> onError
        ) => validatable.Validator(property => property.Value.IfLessThan(min, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than
        /// </summary>
        public static IError IfLessThan(
            this TimeOnly? value,
            TimeOnly min,
            Func<IProperty<TimeOnly?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is not null && value.Value < min)
            {
                return onError(new Property<TimeOnly?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than. Error code 'MIN:{HH:mm:ss}'
        /// </summary>
        public static IError IfLessThan(
            this TimeOnly? value,
            TimeOnly min,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfLessThan(
            min,
            (_) => Error.Validation(
                propertyName,
                Temporary.CreateMin(min),
                $"The '{propertyName}' is very old. The minimum is {min:HH:mm:ss}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than and adds an error code 'MAX:{HH:mm:ss}' in error list
        /// </summary>
        public static IValidatable<TimeOnly?> IfLessThan(
            this IValidatable<TimeOnly?> validatable,
            TimeOnly min
        ) => validatable.Validator(property => property.Value.IfLessThan(min, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than and adds an error
        /// </summary>
        public static IValidatable<TimeOnly?> IfLessThan(
            this IValidatable<TimeOnly?> validatable,
            TimeOnly min,
            Func<IProperty<TimeOnly?>, IError> onError
        ) => validatable.Validator(property => property.Value.IfLessThan(min, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> out of range
        /// </summary>
        public static IError IfOutOfRange(
            this TimeOnly value,
            TimeOnly min,
            TimeOnly max,
            Func<IProperty<TimeOnly>, IError> onErrorMin,
            Func<IProperty<TimeOnly>, IError> onErrorMax,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value < min)
            {
                return onErrorMin(new Property<TimeOnly>(value, propertyName));
            }

            if(value > max)
            {
                return onErrorMax(new Property<TimeOnly>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> out of range. Error code 'MIN:{X}' or 'MAX:{X}'
        /// </summary>
        public static IError IfOutOfRange(
            this TimeOnly value,
            TimeOnly min,
            TimeOnly max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfOutOfRange(
            min,
            max,
            (_) => Error.Validation(
                propertyName,
                Temporary.CreateMin(min),
                $"The '{propertyName}' is very old. The minimum is {min:HH:mm:ss}"
            ),
            (_) => Error.Validation(
                propertyName,
                Temporary.CreateMax(max),
                $"The '{propertyName}' is very future. The maximum is {max:HH:mm:ss}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> out of range and adds an error code 'MIN:{HH:mm:ss} or MAX:{HH:mm:ss}' in error list
        /// </summary>
        public static IValidatable<TimeOnly> IfOutOfRange(
            this IValidatable<TimeOnly> validatable,
            TimeOnly min,
            TimeOnly max
        ) => validatable.Validator(property => property.Value.IfOutOfRange(min, max, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> out of range and adds an error
        /// </summary>
        public static IValidatable<TimeOnly> IfOutOfRange(
            this IValidatable<TimeOnly> validatable,
            TimeOnly min,
            TimeOnly max,
            Func<IProperty<TimeOnly>, IError> onErrorMin,
            Func<IProperty<TimeOnly>, IError> onErrorMax
        ) => validatable.Validator(property => property.Value.IfOutOfRange(min, max, onErrorMin, onErrorMax));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> out of range
        /// </summary>
        public static IError IfOutOfRange(
            this TimeOnly? value,
            TimeOnly min,
            TimeOnly max,
            Func<IProperty<TimeOnly?>, IError> onErrorMin,
            Func<IProperty<TimeOnly?>, IError> onErrorMax,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            if(value.Value < min)
            {
                return onErrorMin(new Property<TimeOnly?>(value, propertyName));
            }

            if(value.Value > max)
            {
                return onErrorMax(new Property<TimeOnly?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> out of range. Error code 'MIN:{X}' or 'MAX:{X}'
        /// </summary>
        public static IError IfOutOfRange(
            this TimeOnly? value,
            TimeOnly min,
            TimeOnly max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfOutOfRange(
            min,
            max,
            (_) => Error.Validation(
                propertyName,
                Temporary.CreateMin(min),
                $"The '{propertyName}' is very old. The minimum is {min:HH:mm:ss}"
            ),
            (_) => Error.Validation(
                propertyName,
                Temporary.CreateMax(max),
                $"The '{propertyName}' is very future. The maximum is {max:HH:mm:ss}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> out of range and adds an error code 'MIN:{HH:mm:ss} or MAX:{HH:mm:ss}' in error list
        /// </summary>
        public static IValidatable<TimeOnly?> IfOutOfRange(
            this IValidatable<TimeOnly?> validatable,
            TimeOnly min,
            TimeOnly max
        ) => validatable.Validator(property => property.Value.IfOutOfRange(min, max, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> out of range and adds an error code 'MIN:{HH:mm:ss} or MAX:{HH:mm:ss}' in error list
        /// </summary>
        public static IValidatable<TimeOnly?> IfOutOfRange(
            this IValidatable<TimeOnly?> validatable,
            TimeOnly min,
            TimeOnly max,
            Func<IProperty<TimeOnly?>, IError> onErrorMin,
            Func<IProperty<TimeOnly?>, IError> onErrorMax
        ) => validatable.Validator(property => property.Value.IfOutOfRange(min, max, onErrorMin, onErrorMax));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to other value
        /// </summary>
        public static IError IfEquals(
            this TimeOnly? value,
            TimeOnly? otherValue,
            Func<IProperty<TimeOnly?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value == otherValue)
            {
                return onError(new Property<TimeOnly?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to other value. Error code 'INVALID'
        /// </summary>
        public static IError IfEquals(
            this TimeOnly? value,
            TimeOnly? otherValue,
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
        public static IValidatable<TimeOnly?> IfEquals(
            this IValidatable<TimeOnly?> validatable,
            TimeOnly? otherValue
        ) => validatable.Validator(property => property.Value.IfEquals(otherValue, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is equals to other value and adds an error
        /// </summary>
        public static IValidatable<TimeOnly?> IfEquals(
            this IValidatable<TimeOnly?> validatable,
            TimeOnly? otherValue,
            Func<IProperty<TimeOnly?>, IError> onError
        ) => validatable.Validator(property => property.Value.IfEquals(otherValue, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value
        /// </summary>
        public static IError IfDifferent(
            this TimeOnly? value,
            TimeOnly? otherValue,
            Func<IProperty<TimeOnly?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value != otherValue)
            {
                return onError(new Property<TimeOnly?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value. Error code 'INVALID'
        /// </summary>
        public static IError IfDifferent(
            this TimeOnly? value,
            TimeOnly? otherValue,
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
        public static IValidatable<TimeOnly?> IfDifferent(
            this IValidatable<TimeOnly?> validatable,
            TimeOnly? otherValue
        ) => validatable.Validator(property => property.Value.IfDifferent(otherValue, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value and adds an error
        /// </summary>
        public static IValidatable<TimeOnly?> IfDifferent(
            this IValidatable<TimeOnly?> validatable,
            TimeOnly? otherValue,
            Func<IProperty<TimeOnly?>, IError> onError
        ) => validatable.Validator(property => property.Value.IfDifferent(otherValue, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than utc now
        /// </summary>
        public static IError IfGreaterThanUtcNow(
            this TimeOnly value,
            Func<IProperty<TimeOnly>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value > TimeOnly.FromDateTime(DateTime.UtcNow))
            {
                return onError(new Property<TimeOnly>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than utc now. Error code 'MAX:DATETIME_UTCNOW'
        /// </summary>
        public static IError IfGreaterThanUtcNow(
            this TimeOnly value,
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
        public static IValidatable<TimeOnly> IfGreaterThanUtcNow(this IValidatable<TimeOnly> validatable)
            => validatable.Validator(property => property.Value.IfGreaterThanUtcNow(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than utc now and adds an error
        /// </summary>
        public static IValidatable<TimeOnly> IfGreaterThanUtcNow(
            this IValidatable<TimeOnly> validatable,
            Func<IProperty<TimeOnly>, IError> onError
        ) => validatable.Validator(property => property.Value.IfGreaterThanUtcNow(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than utc now
        /// </summary>
        public static IError IfGreaterThanUtcNow(
            this TimeOnly? value,
            Func<IProperty<TimeOnly?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }


            if(value.Value > TimeOnly.FromDateTime(DateTime.UtcNow))
            {
                return onError(new Property<TimeOnly?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than utc now. Error code 'MAX:DATETIME_UTCNOW'
        /// </summary>
        public static IError IfGreaterThanUtcNow(
            this TimeOnly? value,
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
        public static IValidatable<TimeOnly?> IfGreaterThanUtcNow(this IValidatable<TimeOnly?> validatable)
            => validatable.Validator(property => property.Value.IfGreaterThanUtcNow(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than utc now and adds an error
        /// </summary>
        public static IValidatable<TimeOnly?> IfGreaterThanUtcNow(
            this IValidatable<TimeOnly?> validatable,
            Func<IProperty<TimeOnly?>, IError> onError
        ) => validatable.Validator(property => property.Value.IfGreaterThanUtcNow(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than utc now
        /// </summary>
        public static IError IfLessThanUtcNow(
            this TimeOnly value,
            Func<IProperty<TimeOnly>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value < TimeOnly.FromDateTime(DateTime.UtcNow))
            {
                return onError(new Property<TimeOnly>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than utc now. Error code 'MIN:DATETIME_UTCNOW'
        /// </summary>
        public static IError IfLessThanUtcNow(
            this TimeOnly value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfLessThanUtcNow(
            (_) => Error.Validation(
                propertyName,
                MIN_TIME_UTCNOW,
                $"The '{propertyName}' is very old. The minimum is UTC NOW"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than utc now and adds an error code 'MIN:DATETIME_UTCNOW' in error list
        /// </summary>
        public static IValidatable<TimeOnly> IfLessThanUtcNow(this IValidatable<TimeOnly> validatable)
            => validatable.Validator(property => property.Value.IfLessThanUtcNow(property.Name));


        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than utc now and adds an error
        /// </summary>
        public static IValidatable<TimeOnly> IfLessThanUtcNow(
            this IValidatable<TimeOnly> validatable,
            Func<IProperty<TimeOnly>, IError> onError
        ) => validatable.Validator(property => property.Value.IfLessThanUtcNow(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than utc now
        /// </summary>
        public static IError IfLessThanUtcNow(
            this TimeOnly? value,
            Func<IProperty<TimeOnly?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            if(value.Value < TimeOnly.FromDateTime(DateTime.UtcNow))
            {
                return onError(new Property<TimeOnly?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than utc now. Error code 'MIN:DATETIME_UTCNOW'
        /// </summary>
        public static IError IfLessThanUtcNow(
            this TimeOnly? value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfLessThanUtcNow(
            (_) => Error.Validation(
                propertyName,
                MIN_TIME_UTCNOW,
                $"The '{propertyName}' is very old. The minimum is UTC NOW"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than utc now and adds an error code 'MIN:DATETIME_UTCNOW' in error list
        /// </summary>
        public static IValidatable<TimeOnly?> IfLessThanUtcNow(this IValidatable<TimeOnly?> validatable)
            => validatable.Validator(property => property.Value.IfLessThanUtcNow(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than utc now and adds an error
        /// </summary>
        public static IValidatable<TimeOnly?> IfLessThanUtcNow(
            this IValidatable<TimeOnly?> validatable,
            Func<IProperty<TimeOnly?>, IError> onError
        ) => validatable.Validator(property => property.Value.IfLessThanUtcNow(onError));
#endif
    }
}
