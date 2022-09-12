using System.IO;
using System.Runtime.CompilerServices;

namespace PowerUtils.Results
{
    public static class StreamValidations
    {
        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is empty. Error code 'REQUIRED'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfEmpty(
            this Stream value,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value == null)
            {
                return null;
            }

            if(value.Length == 0)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.REQUIRED,
                    $"The '{propertyName}' cannot be empty"
                );
            }

            return null;
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is empty. Error code 'REQUIRED' in error list
        /// </summary>
        public static IValidatable<Stream> IfEmpty(this IValidatable<Stream> validatable)
            => validatable.Validator(property => property.Value.IfEmpty(property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is null or empty. Error code 'REQUIRED'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfNullOrEmpty(
            this Stream value,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value == null || value.Length == 0)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.REQUIRED,
                    $"The '{propertyName}' cannot be null or empty"
                );
            }

            return null;
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is null or empty. Error code 'REQUIRED' in error list
        /// </summary>
        public static IValidatable<Stream> IfNullOrEmpty(this IValidatable<Stream> validatable)
            => validatable.Validator(property => property.Value.IfNullOrEmpty(property.Name));
    }
}
