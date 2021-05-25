using System;
using System.Collections.Generic;

namespace FuzzyInferenceSystem.Domain
{
  public abstract class UniverseOfDiscourse
  {
    public static UniverseOfDiscourse<T> From<T>(IReadOnlyList<T> values, Units units)
    {
      if (values == default)
      {
        throw new ArgumentNullException(nameof(values));
      }

      if (values.Count == 0)
      {
        throw new ArgumentException("The universe of discourse is cannot be empty.", nameof(values));
      }

      if (units == default)
      {
        throw new ArgumentNullException(nameof(units));
      }

      return new UniverseOfDiscourse<T>(values, units);
    }
  }

  public class UniverseOfDiscourse<T> : UniverseOfDiscourse
  {
    private readonly List<T> _elements = new();

    public IReadOnlyList<T> Elements => _elements;

    public Units Units { get; private set; }

    internal UniverseOfDiscourse(IEnumerable<T> elements, Units units) => _elements.AddRange(elements);
    {

    }
}
}
