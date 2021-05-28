using System;
using System.Collections.Generic;

using FuzzyInferenceSystem.SeedWork.DDD;
using FuzzyInferenceSystem.SeedWork.Extensions;

namespace FuzzyInferenceSystem.Domain
{
  public class ConceptDescription : ValueObject
  {
    public string Text { get; }

    public static ConceptDescription From(string text)
    {
      if (text.IsEmpty())
      {
        throw new ArgumentException(
          "The fuzzy concept description must be defined.",
          nameof(text));
      }

      return new ConceptDescription(text);
    }

    internal ConceptDescription(string text) => Text = text;

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return Text;
    }
  }
}
