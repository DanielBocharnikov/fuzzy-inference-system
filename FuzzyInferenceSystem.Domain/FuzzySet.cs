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

    public FuzzySet<T> ToEmpty()
  => throw new NotImplementedException();

    public bool IsEmpty()
      => !_mapping.Any(element => element.degreeOfMembership > 0);

    public bool IsUniversal()
      => !_mapping.Any(element => element.degreeOfMembership < 1);

    public bool IsNormal()
      => _mapping.Any(element => element.degreeOfMembership == 1)
      && _mapping.Any(element => element.degreeOfMembership == 0);

    private List<(double degreeOfMembership, T domainElement)> _mapping = new();
  }
}
