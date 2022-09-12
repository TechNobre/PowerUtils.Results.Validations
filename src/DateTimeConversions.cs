using System;
using System.Globalization;

namespace PowerUtils.Results
{
    public static class DateTimeConversions
    {
        /// <summary>
        /// Try to convert the <paramref name="validatable.Value"/> to a DateTime. The default format is 'yyyy-MM-dd HH:mm:ss'
        /// </summary>
        public static IValidatable<DateTime> ToDateTime(this IValidatable<string> validatable, string format = "yyyy-MM-dd HH:mm:ss")
            => validatable.ToDateTime(out var _, format);

        /// <summary>
        /// Try to convert the <paramref name="validatable.Value"/> to a DateTime. The default format is 'yyyy-MM-dd HH:mm:ss'
        /// </summary>
        public static IValidatable<DateTime> ToDateTime(this IValidatable<string> validatable, out DateTime result, string format = "yyyy-MM-dd HH:mm:ss")
        {
            if(DateTime.TryParseExact(validatable.Value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                return new Validatable<DateTime>(
                    result,
                    validatable.Name,
                    validatable.Errors
                );
            }

            result = default;
            var convertible = new Validatable<DateTime>(
                result,
                validatable.Name,
                validatable.Errors
            );

            convertible.AddError(
                Error.Validation(
                    convertible.Name,
                    ErrorCodes.INVALID,
                    $"The '{validatable.Name}' is an invalid 'DateTime'. The supported format is '{format}'"
                )
            );

            return convertible;
        }

        /// <summary>
        /// Try to convert the <paramref name="validatable.Value"/> to a DateTime. The default format is 'yyyy-MM-dd HH:mm:ss'
        /// </summary>
        public static IValidatable<DateTime?> ToDateTimeNullable(this IValidatable<string> validatable, string format = "yyyy-MM-dd HH:mm:ss")
            => validatable.ToDateTimeNullable(out var _, format);

        /// <summary>
        /// Try to convert the <paramref name="validatable.Value"/> to a DateTime. The default format is 'yyyy-MM-dd HH:mm:ss'
        /// </summary>
        public static IValidatable<DateTime?> ToDateTimeNullable(this IValidatable<string> validatable, out DateTime? result, string format = "yyyy-MM-dd HH:mm:ss")
        {
            if(DateTime.TryParseExact(validatable.Value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateTime))
            {
                result = dateTime;
                return new Validatable<DateTime?>(
                    dateTime,
                    validatable.Name,
                    validatable.Errors
                );
            }

            result = default;
            var convertible = new Validatable<DateTime?>(
                result,
                validatable.Name,
                validatable.Errors
            );

            convertible.AddError(
                Error.Validation(
                    convertible.Name,
                    ErrorCodes.INVALID,
                    $"The '{validatable.Name}' is an invalid 'DateTime'. The supported format is '{format}'"
                )
            );

            return convertible;
        }



#if NET6_0_OR_GREATER
        /// <summary>
        /// Try to convert the <paramref name="validatable.Value"/> to a Date. The default format is 'yyyy-MM-dd'
        /// </summary>
        public static IValidatable<DateOnly> ToDate(this IValidatable<string> validatable, string format = "yyyy-MM-dd")
            => validatable.ToDate(out var _, format);

        /// <summary>
        /// Try to convert the <paramref name="validatable.Value"/> to a Date. The default format is 'yyyy-MM-dd'
        /// </summary>
        public static IValidatable<DateOnly> ToDate(this IValidatable<string> validatable, out DateOnly result, string format = "yyyy-MM-dd")
        {
            if(DateOnly.TryParseExact(validatable.Value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                return new Validatable<DateOnly>(
                    result,
                    validatable.Name,
                    validatable.Errors
                );
            }

            result = default;
            var convertible = new Validatable<DateOnly>(
                result,
                validatable.Name,
                validatable.Errors
            );

            convertible.AddError(
                Error.Validation(
                    convertible.Name,
                    ErrorCodes.INVALID,
                    $"The '{validatable.Name}' is an invalid 'Date'. The supported format is '{format}'"
                )
            );

            return convertible;
        }

        /// <summary>
        /// Try to convert the <paramref name="validatable.Value"/> to a Date. The default format is 'yyyy-MM-dd'
        /// </summary>
        public static IValidatable<DateOnly?> ToDateNullable(this IValidatable<string> validatable, string format = "yyyy-MM-dd")
            => validatable.ToDateNullable(out var _, format);

        /// <summary>
        /// Try to convert the <paramref name="validatable.Value"/> to a Date. The default format is 'yyyy-MM-dd'
        /// </summary>
        public static IValidatable<DateOnly?> ToDateNullable(this IValidatable<string> validatable, out DateOnly? result, string format = "yyyy-MM-dd")
        {
            if(DateOnly.TryParseExact(validatable.Value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
            {
                result = date;
                return new Validatable<DateOnly?>(
                    date,
                    validatable.Name,
                    validatable.Errors
                );
            }

            result = default;
            var convertible = new Validatable<DateOnly?>(
                result,
                validatable.Name,
                validatable.Errors
            );

            convertible.AddError(
                Error.Validation(
                    convertible.Name,
                    ErrorCodes.INVALID,
                    $"The '{validatable.Name}' is an invalid 'Date'. The supported format is '{format}'"
                )
            );

            return convertible;
        }



        /// <summary>
        /// Try to convert the <paramref name="validatable.Value"/> to a Time. The default format is 'HH:mm:ss'
        /// </summary>
        public static IValidatable<TimeOnly> ToTime(this IValidatable<string> validatable, string format = "HH:mm:ss")
            => validatable.ToTime(out var _, format);

        /// <summary>
        /// Try to convert the <paramref name="validatable.Value"/> to a Time. The default format is 'HH:mm:ss'
        /// </summary>
        public static IValidatable<TimeOnly> ToTime(this IValidatable<string> validatable, out TimeOnly result, string format = "HH:mm:ss")
        {
            if(TimeOnly.TryParseExact(validatable.Value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                return new Validatable<TimeOnly>(
                    result,
                    validatable.Name,
                    validatable.Errors
                );
            }

            result = default;
            var convertible = new Validatable<TimeOnly>(
                result,
                validatable.Name,
                validatable.Errors
            );

            convertible.AddError(
                Error.Validation(
                    convertible.Name,
                    ErrorCodes.INVALID,
                    $"The '{validatable.Name}' is an invalid 'Time'. The supported format is '{format}'"
                )
            );

            return convertible;
        }

        /// <summary>
        /// Try to convert the <paramref name="validatable.Value"/> to a Time. The default format is 'HH:mm:ss'
        /// </summary>
        public static IValidatable<TimeOnly?> ToTimeNullable(this IValidatable<string> validatable, string format = "HH:mm:ss")
            => validatable.ToTimeNullable(out var _, format);

        /// <summary>
        /// Try to convert the <paramref name="validatable.Value"/> to a Time. The default format is 'HH:mm:ss'
        /// </summary>
        public static IValidatable<TimeOnly?> ToTimeNullable(this IValidatable<string> validatable, out TimeOnly? result, string format = "HH:mm:ss")
        {
            if(TimeOnly.TryParseExact(validatable.Value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var time))
            {
                result = time;
                return new Validatable<TimeOnly?>(
                    time,
                    validatable.Name,
                    validatable.Errors
                );
            }

            result = default;
            var convertible = new Validatable<TimeOnly?>(
                result,
                validatable.Name,
                validatable.Errors
            );

            convertible.AddError(
                Error.Validation(
                    convertible.Name,
                    ErrorCodes.INVALID,
                    $"The '{validatable.Name}' is an invalid 'Time'. The supported format is '{format}'"
                )
            );

            return convertible;
        }
#endif
    }
}
