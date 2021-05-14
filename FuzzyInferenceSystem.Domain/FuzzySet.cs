using System;
using System.Collections.Generic;

namespace FuzzyInferenceSystem.Domain
{
  public class FuzzySet<TDomainValue>
  {
    private readonly List<TDomainValue> _domain = new();

    private readonly List<double> _gradesOfMembership = new();

    public Guid Id { get; private set; } = Guid.Empty;

    public string LinguisticValue { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public IEnumerable<TDomainValue> Domain => _domain;

    public IEnumerable<double> GradesOfMembership => _gradesOfMembership;
  }
}
