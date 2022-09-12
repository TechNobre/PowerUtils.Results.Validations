using System.Collections;
using System.Runtime.CompilerServices;

namespace PowerUtils.Results
{
    public static class CollectionValidations
    {
        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is empty. Error code 'REQUIRED'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfEmpty<TValue>(
            this TValue value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : IEnumerable
        {
            if(value == null)
            {
                return null;
            }

            if(value._itemCounter() == 0)
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
        public static IValidatable<TValue> IfEmpty<TValue>(this IValidatable<TValue> validatable)
            where TValue : IEnumerable
            => validatable.Validator(property => property.Value.IfEmpty(property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> is null or empty. Error code 'REQUIRED'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfNullOrEmpty<TValue>(
            this TValue value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : IEnumerable
        {
            if(value is null || value._itemCounter() == 0)
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
        public static IValidatable<TValue> IfNullOrEmpty<TValue>(this IValidatable<TValue> validatable)
            where TValue : IEnumerable
            => validatable.Validator(property => property.Value.IfNullOrEmpty(property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> contains a number of items greater than. Error code 'MAX:{X}'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="max">Maximum number of items in the collection</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfCountGreaterThan<TValue>(
            this TValue value,
            int max,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : IEnumerable
        {
            if(value == null)
            {
                return null;
            }

            if(value._itemCounter() > max)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.CreateMax(max),
                    $"The '{propertyName}' contains a lot of items. The maximum is {max}"
                );
            }

            return null;
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> contains a number of items greater than. Error code 'MAX:{X}' in error list
        /// </summary>
        public static IValidatable<TValue> IfCountGreaterThan<TValue>(
            this IValidatable<TValue> validatable,
            int max
        ) where TValue : IEnumerable
            => validatable.Validator(property => property.Value.IfCountGreaterThan(max, property.Name));



        /// <summary>
        /// Returns an <see cref="IError" /> if <paramref name="value"/> contains a number of items less than. Error code 'MIN:{X}'
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="min">Minimum of items in the list</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IError IfCountLessThan<TValue>(
            this TValue value,
            int min,
            [CallerArgumentExpression("value")] string propertyName = null
        ) where TValue : IEnumerable
        {
            if(value == null)
            {
                return null;
            }

            if(value._itemCounter() < min)
            {
                return Error.Validation(
                    propertyName,
                    ErrorCodes.CreateMin(min),
                    $"The '{propertyName}' contains few items. The minimum is {min}"
                );
            }

            return null;
        }

        /// <summary>
        /// Validates if <paramref name="validatable.Value"/> contains a number of items less than. Error code 'MIN:{X}' in error list
        /// </summary>
        public static IValidatable<TValue> IfCountLessThan<TValue>(
            this IValidatable<TValue> validatable,
            int min
        ) where TValue : IEnumerable
            => validatable.Validator(property => property.Value.IfCountLessThan(min, property.Name));



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
