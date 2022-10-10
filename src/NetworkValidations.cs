using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace PowerUtils.Results
{
    public static class NetworkValidations
    {
        private static readonly Regex _emailRegex = new(@"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)+$", RegexOptions.Compiled);

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is not an email
        /// </summary>
        public static IError IfNotEmail(
            this string value,
            Func<IProperty<string>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            if(!_emailRegex.IsMatch(value))
            {
                return onError(new Property<string>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is not an email. Error code 'INVALID'
        /// </summary>
        public static IError IfNotEmail(
            this string value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfNotEmail(
            (_) => Error.Validation(
                propertyName,
                ResultErrorCodes.INVALID,
                $"The '{propertyName}' is not a valid email"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is not an email and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<string> IfNotEmail(this IValidatable<string> validatable)
            => validatable.Validator(property => property.Value.IfNotEmail(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is not an email and adds an error
        /// </summary>
        public static IValidatable<string> IfNotEmail(
            this IValidatable<string> validatable,
            Func<IProperty<string>, IError> onError
        ) => validatable.Validator(property => property.Value.IfNotEmail(onError));

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is not an email
        /// </summary>
        public static IError ShouldBeEmail(
            this string value,
            Func<IProperty<string>, IError> onError
        ) => value.IfNotEmail(onError);

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is not an email. Error code 'INVALID'
        /// </summary>
        public static IError ShouldBeEmail(
            this string value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfNotEmail(propertyName);

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is not an email and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<string> ShouldBeEmail(this IValidatable<string> validatable)
            => validatable.Validator(property => property.Value.ShouldBeEmail(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is not an email and adds an error
        /// </summary>
        public static IValidatable<string> ShouldBeEmail(
            this IValidatable<string> validatable,
            Func<IProperty<string>, IError> onError
        ) => validatable.Validator(property => property.Value.ShouldBeEmail(onError));
    }
}
