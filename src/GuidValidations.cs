using System;
using System.Runtime.CompilerServices;

namespace PowerUtils.Results
{
    public static class GuidValidations
    {
        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is empty. Error code 'REQUIRED'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfEmpty(
            this Guid value,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value == Guid.Empty)
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
        public static IValidatable<Guid> IfEmpty(this IValidatable<Guid> validatable)
            => validatable.Validator(property => property.Value.IfEmpty(property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to other value. Error code 'INVALID'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="otherValue">Reference value for comparison</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfEquals(
            this Guid value,
            Guid otherValue,
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
        public static IValidatable<Guid> IfEquals(
            this IValidatable<Guid> validatable,
            Guid otherValue
        ) => validatable.Validator(property => property.Value.IfEquals(otherValue, property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to other value. Error code 'INVALID'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="otherValue">Reference value for comparison</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfEquals(
            this Guid? value,
            Guid? otherValue,
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
        public static IValidatable<Guid?> IfEquals(
            this IValidatable<Guid?> validatable,
            Guid? otherValue
        ) => validatable.Validator(property => property.Value.IfEquals(otherValue, property.Name));


        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to other value. Error code 'INVALID'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="otherValue">Reference value for comparison</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfEquals(
            this Guid value,
            Guid? otherValue,
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
        public static IValidatable<Guid> IfEquals(
            this IValidatable<Guid> validatable,
            Guid? otherValue
        ) => validatable.Validator(property => property.Value.IfEquals(otherValue, property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value. Error code 'INVALID'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="otherValue">Reference value for comparison</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfDifferent(
            this Guid value,
            Guid otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value != otherValue)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.INVALID,
                    $"The '{propertyName}' cannot be different to '{otherValue}'"
                );
            }

            return null;
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<Guid> IfDifferent(
            this IValidatable<Guid> validatable,
            Guid otherValue
        ) => validatable.Validator(property => property.Value.IfDifferent(otherValue, property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value. Error code 'INVALID'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="otherValue">Reference value for comparison</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfDifferent(
            this Guid? value,
            Guid? otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value != otherValue)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.INVALID,
                    $"The '{propertyName}' cannot be different to '{otherValue}'"
                );
            }

            return null;
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<Guid?> IfDifferent(
            this IValidatable<Guid?> validatable,
            Guid? otherValue
        ) => validatable.Validator(property => property.Value.IfDifferent(otherValue, property.Name));

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value. Error code 'INVALID'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="otherValue">Reference value for comparison</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfDifferent(
            this Guid value,
            Guid? otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value != otherValue)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.INVALID,
                    $"The '{propertyName}' cannot be different to '{otherValue}'"
                );
            }

            return null;
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<Guid> IfDifferent(
            this IValidatable<Guid> validatable,
            Guid? otherValue
        ) => validatable.Validator(property => property.Value.IfDifferent(otherValue, property.Name));
    }
}
