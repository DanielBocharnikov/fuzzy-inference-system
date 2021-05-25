using System;
using System.Collections.Generic;

using FuzzyInferenceSystem.SeedWork;
using FuzzyInferenceSystem.SeedWork.DDD;

namespace FuzzyInferenceSystem.Domain
{
  public class FuzzyConceptDescription : ValueObject
  {
    public string Text { get; }

    public static FuzzyConceptDescription From(string text)
    {
      if (text.IsEmpty())
      {
        throw new ArgumentException(
          "The fuzzy concept description must be defined.",
          nameof(text));
      }

      return new FuzzyConceptDescription(text);
    }

    internal FuzzyConceptDescription(string text) => Text = text;

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Text;
    }
  }
}
