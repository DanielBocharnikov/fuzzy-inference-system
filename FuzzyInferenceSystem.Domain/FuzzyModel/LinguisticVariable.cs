using System;
using System.Collections.Generic;

using FuzzyInferenceSystem.SeedWork.DDD;

namespace FuzzyInferenceSystem.Domain.FuzzyModel
{
  public class LinguisticVariable : Entity<LinguisticVariableId>
  {
    public FuzzyModelId ModelId { get; private set; }

    public FuzzyConceptTitle Title { get; private set; }

    public FuzzyConceptDescription Description { get; private set; }

    public PortType PortType { get; private set; }

    public IReadOnlyList<Term> TermSet { get; private set; }

    public LinguisticVariable(Action<object> applier) : base(applier)
    {
    }

    protected override void When(object @event)
    {
      switch (@event)
      {
        case Events.LinguisticVariableAddedToFuzzyModel e:
          Id = new(e.LinguisticVariableId);
          ModelId = new(e.ModelId);
          Title = new(e.Title);
          Description = new(e.Description);
          PortType = Enumeration.FromDisplayName<PortType>(e.PortType);
          break;
      }
    }
  }
}
