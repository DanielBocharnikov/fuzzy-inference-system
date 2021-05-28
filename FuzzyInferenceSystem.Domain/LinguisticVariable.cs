using System;
using System.Collections.Generic;

using FuzzyInferenceSystem.SeedWork.DDD;

namespace FuzzyInferenceSystem.Domain
{
  public class LinguisticVariable : Entity<LinguisticVariableId>
  {
    public SystemId SystemId { get; private set; }

    public ConceptName Name { get; private set; }

    public ConceptDescription Description { get; private set; }

    public IReadOnlyList<LinguisticValue> TermSet { get; private set; } = new List<LinguisticValue>();

    public LinguisticVariable(Action<object> applier) : base(applier)
    {
    }

    protected override void When(object @event)
    {
    }
  }
}
