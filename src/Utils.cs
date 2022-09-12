using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PowerUtils.Results
{
    public static class Utils
    {
        /// <summary>
        /// Creates a new <see cref="IValidatable{TValue}"/> instance with the specified value.
        /// The <see cref="IValidatable{TValue}"/> instance can be used to generare an erro if the value matches a condition specified.
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="errors">List of errors to use as a reference</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IValidatable<TValue> Validate<TValue>(
            this TValue value,
            List<IError> errors,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => new Validatable<TValue>(value, propertyName, errors);

        /// <summary>
        /// Creates a new <see cref="IValidatable{TValue}"/> instance with the specified value.
        /// The <see cref="IValidatable{TValue}"/> instance can be used to generare an erro if the value matches a condition specified.
        /// </summary>
        /// <param name="value">Value to validate</param>
        /// <param name="propertyName">If not defined, the name of the variable passed by the <paramref name="value"/> property will be used</param>
        public static IValidatable<TValue> Validate<TValue>(
            this TValue value,
            [CallerArgumentExpression("value")] string propertyName = null
        ) => Validate(value, new(), propertyName);
    }
}
