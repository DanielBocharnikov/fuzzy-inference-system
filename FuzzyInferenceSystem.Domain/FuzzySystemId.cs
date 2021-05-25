using System;
using System.Collections.Generic;

using FuzzyInferenceSystem.SeedWork.DDD;

namespace FuzzyInferenceSystem.Domain
{
  public class FuzzySystemId : ValueObject
  {
    public Guid Value { get; }

    public static FuzzySystemId For(Guid value)
      => value == default
        ? throw new ArgumentException(
          "The value of system id must be defined.",
          nameof(value))
        : new FuzzySystemId(value);

    public static implicit operator FuzzySystemId(string value)
      => new(Guid.Parse(value));

    public static implicit operator Guid(FuzzySystemId self)
      => self.Value;

    public override string ToString() => Value.ToString();

    internal FuzzySystemId(Guid value) => Value = value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}