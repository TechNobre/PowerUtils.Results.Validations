using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace PowerUtils.Results
{
    public static class NetworkValidations
    {
        private static readonly Regex _emailRegex = new(@"^[a-zA-Z0-9.!#$%&'*+\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)+$", RegexOptions.Compiled);

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is not an email. Error code 'INVALID'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfNotEmail(
            this string value,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            if(!_emailRegex.IsMatch(value))
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.INVALID,
                    $"The '{propertyName}' is not a valid email"
                );
            }

            return null;
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is not an email and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<string> IfNotEmail(this IValidatable<string> validatable)
            => validatable.Validator(property => property.Value.IfNotEmail(property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is not an email. Error code 'INVALID'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError ShouldBeEmail(
            this string value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfNotEmail(propertyName);

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is not an email and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<string> ShouldBeEmail(this IValidatable<string> validatable)
            => validatable.Validator(property => property.Value.ShouldBeEmail(property.Name));
    }
}
