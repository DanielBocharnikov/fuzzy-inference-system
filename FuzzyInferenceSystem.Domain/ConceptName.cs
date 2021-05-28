using System;
using System.Collections.Generic;

using FuzzyInferenceSystem.SeedWork.DDD;
using FuzzyInferenceSystem.SeedWork.Extensions;

namespace FuzzyInferenceSystem.Domain
{
  public class ConceptName : ValueObject
  {
    public string Value { get; }

    internal ConceptName(string value) => Value = value;

    public static ConceptName From(string name)
    {
      if (name.IsEmpty())
      {
        throw new ArgumentException("The name of fuzzy concept must be defined.", nameof(name));
      }

      return new ConceptName(name);
    }

    public static implicit operator string(ConceptName fuzzyConceptName)
      => fuzzyConceptName.Value;

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Value;
    }
  }
}
