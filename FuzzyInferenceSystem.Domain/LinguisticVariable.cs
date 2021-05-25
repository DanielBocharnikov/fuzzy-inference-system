using System;
using System.Collections.Generic;

using FuzzyInferenceSystem.SeedWork.DDD;

namespace FuzzyInferenceSystem.Domain
{
  public class LinguisticVariable : Entity<LinguisticVariableId>
  {
    public FuzzySystemId SystemId { get; private set; }

    public FuzzyConceptName Name { get; private set; }

    public FuzzyConceptDescription Description { get; private set; }

    public IReadOnlyList<FuzzyVariable> TermSet { get; private set; } = new List<FuzzyVariable>();

    public LinguisticVariable(Action<object> applier) : base(applier)
    {
    }

    protected override void When(object @event)
    {
    }
  }
}
