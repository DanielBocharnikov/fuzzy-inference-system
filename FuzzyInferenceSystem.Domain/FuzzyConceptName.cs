using System;
using System.Collections.Generic;

using FuzzyInferenceSystem.SeedWork.DDD;
using FuzzyInferenceSystem.SeedWork.Extensions;

namespace FuzzyInferenceSystem.Domain
{
  public class FuzzyConceptName : ValueObject
  {
    public string Value { get; }

    internal FuzzyConceptName(string value) => Value = value;

    public static FuzzyConceptName From(string name)
    {
      if (name.IsEmpty())
      {
        throw new ArgumentException("The name of fuzzy concept must be defined.", nameof(name));
      }

      return new FuzzyConceptName(name);
    }

    public static implicit operator string(FuzzyConceptName fuzzyConceptName)
      => fuzzyConceptName.Value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
