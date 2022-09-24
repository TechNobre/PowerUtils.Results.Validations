namespace PowerUtils.Results
{
    public interface IProperty<out TValue>
    {
        TValue Value { get; }

        string Name { get; }
    }

#if NET6_0_OR_GREATER
    public readonly record struct Property<TValue> : IProperty<TValue>
#else
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
