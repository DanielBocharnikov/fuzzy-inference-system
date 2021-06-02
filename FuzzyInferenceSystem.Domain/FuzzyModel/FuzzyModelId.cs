using System;
using System.Collections.Generic;

using FuzzyInferenceSystem.SeedWork.DDD;

namespace FuzzyInferenceSystem.Domain.FuzzyModel
{
  public class FuzzyModelId : ValueObject
  {
    public Guid Value { get; }

    public static FuzzyModelId For(Guid value)
      => value == default
        ? throw new ArgumentException(
            "The value of linguistic variable id must be defined.",
            nameof(value))
        : new FuzzyModelId(value);

    public static implicit operator FuzzyModelId(string value)
      => new(Guid.Parse(value));

    public static implicit operator Guid(FuzzyModelId self)
      => self.Value;

    public override string ToString() => Value.ToString();

    internal FuzzyModelId(Guid value) => Value = value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
