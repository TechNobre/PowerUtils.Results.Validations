﻿using System;
using System.Collections.Generic;

namespace PowerUtils.Results
{
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public interface IValidatable<TValue> : IProperty<TValue>
    {
        IReadOnlyCollection<IError> Errors { get; }

        IValidatable<TValue> Validator(Func<IProperty<TValue>, IError> validation);

        void AddError(IError error);
    }

#if NET6_0_OR_GREATER
    [Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public readonly record struct Validatable<TValue> : IValidatable<TValue>
#else
[Obsolete("This package has been discontinued because it never evolved, and the code present in this package does not justify its continuation. It is preferable to implement this code directly in the project if necessary.")]
    public readonly struct Validatable<TValue> : IValidatable<TValue>
#endif
    {
        public TValue Value { get; private init; }

        public string Name { get; private init; }

        private readonly ICollection<IError> _errors;
        public IReadOnlyCollection<IError> Errors => _errors as IReadOnlyCollection<IError>;

        public Validatable(TValue value, string propertyName, IReadOnlyCollection<IError> errors)
        {
            Value = value;
            Name = propertyName;
            _errors = errors as ICollection<IError>;
        }

        public Validatable(TValue value, string propertyName, List<IError> errors)
        {
            Value = value;
            Name = propertyName;
            _errors = errors;
        }

        public IValidatable<TValue> Validator(Func<IProperty<TValue>, IError> validation)
        {
            AddError(validation(this));

            return this;
        }

        public void AddError(IError error)
        {
            if(error is not null)
            {
                _errors.Add(error);
            }
        }
    }
}
