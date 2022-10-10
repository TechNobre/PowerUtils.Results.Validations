using System;
using System.Runtime.CompilerServices;

namespace PowerUtils.Results
{
    public static class DateValidations
    {
        public const string MIN_DATE_UTCTODAY = "MIN:DATE_UTCTODAY";
        public const string MAX_DATE_UTCTODAY = "MAX:DATE_UTCTODAY";


#if NET6_0_OR_GREATER
        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than
        /// </summary>
        public static IError IfGreaterThan(
            this DateOnly value,
            DateOnly max,
            Func<IProperty<DateOnly>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value > max)
            {
                return onError(new Property<DateOnly>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than. Error code 'MAX:{yyyy-MM-dd}'
        /// </summary>
        public static IError IfGreaterThan(
            this DateOnly value,
            DateOnly max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfGreaterThan(
            max,
            (_) => Error.Validation(
                propertyName,
                ErrorCodeFactory.CreateDateMax(max),
                $"The '{propertyName}' is very future. The maximum is {max:yyyy-MM-dd}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than and adds an error code 'MAX:{yyyy-MM-dd}' in error list
        /// </summary>
        public static IValidatable<DateOnly> IfGreaterThan(
            this IValidatable<DateOnly> validatable,
            DateOnly max
        ) => validatable.Validator(property => property.Value.IfGreaterThan(max, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than and adds an error
        /// </summary>
        public static IValidatable<DateOnly> IfGreaterThan(
            this IValidatable<DateOnly> validatable,
            DateOnly max,
            Func<IProperty<DateOnly>, IError> onError
        ) => validatable.Validator(property => property.Value.IfGreaterThan(max, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than
        /// </summary>
        public static IError IfGreaterThan(
            this DateOnly? value,
            DateOnly max,
            Func<IProperty<DateOnly?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is not null && value.Value > max)
            {
                return onError(new Property<DateOnly?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than. Error code 'MAX:{yyyy-MM-dd}'
        /// </summary>
        public static IError IfGreaterThan(
            this DateOnly? value,
            DateOnly max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfGreaterThan(
            max,
            (_) => Error.Validation(
                propertyName,
                ErrorCodeFactory.CreateDateMax(max),
                $"The '{propertyName}' is very future. The maximum is {max:yyyy-MM-dd}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than and adds an error code 'MAX:{yyyy-MM-dd}' in error list
        /// </summary>
        public static IValidatable<DateOnly?> IfGreaterThan(
            this IValidatable<DateOnly?> validatable,
            DateOnly max
        ) => validatable.Validator(property => property.Value.IfGreaterThan(max, property.Name));


        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than and adds an error
        /// </summary>
        public static IValidatable<DateOnly?> IfGreaterThan(
            this IValidatable<DateOnly?> validatable,
            DateOnly max,
            Func<IProperty<DateOnly?>, IError> onError
        ) => validatable.Validator(property => property.Value.IfGreaterThan(max, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than
        /// </summary>
        public static IError IfLessThan(
            this DateOnly value,
            DateOnly min,
            Func<IProperty<DateOnly>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value < min)
            {
                return onError(new Property<DateOnly>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than. Error code 'MIN:{yyyy-MM-dd}'
        /// </summary>
        public static IError IfLessThan(
            this DateOnly value,
            DateOnly min,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfLessThan(
            min,
            (_) => Error.Validation(
                propertyName,
                ErrorCodeFactory.CreateDateMin(min),
                $"The '{propertyName}' is very old. The minimum is {min:yyyy-MM-dd}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than and adds an error code 'MAX:{yyyy-MM-dd}' in error list
        /// </summary>
        public static IValidatable<DateOnly> IfLessThan(
            this IValidatable<DateOnly> validatable,
            DateOnly min
        ) => validatable.Validator(property => property.Value.IfLessThan(min, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than and adds an error
        /// </summary>
        public static IValidatable<DateOnly> IfLessThan(
            this IValidatable<DateOnly> validatable,
            DateOnly min,
            Func<IProperty<DateOnly>, IError> onError
        ) => validatable.Validator(property => property.Value.IfLessThan(min, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than
        /// </summary>
        public static IError IfLessThan(
            this DateOnly? value,
            DateOnly min,
            Func<IProperty<DateOnly?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is not null && value.Value < min)
            {
                return onError(new Property<DateOnly?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than. Error code 'MIN:{yyyy-MM-dd}'
        /// </summary>
        public static IError IfLessThan(
            this DateOnly? value,
            DateOnly min,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfLessThan(
            min,
            (_) => Error.Validation(
                propertyName,
                ErrorCodeFactory.CreateDateMin(min),
                $"The '{propertyName}' is very old. The minimum is {min:yyyy-MM-dd}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than and adds an error code 'MAX:{yyyy-MM-dd}' in error list
        /// </summary>
        public static IValidatable<DateOnly?> IfLessThan(
            this IValidatable<DateOnly?> validatable,
            DateOnly min
        ) => validatable.Validator(property => property.Value.IfLessThan(min, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than and adds an error
        /// </summary>
        public static IValidatable<DateOnly?> IfLessThan(
            this IValidatable<DateOnly?> validatable,
            DateOnly min,
            Func<IProperty<DateOnly?>, IError> onError
        ) => validatable.Validator(property => property.Value.IfLessThan(min, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> out of range
        /// </summary>
        public static IError IfOutOfRange(
            this DateOnly value,
            DateOnly min,
            DateOnly max,
            Func<IProperty<DateOnly>, IError> onErrorMin,
            Func<IProperty<DateOnly>, IError> onErrorMax,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value < min)
            {
                return onErrorMin(new Property<DateOnly>(value, propertyName));
            }

            if(value > max)
            {
                return onErrorMax(new Property<DateOnly>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> out of range. Error code 'MIN:{X}' or 'MAX:{X}'
        /// </summary>
        public static IError IfOutOfRange(
            this DateOnly value,
            DateOnly min,
            DateOnly max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfOutOfRange(
            min,
            max,
            (_) => Error.Validation(
                propertyName,
                ErrorCodeFactory.CreateDateMin(min),
                $"The '{propertyName}' is very old. The minimum is {min:yyyy-MM-dd}"
            ),
            (_) => Error.Validation(
                propertyName,
                ErrorCodeFactory.CreateDateMax(max),
                $"The '{propertyName}' is very future. The maximum is {max:yyyy-MM-dd}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> out of range and adds an error code 'MIN:{yyyy-MM-dd} or MAX:{yyyy-MM-dd}' in error list
        /// </summary>
        public static IValidatable<DateOnly> IfOutOfRange(
            this IValidatable<DateOnly> validatable,
            DateOnly min,
            DateOnly max
        ) => validatable.Validator(property => property.Value.IfOutOfRange(min, max, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> out of range and adds an error
        /// </summary>
        public static IValidatable<DateOnly> IfOutOfRange(
            this IValidatable<DateOnly> validatable,
            DateOnly min,
            DateOnly max,
            Func<IProperty<DateOnly>, IError> onErrorMin,
            Func<IProperty<DateOnly>, IError> onErrorMax
        ) => validatable.Validator(property => property.Value.IfOutOfRange(min, max, onErrorMin, onErrorMax));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> out of range
        /// </summary>
        public static IError IfOutOfRange(
            this DateOnly? value,
            DateOnly min,
            DateOnly max,
            Func<IProperty<DateOnly?>, IError> onErrorMin,
            Func<IProperty<DateOnly?>, IError> onErrorMax,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            if(value.Value < min)
            {
                return onErrorMin(new Property<DateOnly?>(value, propertyName));
            }

            if(value.Value > max)
            {
                return onErrorMax(new Property<DateOnly?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> out of range. Error code 'MIN:{X}' or 'MAX:{X}'
        /// </summary>
        public static IError IfOutOfRange(
            this DateOnly? value,
            DateOnly min,
            DateOnly max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfOutOfRange(
            min,
            max,
            (_) => Error.Validation(
                propertyName,
                ErrorCodeFactory.CreateDateMin(min),
                $"The '{propertyName}' is very old. The minimum is {min:yyyy-MM-dd}"
            ),
            (_) => Error.Validation(
                propertyName,
                ErrorCodeFactory.CreateDateMax(max),
                $"The '{propertyName}' is very future. The maximum is {max:yyyy-MM-dd}"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> out of range and adds an error code 'MIN:{yyyy-MM-dd} or MAX:{yyyy-MM-dd}' in error list
        /// </summary>
        public static IValidatable<DateOnly?> IfOutOfRange(
            this IValidatable<DateOnly?> validatable,
            DateOnly min,
            DateOnly max
        ) => validatable.Validator(property => property.Value.IfOutOfRange(min, max, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> out of range and adds an error code 'MIN:{yyyy-MM-dd} or MAX:{yyyy-MM-dd}' in error list
        /// </summary>
        public static IValidatable<DateOnly?> IfOutOfRange(
            this IValidatable<DateOnly?> validatable,
            DateOnly min,
            DateOnly max,
            Func<IProperty<DateOnly?>, IError> onErrorMin,
            Func<IProperty<DateOnly?>, IError> onErrorMax
        ) => validatable.Validator(property => property.Value.IfOutOfRange(min, max, onErrorMin, onErrorMax));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to other value
        /// </summary>
        public static IError IfEquals(
            this DateOnly? value,
            DateOnly? otherValue,
            Func<IProperty<DateOnly?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value == otherValue)
            {
                return onError(new Property<DateOnly?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to other value. Error code 'INVALID'
        /// </summary>
        public static IError IfEquals(
            this DateOnly? value,
            DateOnly? otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfEquals(
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
        public static IValidatable<DateOnly?> IfEquals(
            this IValidatable<DateOnly?> validatable,
            DateOnly? otherValue
        ) => validatable.Validator(property => property.Value.IfEquals(otherValue, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is equals to other value and adds an error
        /// </summary>
        public static IValidatable<DateOnly?> IfEquals(
            this IValidatable<DateOnly?> validatable,
            DateOnly? otherValue,
            Func<IProperty<DateOnly?>, IError> onError
        ) => validatable.Validator(property => property.Value.IfEquals(otherValue, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value
        /// </summary>
        public static IError IfDifferent(
            this DateOnly? value,
            DateOnly? otherValue,
            Func<IProperty<DateOnly?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value != otherValue)
            {
                return onError(new Property<DateOnly?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value. Error code 'INVALID'
        /// </summary>
        public static IError IfDifferent(
            this DateOnly? value,
            DateOnly? otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfDifferent(
            otherValue,
            (_) => Error.Validation(
                propertyName,
                ResultErrorCodes.INVALID,
                $"The '{propertyName}' cannot be equal to '{otherValue}'"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<DateOnly?> IfDifferent(
            this IValidatable<DateOnly?> validatable,
            DateOnly? otherValue
        ) => validatable.Validator(property => property.Value.IfDifferent(otherValue, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value and adds an error
        /// </summary>
        public static IValidatable<DateOnly?> IfDifferent(
            this IValidatable<DateOnly?> validatable,
            DateOnly? otherValue,
            Func<IProperty<DateOnly?>, IError> onError
        ) => validatable.Validator(property => property.Value.IfDifferent(otherValue, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than utc today
        /// </summary>
        public static IError IfGreaterThanUtcToday(
            this DateOnly value,
            Func<IProperty<DateOnly>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value > DateOnly.FromDateTime(DateTime.UtcNow))
            {
                return onError(new Property<DateOnly>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than utc today
        /// </summary>
        public static IError IfGreaterThanUtcToday(
            this DateOnly value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfGreaterThanUtcToday(
            (_) => Error.Validation(
                propertyName,
                MAX_DATE_UTCTODAY,
                $"The '{propertyName}' is very future. The maximum is UTC TODAY"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than utc today and adds an error code 'MAX:DATE_UTCTODAY' in error list
        /// </summary>
        public static IValidatable<DateOnly> IfGreaterThanUtcToday(this IValidatable<DateOnly> validatable)
            => validatable.Validator(property => property.Value.IfGreaterThanUtcToday(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than utc today and adds an error
        /// </summary>
        public static IValidatable<DateOnly> IfGreaterThanUtcToday(
            this IValidatable<DateOnly> validatable,
            Func<IProperty<DateOnly>, IError> onError
        ) => validatable.Validator(property => property.Value.IfGreaterThanUtcToday(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than utc today
        /// </summary>
        public static IError IfGreaterThanUtcToday(
            this DateOnly? value,
            Func<IProperty<DateOnly?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            if(value.Value > DateOnly.FromDateTime(DateTime.UtcNow))
            {
                return onError(new Property<DateOnly?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is greater than utc today. Error code 'MAX:DATE_UTCTODAY'
        /// </summary>
        public static IError IfGreaterThanUtcToday(
            this DateOnly? value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfGreaterThanUtcToday(
            (_) => Error.Validation(
                propertyName,
                MAX_DATE_UTCTODAY,
                $"The '{propertyName}' is very future. The maximum is UTC TODAY"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than utc today and adds an error code 'MAX:DATE_UTCTODAY' in error list
        /// </summary>
        public static IValidatable<DateOnly?> IfGreaterThanUtcToday(this IValidatable<DateOnly?> validatable)
            => validatable.Validator(property => property.Value.IfGreaterThanUtcToday(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is greater than utc today and adds an error
        /// </summary>
        public static IValidatable<DateOnly?> IfGreaterThanUtcToday(
            this IValidatable<DateOnly?> validatable,
            Func<IProperty<DateOnly?>, IError> onError
        ) => validatable.Validator(property => property.Value.IfGreaterThanUtcToday(onError));




        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than utc today
        /// </summary>
        public static IError IfLessThanUtcToday(
            this DateOnly value,
            Func<IProperty<DateOnly>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value < DateOnly.FromDateTime(DateTime.UtcNow))
            {
                return onError(new Property<DateOnly>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than utc today. Error code 'MIN:DATE_UTCTODAY'
        /// </summary>
        public static IError IfLessThanUtcToday(
            this DateOnly value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfLessThanUtcToday(
            (_) => Error.Validation(
                propertyName,
                MIN_DATE_UTCTODAY,
                $"The '{propertyName}' is very old. The minimum is UTC TODAY"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than utc today and adds an error code 'MIN:DATE_UTCTODAY' in error list
        /// </summary>
        public static IValidatable<DateOnly> IfLessThanUtcToday(this IValidatable<DateOnly> validatable)
            => validatable.Validator(property => property.Value.IfLessThanUtcToday(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than utc today and adds an error
        /// </summary>
        public static IValidatable<DateOnly> IfLessThanUtcToday(
            this IValidatable<DateOnly> validatable,
            Func<IProperty<DateOnly>, IError> onError
        ) => validatable.Validator(property => property.Value.IfLessThanUtcToday(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than utc today
        /// </summary>
        public static IError IfLessThanUtcToday(
            this DateOnly? value,
            Func<IProperty<DateOnly?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            if(value.Value < DateOnly.FromDateTime(DateTime.UtcNow))
            {
                return onError(new Property<DateOnly?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is less than utc today. Error code 'MIN:DATE_UTCTODAY'
        /// </summary>
        public static IError IfLessThanUtcToday(
            this DateOnly? value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfLessThanUtcToday(
            (_) => Error.Validation(
                propertyName,
                MIN_DATE_UTCTODAY,
                $"The '{propertyName}' is very old. The minimum is UTC TODAY"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than utc today and adds an error code 'MIN:DATE_UTCTODAY' in error list
        /// </summary>
        public static IValidatable<DateOnly?> IfLessThanUtcToday(this IValidatable<DateOnly?> validatable)
            => validatable.Validator(property => property.Value.IfLessThanUtcToday(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is less than utc today and adds an error
        /// </summary>
        public static IValidatable<DateOnly?> IfLessThanUtcToday(
            this IValidatable<DateOnly?> validatable,
            Func<IProperty<DateOnly?>, IError> onError
        ) => validatable.Validator(property => property.Value.IfLessThanUtcToday(onError));
#endif
    }
}
