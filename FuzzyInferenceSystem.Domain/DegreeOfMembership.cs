using System;
using System.Collections.Generic;

using FuzzyInferenceSystem.SeedWork.DDD;

namespace FuzzyInferenceSystem.Domain
{
  public class DegreeOfMembership : ValueObject
  {
    public double Value { get; }

    public static DegreeOfMembership For(double value)
    {
      if (value is < 0 or > 1)
      {
        throw new ArgumentException(
          "Degree of membership cannot be greater than one and less than zero.",
          nameof(value));
      }

      return new DegreeOfMembership(value);
    }

    internal DegreeOfMembership(double value) => Value = value;

    public static implicit operator double(DegreeOfMembership self) => self.Value;

    public static implicit operator DegreeOfMembership(double value) => new(value);

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
