using System;
using System.Collections.Generic;

namespace FuzzyInferenceSystem.Domain
{
  public class FuzzySet<TValue>
  {
    private readonly List<TValue> _domain = new();
    private readonly List<double> _degreesOfMembership = new();

    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public IEnumerable<TValue> Domain => _domain;

    public IEnumerable<double> DegreesOfMembership => _degreesOfMembership;
  }
}
