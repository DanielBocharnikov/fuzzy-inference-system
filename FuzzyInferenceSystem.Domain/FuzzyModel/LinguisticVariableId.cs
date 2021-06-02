using System;
using System.Collections.Generic;

using FuzzyInferenceSystem.SeedWork.DDD;

namespace FuzzyInferenceSystem.Domain.FuzzyModel
{
  public class LinguisticVariableId : ValueObject
  {
    public Guid Value { get; }

    public static LinguisticVariableId For(Guid value)
      => value == default
        ? throw new ArgumentException(
            "The value of linguistic variable id must be defined.",
            nameof(value))
        : new LinguisticVariableId(value);

    public static implicit operator LinguisticVariableId(string value)
      => new(Guid.Parse(value));

    public static implicit operator Guid(LinguisticVariableId self)
      => self.Value;

    public override string ToString() => Value.ToString();

    internal LinguisticVariableId(Guid value) => Value = value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}