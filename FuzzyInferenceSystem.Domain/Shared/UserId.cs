using System;
using System.Collections.Generic;

using FuzzyInferenceSystem.SeedWork.DDD;

namespace FuzzyInferenceSystem.Domain.Shared
{
  public class UserId : ValueObject
  {
    public Guid Value { get; }

    public static UserId For(Guid value)
      => value == default
        ? throw new ArgumentException(
            "The value of linguistic variable id must be defined.",
            nameof(value))
        : new UserId(value);

    public static implicit operator UserId(string value)
      => new(Guid.Parse(value));

    public static implicit operator Guid(UserId self)
      => self.Value;

    public override string ToString() => Value.ToString();

    internal UserId(Guid value) => Value = value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
