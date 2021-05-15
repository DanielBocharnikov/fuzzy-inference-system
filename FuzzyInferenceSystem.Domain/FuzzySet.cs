using System;
using System.Collections.Generic;
using System.Linq;

namespace FuzzyInferenceSystem.Domain
{
  public class FuzzySet<T> where T : notnull
  {
    public string LinguisticValue { get; private set; }

    public string Description { get; private set; }

    public int Power { get; private set; }

    public FuzzySet<T> ApplyAlphaCut(double value)
      => throw new NotImplementedException();

    public FuzzySet<T> ToUniversal()
      => throw new NotImplementedException();

    public bool IsEmpty()
      => _mapping.Count == 0
      || !_mapping.Any(element => element.degreeOfMembership > 0);

    private List<(double degreeOfMembership, T domainElement)> _mapping = new();
  }
}
