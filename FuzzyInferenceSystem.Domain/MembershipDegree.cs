using System;
using System.Collections.Generic;

using FuzzyInferenceSystem.SeedWork.DDD;

namespace FuzzyInferenceSystem.Domain
{
  public class MembershipDegree : ValueObject
  {
    public double Value { get; }

    public static MembershipDegree For(double value)
    {
      if (value is < 0 or > 1)
      {
        throw new ArgumentException(
          "Degree of membership cannot be greater than one and less than zero.",
          nameof(value));
      }

      return new MembershipDegree(value);
    }

    internal MembershipDegree(double value) => Value = value;

    public static implicit operator double(MembershipDegree self) => self.Value;

    public static implicit operator MembershipDegree(double value) => new(value);

    public override string ToString() => Value.ToString();

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
