using System;
using System.Runtime.CompilerServices;

namespace PowerUtils.Results
{
    public static class HumanValidations
    {
        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is not a gender
        /// </summary>
        public static IError IfNotGender(
            this string value,
            Func<IProperty<string>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value?.ToUpper() switch
        {
            "MALE" or "FEMALE" or null => null,
            _ => onError(new Property<string>(value, propertyName))
        };

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is not a gender. Error code 'INVALID'
        /// </summary>
        public static IError IfNotGender(
            this string value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfNotGender(
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.INVALID,
                $"The '{propertyName}' is invalid gender. The allowed values are 'MALE' and 'FEMALE'"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is not a gender and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<string> IfNotGender(this IValidatable<string> validatable)
            => validatable.Validator(property => property.Value.IfNotGender(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is not a gender and adds an error
        /// </summary>
        public static IValidatable<string> IfNotGender(
            this IValidatable<string> validatable,
            Func<IProperty<string>, IError> onError
        ) => validatable.Validator(property => property.Value.IfNotGender(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is not a gender
        /// </summary>
        public static IError ShouldBeGender(
            this string value,
            Func<IProperty<string>, IError> onError
        ) => value.IfNotGender(onError);

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is not a gender. Error code 'INVALID'
        /// </summary>
        public static IError ShouldBeGender(
            this string value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfNotGender(propertyName);

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/>  is not a gender and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<string> ShouldBeGender(this IValidatable<string> validatable)
            => validatable.Validator(property => property.Value.ShouldBeGender(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/>  is not a gender and adds an error
        /// </summary>
        public static IValidatable<string> ShouldBeGender(
            this IValidatable<string> validatable,
            Func<IProperty<string>, IError> onError
        ) => validatable.Validator(property => property.Value.ShouldBeGender(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is a gender
        /// </summary>
        public static IError IfNotGenderOrOther(
            this string value,
            Func<IProperty<string>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value?.ToUpper() switch
        {
            "MALE" or "FEMALE" or "OTHER" or null => null,
            _ => onError(new Property<string>(value, propertyName))
        };

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is a gender. Error code 'INVALID'
        /// </summary>
        public static IError IfNotGenderOrOther(
            this string value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfNotGenderOrOther(
            (_) => Error.Validation(
                propertyName,
                ErrorCodes.INVALID,
                $"The '{propertyName}' is invalid gender. The allowed values are 'MALE', 'FEMALE' or 'OTHER'"
            ),
            propertyName
        );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is a gender and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<string> IfNotGenderOrOther(this IValidatable<string> validatable)
            => validatable.Validator(property => property.Value.IfNotGenderOrOther(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is a gender and adds an error
        /// </summary>
        public static IValidatable<string> IfNotGenderOrOther(
            this IValidatable<string> validatable,
            Func<IProperty<string>, IError> onError
        ) => validatable.Validator(property => property.Value.IfNotGenderOrOther(onError));


        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is a gender
        /// </summary>
        public static IError ShouldBeGenderOrOther(
            this string value,
            Func<IProperty<string>, IError> onError
        ) => value.IfNotGenderOrOther(onError);

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is a gender. Error code 'INVALID'
        /// </summary>
        public static IError ShouldBeGenderOrOther(
            this string value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => value.IfNotGenderOrOther(propertyName);

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is a gender and adds an error code 'INVALID' in error list
        /// </summary>
        public static IValidatable<string> ShouldBeGenderOrOther(this IValidatable<string> validatable)
            => validatable.Validator(property => property.Value.ShouldBeGenderOrOther(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is a gender and adds an error
        /// </summary>
        public static IValidatable<string> ShouldBeGenderOrOther(
            this IValidatable<string> validatable,
            Func<IProperty<string>, IError> onError
        ) => validatable.Validator(property => property.Value.ShouldBeGenderOrOther(onError));
    }
}
