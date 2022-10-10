using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace PowerUtils.Results
{
    public static class CollectionValidations
    {
        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is empty
        /// </summary>
        public static IError IfEmpty<TValue>(
            this TValue value,
            Func<IProperty<TValue>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : IEnumerable
        {
            if(value is null)
            {
                return null;
            }

            if(value._itemCounter() == 0)
            {
                return onError(new Property<TValue>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is empty. Error code 'REQUIRED'
        /// </summary>
        public static IError IfEmpty<TValue>(
            this TValue value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : IEnumerable
            => value.IfEmpty(
                (_) => Error.Validation(
                    propertyName,
                    ResultErrorCodes.REQUIRED,
                    $"The '{propertyName}' cannot be empty"
                ),
                propertyName
            );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is empty and. Error code 'REQUIRED' in error list
        /// </summary>
        public static IValidatable<TValue> IfEmpty<TValue>(this IValidatable<TValue> validatable)
            where TValue : IEnumerable
            => validatable.Validator(property => property.Value.IfEmpty(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is empty and adds an error
        /// </summary>
        public static IValidatable<TValue> IfEmpty<TValue>(
            this IValidatable<TValue> validatable,
            Func<IProperty<TValue>, IError> onError
        ) where TValue : IEnumerable
            => validatable.Validator(property => property.Value.IfEmpty(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is null or empty
        /// </summary>
        public static IError IfNullOrEmpty<TValue>(
            this TValue value,
            Func<IProperty<TValue>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : IEnumerable
        {
            if(value is null || value._itemCounter() == 0)
            {
                return onError(new Property<TValue>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is null or empty. Error code 'REQUIRED'
        /// </summary>
        public static IError IfNullOrEmpty<TValue>(
            this TValue value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : IEnumerable
            => value.IfNullOrEmpty(
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
        public static IValidatable<TValue> IfNullOrEmpty<TValue>(this IValidatable<TValue> validatable)
            where TValue : IEnumerable
            => validatable.Validator(property => property.Value.IfNullOrEmpty(property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> is null or empty and add ab error
        /// </summary>
        public static IValidatable<TValue> IfNullOrEmpty<TValue>(
            this IValidatable<TValue> validatable,
            Func<IProperty<TValue>, IError> onError
        ) where TValue : IEnumerable
            => validatable.Validator(property => property.Value.IfNullOrEmpty(onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> contains a number of items greater than
        /// </summary>
        public static IError IfCountGreaterThan<TValue>(
            this TValue value,
            int max,
            Func<IProperty<TValue>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : IEnumerable
        {
            if(value is null)
            {
                return null;
            }

            if(value._itemCounter() > max)
            {
                return onError(new Property<TValue>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> contains a number of items greater than. Error code 'MAX:{X}'
        /// </summary>
        public static IError IfCountGreaterThan<TValue>(
            this TValue value,
            int max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : IEnumerable
            => value.IfCountGreaterThan(
                max,
                (_) => Error.Validation(
                    propertyName,
                    ErrorCodeFactory.CreateMax(max),
                    $"The '{propertyName}' contains a lot of items. The maximum is {max}"
                ),
                propertyName
            );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> contains a number of items greater than. Error code 'MAX:{X}' in error list
        /// </summary>
        public static IValidatable<TValue> IfCountGreaterThan<TValue>(
            this IValidatable<TValue> validatable,
            int max
        ) where TValue : IEnumerable
            => validatable.Validator(property => property.Value.IfCountGreaterThan(max, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> contains a number of items greater than
        /// </summary>
        public static IValidatable<TValue> IfCountGreaterThan<TValue>(
            this IValidatable<TValue> validatable,
            int max,
            Func<IProperty<TValue>, IError> onError
        ) where TValue : IEnumerable
            => validatable.Validator(property => property.Value.IfCountGreaterThan(max, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> contains a number of items less than
        /// </summary>
        public static IError IfCountLessThan<TValue>(
            this TValue value,
            int min,
            Func<IProperty<TValue>, IError> onError,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : IEnumerable
        {
            if(value is null)
            {
                return null;
            }

            if(value._itemCounter() < min)
            {
                return onError(new Property<TValue>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> contains a number of items less than. Error code 'MIN:{X}'
        /// </summary>
        public static IError IfCountLessThan<TValue>(
            this TValue value,
            int min,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : IEnumerable
            => value.IfCountLessThan(
                min,
                (_) => Error.Validation(
                    propertyName,
                    ErrorCodeFactory.CreateMin(min),
                    $"The '{propertyName}' contains few items. The minimum is {min}"
                ),
                propertyName
            );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> contains a number of items less than. Error code 'MIN:{X}' in error list
        /// </summary>
        public static IValidatable<TValue> IfCountLessThan<TValue>(
            this IValidatable<TValue> validatable,
            int min
        ) where TValue : IEnumerable
            => validatable.Validator(property => property.Value.IfCountLessThan(min, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> contains a number of items less than
        /// </summary>
        public static IValidatable<TValue> IfCountLessThan<TValue>(
            this IValidatable<TValue> validatable,
            int min,
            Func<IProperty<TValue>, IError> onError
        ) where TValue : IEnumerable
            => validatable.Validator(property => property.Value.IfCountLessThan(min, onError));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> out of range
        /// </summary>
        public static IError IfCountOutOfRange<TValue>(
            this TValue value,
            int min,
            int max,
            Func<IProperty<TValue>, IError> onErrorMin,
            Func<IProperty<TValue>, IError> onErrorMax,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : IEnumerable
        {
            if(value is null)
            {
                return null;
            }

            if(value._itemCounter() < min)
            {
                return onErrorMin(new Property<TValue>(value, propertyName));
            }

            if(value._itemCounter() > max)
            {
                return onErrorMax(new Property<TValue>(value, propertyName));
            }

            return null;
        }

        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> out of range. Error code 'MIN:{X}' or 'MAX:{X}'
        /// </summary>
        public static IError IfCountOutOfRange<TValue>(
            this TValue value,
            int min,
            int max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : IEnumerable
            => value.IfCountOutOfRange(
                min,
                max,
                (_) => Error.Validation(
                    propertyName,
                    ErrorCodeFactory.CreateMin(min),
                    $"The '{propertyName}' contains few items. The minimum is {min}"
                ),
                (_) => Error.Validation(
                    propertyName,
                    ErrorCodeFactory.CreateMax(max),
                    $"The '{propertyName}' contains a lot of items. The maximum is {max}"
                ),
                propertyName
            );

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> out of range and adds an error code 'MIN:{X}' or 'MAX:{X}' in error list
        /// </summary>
        public static IValidatable<TValue> IfCountOutOfRange<TValue>(
            this IValidatable<TValue> validatable,
            int min,
            int max
        ) where TValue : IEnumerable
            => validatable.Validator(property => property.Value.IfCountOutOfRange(min, max, property.Name));

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> out of range and adds an error
        /// </summary>
        public static IValidatable<TValue> IfCountOutOfRange<TValue>(
            this IValidatable<TValue> validatable,
            int min,
            int max,
            Func<IProperty<TValue>, IError> onErrorMin,
            Func<IProperty<TValue>, IError> onErrorMax
        ) where TValue : IEnumerable
            => validatable.Validator(property => property.Value.IfCountOutOfRange(min, max, onErrorMin, onErrorMax));



        private static int _itemCounter(this IEnumerable value)
        {
            if(value is ICollection collection)
            {
                return collection.Count;
            }

            return value._enumerableCounter();
        }

        private static int _enumerableCounter(this IEnumerable enumerable)
        {
            var count = 0;
            var enumerator = enumerable.GetEnumerator();
            while(enumerator.MoveNext())
            {
                count++;
            }

            return count;
        }
    }
}
