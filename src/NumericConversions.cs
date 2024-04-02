using System;

namespace PowerUtils.Results
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public static class NumericConversions
    {
        /// <summary>
        /// Try to convert the <paramref name="validatable.Value"/> to a specific type
        /// </summary>
        public static IValidatable<TValue> ToNumber<TValue>(this IValidatable<string> validatable)
            => validatable.ToNumber<TValue>(out var _);

        /// <summary>
        /// Try to convert the <paramref name="validatable.Value"/> to a specific type
        /// </summary>
        public static IValidatable<TValue> ToNumber<TValue>(this IValidatable<string> validatable, out TValue result)
        {
            var type = Type.GetTypeCode(typeof(TValue));
            switch(type)
            {
                case TypeCode.Single:

                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:

                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:

                case TypeCode.Double:
                case TypeCode.Decimal:
                    try
                    {
                        result = (TValue)Convert.ChangeType(validatable.Value, typeof(TValue));

                        return new Validatable<TValue>(
                            result,
                            validatable.Name,
                            validatable.Errors
                        );
                    }
                    catch
                    {
                        result = default;
                        var convertible = new Validatable<TValue>(
                            result,
                            validatable.Name,
                            validatable.Errors
                        );

                        convertible.AddError(
                            Error.Validation(
                                convertible.Name,
                                ResultErrorCodes.INVALID,
                                $"The '{validatable.Name}' is an invalid"
                            )
                        );

                        return convertible;
                    }

                default:
                    throw new InvalidCastException($"Invalid type '{type}'");
            }
        }
    }
}
