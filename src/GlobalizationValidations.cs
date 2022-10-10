using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PowerUtils.Results
{
    public static class GlobalizationValidations
    {
        private const int MAX_LATITUDE = 90;
        private const int MIN_LATITUDE = MAX_LATITUDE * -1;

        private const int MAX_LONGITUDE = 180;
        private const int MIN_LONGITUDE = MAX_LONGITUDE * -1;


        private static readonly HashSet<string> _iso2 = new(StringComparer.OrdinalIgnoreCase) { "XK", "AF", "AL", "AQ", "DZ", "AS", "AD", "AO", "AG", "AZ", "AR", "AU", "AT", "BS", "BH", "BD", "AM", "BB", "BE", "BM", "BT", "BO", "BA", "BW", "BV", "BR", "BZ", "IO", "SB", "VG", "BN", "BG", "MM", "BI", "BY", "KH", "CM", "CA", "CV", "KY", "CF", "LK", "TD", "CL", "CN", "TW", "CX", "CC", "CO", "KM", "YT", "CG", "CD", "CK", "CR", "HR", "CU", "CY", "CZ", "BJ", "DK", "DM", "DO", "EC", "SV", "GQ", "ET", "ER", "EE", "FO", "FK", "GS", "FJ", "FI", "AX", "FR", "GF", "PF", "TF", "DJ", "GA", "GE", "GM", "PS", "DE", "GH", "GI", "KI", "GR", "GL", "GD", "GP", "GU", "GT", "GN", "GY", "HT", "HM", "VA", "HN", "HK", "HU", "IS", "IN", "ID", "IR", "IQ", "IE", "IL", "IT", "CI", "JM", "JP", "KZ", "JO", "KE", "KP", "KR", "KW", "KG", "LA", "LB", "LS", "LV", "LR", "LY", "LI", "LT", "LU", "MO", "MG", "MW", "MY", "MV", "ML", "MT", "MQ", "MR", "MU", "MX", "MC", "MN", "MD", "ME", "MS", "MA", "MZ", "OM", "NA", "NR", "NP", "NL", "AN", "CW", "AW", "SX", "BQ", "NC", "VU", "NZ", "NI", "NE", "NG", "NU", "NF", "NO", "MP", "UM", "FM", "MH", "PW", "PK", "PA", "PG", "PY", "PE", "PH", "PN", "PL", "PT", "GW", "TL", "PR", "QA", "RE", "RO", "RU", "RW", "BL", "SH", "KN", "AI", "LC", "MF", "PM", "VC", "SM", "ST", "SA", "SN", "RS", "SC", "SL", "SG", "SK", "VN", "SI", "SO", "ZA", "ZW", "ES", "SS", "SD", "EH", "SR", "SJ", "SZ", "SE", "CH", "SY", "TJ", "TH", "TG", "TK", "TO", "TT", "AE", "TN", "TR", "TM", "TC", "TV", "UG", "UA", "MK", "EG", "GB", "GG", "JE", "IM", "TZ", "US", "VI", "BF", "UY", "UZ", "VE", "WF", "WS", "YE", "ZM" };



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is out of range
        /// </summary>
        public static IError IfLatitudeOutOfRange<TValue>(
            this TValue value,
            Func<IProperty<TValue>, IError> onErrorMin,
            Func<IProperty<TValue>, IError> onErrorMax,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value.CompareTo(Convert.ChangeType(MIN_LATITUDE, typeof(TValue))) < 0)
            {
                return onErrorMin(new Property<TValue>(value, propertyName));
            }

            if(value.CompareTo(Convert.ChangeType(MAX_LATITUDE, typeof(TValue))) > 0)
            {
                return onErrorMax(new Property<TValue>(value, propertyName));
            }

            return null;
        }


        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is out of range. Error code 'MIN:-90' or 'MAX:90'
        /// </summary>
        /// <param name="value">Latitude to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfLatitudeOutOfRange<TValue>(
            this TValue value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
            => value.IfLatitudeOutOfRange(
                (_) => Error.Validation(
                    propertyName,
                    ErrorCodeFactory.MIN_LATITUDE,
                    $"The '{propertyName}' is invalid. The minimum latitude is {MIN_LATITUDE}"
                ),
                (_) => Error.Validation(
                    propertyName,
                    ErrorCodeFactory.MAX_LATITUDE,
                    $"The '{propertyName}' is invalid. The maximum latitude is {MAX_LATITUDE}"
                ),
                propertyName
            );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is out of range and adds an error code 'MIN:-90' or 'MAX:90' in error list
        /// </summary>
        public static IValidatable<TValue> IfLatitudeOutOfRange<TValue>(this IValidatable<TValue> validatable)
            where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfLatitudeOutOfRange(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is out of range and adds an error
        /// </summary>
        public static IValidatable<TValue> IfLatitudeOutOfRange<TValue>(
            this IValidatable<TValue> validatable,
            Func<IProperty<TValue>, IError> onErrorMin,
            Func<IProperty<TValue>, IError> onErrorMax
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfLatitudeOutOfRange(onErrorMin, onErrorMax));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is out of range
        /// </summary>
        public static IError IfLatitudeOutOfRange<TValue>(
            this TValue? value,
            Func<IProperty<TValue?>, IError> onErrorMin,
            Func<IProperty<TValue?>, IError> onErrorMax,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value is null)
            {
                return null;
            }

            if(value.Value.CompareTo(Convert.ChangeType(MIN_LATITUDE, typeof(TValue))) < 0)
            {
                return onErrorMin(new Property<TValue?>(value, propertyName));
            }

            if(value.Value.CompareTo(Convert.ChangeType(MAX_LATITUDE, typeof(TValue))) > 0)
            {
                return onErrorMax(new Property<TValue?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is out of range. Error code 'MIN:-90' or 'MAX:90'
        /// </summary>
        public static IError IfLatitudeOutOfRange<TValue>(
            this TValue? value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
            => value.IfLatitudeOutOfRange(
                (_) => Error.Validation(
                    propertyName,
                    ErrorCodeFactory.MIN_LATITUDE,
                    $"The '{propertyName}' is invalid. The minimum latitude is {MIN_LATITUDE}"
                ),
                (_) => Error.Validation(
                    propertyName,
                    ErrorCodeFactory.MAX_LATITUDE,
                    $"The '{propertyName}' is invalid. The maximum latitude is {MAX_LATITUDE}"
                ),
                propertyName
            );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is out of range and adds an error code 'MIN:-90' or 'MAX:90' in error list
        /// </summary>
        public static IValidatable<TValue?> IfLatitudeOutOfRange<TValue>(this IValidatable<TValue?> validatable)
            where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfLatitudeOutOfRange(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is out of range and adds an error
        /// </summary>
        public static IValidatable<TValue?> IfLatitudeOutOfRange<TValue>(
            this IValidatable<TValue?> validatable,
            Func<IProperty<TValue?>, IError> onErrorMin,
            Func<IProperty<TValue?>, IError> onErrorMax
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfLatitudeOutOfRange(onErrorMin, onErrorMax));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is out of range. Error code 'MIN:-180' or 'MAX:180'
        /// </summary>
        public static IError IfLongitudeOutOfRange<TValue>(
            this TValue value,
            Func<IProperty<TValue>, IError> onErrorMin,
            Func<IProperty<TValue>, IError> onErrorMax,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value.CompareTo(Convert.ChangeType(MIN_LONGITUDE, typeof(TValue))) < 0)
            {
                return onErrorMin(new Property<TValue>(value, propertyName));
            }

            if(value.CompareTo(Convert.ChangeType(MAX_LONGITUDE, typeof(TValue))) > 0)
            {
                return onErrorMax(new Property<TValue>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is out of range. Error code 'MIN:-180' or 'MAX:180'
        /// </summary>
        public static IError IfLongitudeOutOfRange<TValue>(
            this TValue value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
            => value.IfLongitudeOutOfRange(
                (_) => Error.Validation(
                    propertyName,
                    ErrorCodeFactory.MIN_LONGITUDE,
                    $"The '{propertyName}' is invalid. The minimum longitude is {MIN_LONGITUDE}"
                ),
                (_) => Error.Validation(
                    propertyName,
                    ErrorCodeFactory.MAX_LONGITUDE,
                    $"The '{propertyName}' is invalid. The maximum longitude is {MAX_LONGITUDE}"
                ),
                propertyName
            );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is out of range and adds an error code 'MIN:-180' or 'MAX:180' in error list
        /// </summary>
        public static IValidatable<TValue> IfLongitudeOutOfRange<TValue>(this IValidatable<TValue> validatable)
            where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfLongitudeOutOfRange(property.Name));



        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is out of range and adds an error
        /// </summary>
        public static IValidatable<TValue> IfLongitudeOutOfRange<TValue>(
            this IValidatable<TValue> validatable,
            Func<IProperty<TValue>, IError> onErrorMin,
            Func<IProperty<TValue>, IError> onErrorMax
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfLongitudeOutOfRange(onErrorMin, onErrorMax));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is out of range
        /// </summary>
        public static IError IfLongitudeOutOfRange<TValue>(
            this TValue? value,
            Func<IProperty<TValue?>, IError> onErrorMin,
            Func<IProperty<TValue?>, IError> onErrorMax,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
        {
            if(value is null)
            {
                return null;
            }

            if(value.Value.CompareTo(Convert.ChangeType(MIN_LONGITUDE, typeof(TValue))) < 0)
            {
                return onErrorMin(new Property<TValue?>(value, propertyName));
            }

            if(value.Value.CompareTo(Convert.ChangeType(MAX_LONGITUDE, typeof(TValue))) > 0)
            {
                return onErrorMax(new Property<TValue?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is out of range. Error code 'MIN:-180' or 'MAX:180'
        /// </summary>
        public static IError IfLongitudeOutOfRange<TValue>(
            this TValue? value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : struct, IComparable<TValue>, IComparable
            => value.IfLongitudeOutOfRange(
                (_) => Error.Validation(
                    propertyName,
                    ErrorCodeFactory.MIN_LONGITUDE,
                    $"The '{propertyName}' is invalid. The minimum longitude is {MIN_LONGITUDE}"
                ),
                (_) => Error.Validation(
                    propertyName,
                    ErrorCodeFactory.MAX_LONGITUDE,
                    $"The '{propertyName}' is invalid. The maximum longitude is {MAX_LONGITUDE}"
                ),
                propertyName
            );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is out of range and adds an error code 'MIN:-180' or 'MAX:180' in error list
        /// </summary>
        public static IValidatable<TValue?> IfLongitudeOutOfRange<TValue>(this IValidatable<TValue?> validatable)
            where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfLongitudeOutOfRange(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is out of range and adds an error
        /// </summary>
        public static IValidatable<TValue?> IfLongitudeOutOfRange<TValue>(
            this IValidatable<TValue?> validatable,
            Func<IProperty<TValue?>, IError> onErrorMin,
            Func<IProperty<TValue?>, IError> onErrorMax
        ) where TValue : struct, IComparable<TValue>, IComparable
            => validatable.Validator(property => property.Value.IfLongitudeOutOfRange(onErrorMin, onErrorMax));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is not a country code ISO2
        /// </summary>
        public static IError IfNotISO2(
            this string value,
            Func<IProperty<string>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            if(value.Length != 2 || !_iso2.Contains(value))
            {
                return onError(new Property<string>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is not a country code ISO2
        /// </summary>
        public static IError IfNotISO2(
            this string value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfNotISO2(
            (_) => Error.Validation(
                propertyName,
                ResultErrorCodes.INVALID,
                $"The '{propertyName}' is invalid country code. ISO2 formats are allowed"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is not a country code ISO2 and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<string> IfNotISO2(this IValidatable<string> validatable)
            => validatable.Validator(property => property.Value.IfNotISO2(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is not a country code ISO2 and adds an error
        /// </summary>
        public static IValidatable<string> IfNotISO2(
            this IValidatable<string> validatable,
            Func<IProperty<string>, IError> onError
        ) => validatable.Validator(property => property.Value.IfNotISO2(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is not a country code ISO2
        /// </summary>
        public static IError ShouldBeISO2(
            this string value,
            Func<IProperty<string>, IError> onError
        ) => value.IfNotISO2(onError);

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is not a country code ISO2. Error code 'INVALID'
        /// </summary>
        public static IError ShouldBeISO2(
            this string value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfNotISO2(propertyName);

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is not a country code ISO2 and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<string> ShouldBeISO2(this IValidatable<string> validatable)
            => validatable.Validator(property => property.Value.ShouldBeISO2(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is not a country code ISO2 and adds an error
        /// </summary>
        public static IValidatable<string> ShouldBeISO2(
            this IValidatable<string> validatable,
            Func<IProperty<string>, IError> onError
        ) => validatable.Validator(property => property.Value.ShouldBeISO2(onError));
    }
}
