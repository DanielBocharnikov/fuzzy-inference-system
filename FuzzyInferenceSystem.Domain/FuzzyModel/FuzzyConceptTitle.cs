using System;
using System.Collections.Generic;

using FuzzyInferenceSystem.SeedWork.DDD;
using FuzzyInferenceSystem.SeedWork.Extensions;

namespace FuzzyInferenceSystem.Domain.FuzzyModel
{
  public class FuzzyConceptTitle : ValueObject
  {
    public string Value { get; }

    internal FuzzyConceptTitle(string value) => Value = value;

    public static FuzzyConceptTitle From(string name)
    {
      if (name.IsEmpty())
      {
        throw new ArgumentException("The name of fuzzy concept must be defined.", nameof(name));
      }

      return new FuzzyConceptTitle(name);
    }

    public static implicit operator string(FuzzyConceptTitle fuzzyConceptName)
      => fuzzyConceptName.Value;

    public override string ToString() => Value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
