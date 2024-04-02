using System;

namespace PowerUtils.Results
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public interface IProperty<out TValue>
    {
        TValue Value { get; }

        string Name { get; }
    }

#if NET6_0_OR_GREATER
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public readonly record struct Property<TValue> : IProperty<TValue>
#else
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public readonly struct Property<TValue> : IProperty<TValue>
#endif
    {
        public TValue Value { get; private init; }

        public string Name { get; private init; }
        public Property(TValue value, string name)
        {
            Value = value;
            Name = name;
        }
    }
}
