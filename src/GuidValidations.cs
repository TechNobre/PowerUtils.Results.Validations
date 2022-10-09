using System;
using System.Runtime.CompilerServices;

namespace PowerUtils.Results
{
    public static class GuidValidations
    {
        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is empty
        /// </summary>
        public static IError IfEmpty(
            this Guid value,
            Func<IProperty<Guid>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value == Guid.Empty)
            {
                return onError(new Property<Guid>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is empty. Error code 'REQUIRED'
        /// </summary>
        public static IError IfEmpty(
            this Guid value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfEmpty(
            (_) => Error.Validation(
                propertyName,
                Errors.Codes.REQUIRED,
                $"The '{propertyName}' cannot be empty"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is empty. Error code 'REQUIRED' in error list
        /// </summary>
        public static IValidatable<Guid> IfEmpty(this IValidatable<Guid> validatable)
            => validatable.Validator(property => property.Value.IfEmpty(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is empty and adds an error
        /// </summary>
        public static IValidatable<Guid> IfEmpty(this IValidatable<Guid> validatable, Func<IProperty<Guid>, IError> onError)
            => validatable.Validator(property => property.Value.IfEmpty(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to other value
        /// </summary>
        public static IError IfEquals(
            this Guid value,
            Guid otherValue,
            Func<IProperty<Guid>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value == otherValue)
            {
                return onError(new Property<Guid>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to other value. Error code 'INVALID'
        /// </summary>
        public static IError IfEquals(
            this Guid value,
            Guid otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfEquals(
            otherValue,
            (_) => Error.Validation(
                propertyName,
                Errors.Codes.INVALID,
                $"The '{propertyName}' cannot be equal to '{otherValue}'"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is equals to other value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<Guid> IfEquals(
            this IValidatable<Guid> validatable,
            Guid otherValue
        ) => validatable.Validator(property => property.Value.IfEquals(otherValue, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is equals to other value and adds an error
        /// </summary>
        public static IValidatable<Guid> IfEquals(
            this IValidatable<Guid> validatable,
            Guid otherValue,
            Func<IProperty<Guid>, IError> onError
        ) => validatable.Validator(property => property.Value.IfEquals(otherValue, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to other value
        /// </summary>
        public static IError IfEquals(
            this Guid? value,
            Guid? otherValue,
            Func<IProperty<Guid?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value == otherValue)
            {
                return onError(new Property<Guid?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to other value. Error code 'INVALID'
        /// </summary>
        public static IError IfEquals(
            this Guid? value,
            Guid? otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfEquals(
            otherValue,
            (_) => Error.Validation(
                propertyName,
                Errors.Codes.INVALID,
                $"The '{propertyName}' cannot be equal to '{otherValue}'"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is equals to other value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<Guid?> IfEquals(
            this IValidatable<Guid?> validatable,
            Guid? otherValue
        ) => validatable.Validator(property => property.Value.IfEquals(otherValue, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is equals to other value and adds an error
        /// </summary>
        public static IValidatable<Guid?> IfEquals(
            this IValidatable<Guid?> validatable,
            Guid? otherValue,
            Func<IProperty<Guid?>, IError> onError
        ) => validatable.Validator(property => property.Value.IfEquals(otherValue, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to other value
        /// </summary>
        public static IError IfEquals(
            this Guid value,
            Guid? otherValue,
            Func<IProperty<Guid>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value == otherValue)
            {
                return onError(new Property<Guid>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is equals to other value. Error code 'INVALID'
        /// </summary>
        public static IError IfEquals(
            this Guid value,
            Guid? otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfEquals(
            otherValue,
            (_) => Error.Validation(
                propertyName,
                Errors.Codes.INVALID,
                $"The '{propertyName}' cannot be equal to '{otherValue}'"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is equals to other value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<Guid> IfEquals(
            this IValidatable<Guid> validatable,
            Guid? otherValue
        ) => validatable.Validator(property => property.Value.IfEquals(otherValue, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is equals to other value and adds an error
        /// </summary>
        public static IValidatable<Guid> IfEquals(
            this IValidatable<Guid> validatable,
            Guid? otherValue,
            Func<IProperty<Guid>, IError> onError
        ) => validatable.Validator(property => property.Value.IfEquals(otherValue, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value
        /// </summary>
        public static IError IfDifferent(
            this Guid value,
            Guid otherValue,
            Func<IProperty<Guid>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value != otherValue)
            {
                return onError(new Property<Guid>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value. Error code 'INVALID'
        /// </summary>
        public static IError IfDifferent(
            this Guid value,
            Guid otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfDifferent(
            otherValue,
            (_) => Error.Validation(
                propertyName,
                Errors.Codes.INVALID,
                $"The '{propertyName}' cannot be different to '{otherValue}'"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<Guid> IfDifferent(
            this IValidatable<Guid> validatable,
            Guid otherValue
        ) => validatable.Validator(property => property.Value.IfDifferent(otherValue, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value value and adds an error
        /// </summary>
        public static IValidatable<Guid> IfDifferent(
            this IValidatable<Guid> validatable,
            Guid otherValue,
            Func<IProperty<Guid>, IError> onError
        ) => validatable.Validator(property => property.Value.IfDifferent(otherValue, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value. Error code 'INVALID'
        /// </summary>
        public static IError IfDifferent(
            this Guid? value,
            Guid? otherValue,
            Func<IProperty<Guid?>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value != otherValue)
            {
                return onError(new Property<Guid?>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value. Error code 'INVALID'
        /// </summary>
        public static IError IfDifferent(
            this Guid? value,
            Guid? otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfDifferent(
            otherValue,
            (_) => Error.Validation(
                propertyName,
                Errors.Codes.INVALID,
                $"The '{propertyName}' cannot be different to '{otherValue}'"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<Guid?> IfDifferent(
            this IValidatable<Guid?> validatable,
            Guid? otherValue
        ) => validatable.Validator(property => property.Value.IfDifferent(otherValue, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value value and adds an error
        /// </summary>
        public static IValidatable<Guid?> IfDifferent(
            this IValidatable<Guid?> validatable,
            Guid? otherValue,
            Func<IProperty<Guid?>, IError> onError
        ) => validatable.Validator(property => property.Value.IfDifferent(otherValue, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value
        /// </summary>
        public static IError IfDifferent(
            this Guid value,
            Guid? otherValue,
            Func<IProperty<Guid>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        )
        {
            if(value != otherValue)
            {
                return onError(new Property<Guid>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is different to other value. Error code 'INVALID'
        /// </summary>
        public static IError IfDifferent(
            this Guid value,
            Guid? otherValue,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfDifferent(
            otherValue,
            (_) => Error.Validation(
                propertyName,
                Errors.Codes.INVALID,
                $"The '{propertyName}' cannot be different to '{otherValue}'"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value value and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<Guid> IfDifferent(
            this IValidatable<Guid> validatable,
            Guid? otherValue
        ) => validatable.Validator(property => property.Value.IfDifferent(otherValue, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is different to other value value and adds an error
        /// </summary>
        public static IValidatable<Guid> IfDifferent(
            this IValidatable<Guid> validatable,
            Guid? otherValue,
            Func<IProperty<Guid>, IError> onError
        ) => validatable.Validator(property => property.Value.IfDifferent(otherValue, onError));
    }
}
