using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace PowerUtils.Results
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public static class StreamValidations
    {
        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is empty
        /// </summary>
        public static IError IfEmpty(
            this Stream value,
            Func<IProperty<Stream>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null)
            {
                return null;
            }

            if(value.Length == 0)
            {
                return onError(new Property<Stream>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is empty. Error code 'REQUIRED'
        /// </summary>
        public static IError IfEmpty(
            this Stream value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfEmpty(
            (_) => Error.Validation(
                propertyName,
                ResultErrorCodes.REQUIRED,
                $"The '{propertyName}' cannot be empty"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is empty. Error code 'REQUIRED' in error list
        /// </summary>
        public static IValidatable<Stream> IfEmpty(this IValidatable<Stream> validatable)
            => validatable.Validator(property => property.Value.IfEmpty(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is empty
        /// </summary>
        public static IValidatable<Stream> IfEmpty(
            this IValidatable<Stream> validatable,
            Func<IProperty<Stream>, IError> onError
        ) => validatable.Validator(property => property.Value.IfEmpty(onError));


        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is null or empty
        /// </summary>
        public static IError IfNullOrEmpty(
            this Stream value,
            Func<IProperty<Stream>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value is null || value.Length == 0)
            {
                return onError(new Property<Stream>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is null or empty. Error code 'REQUIRED'
        /// </summary>
        public static IError IfNullOrEmpty(
            this Stream value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfNullOrEmpty(
            (_) => Error.Validation(
                propertyName,
                ResultErrorCodes.REQUIRED,
                $"The '{propertyName}' cannot be null or empty"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is null or empty. Error code 'REQUIRED' in error list
        /// </summary>
        public static IValidatable<Stream> IfNullOrEmpty(this IValidatable<Stream> validatable)
            => validatable.Validator(property => property.Value.IfNullOrEmpty(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is null or empty
        /// </summary>
        public static IValidatable<Stream> IfNullOrEmpty(
            this IValidatable<Stream> validatable,
            Func<IProperty<Stream>, IError> onError
        ) => validatable.Validator(property => property.Value.IfNullOrEmpty(onError));
    }
}
