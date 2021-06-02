using System;
using System.Collections.Generic;
using System.Linq;

using FuzzyInferenceSystem.Domain.Shared;
using FuzzyInferenceSystem.SeedWork.DDD;

namespace FuzzyInferenceSystem.Domain.FuzzyModel
{
  public class FuzzyModel : AggregateRoot<FuzzyModelId>
  {
    private List<LinguisticVariable> _ports = new();

    public UserId OwnerId { get; private set; }

    public FuzzyConceptTitle Title { get; private set; }

    public FuzzyConceptDescription Description { get; private set; }

    public FuzzyModelStatus Status { get; private set; }

    public IReadOnlyCollection<LinguisticVariable> Inputs
      => _ports
        .Where(lv => lv.PortType.Equals(PortType.Input))
        .ToList();

    public IReadOnlyCollection<LinguisticVariable> Outputs
      => _ports
        .Where(lv => lv.PortType.Equals(PortType.Output))
        .ToList();

    public FuzzyModel(UserId ownerId, FuzzyModelId modelId)
      => Apply(new Events.FuzzyModelCreated(modelId, ownerId));

    public void SetTitle(FuzzyConceptTitle title)
      => Apply(new Events.FuzzyModelTitleChanged(Id, title));

    public void UpdateDescription(FuzzyConceptDescription text)
      => Apply(new Events.FuzzyModelDescriptionUpdated(Id, text));

    public void AddLinguisticVariable(
      FuzzyConceptTitle title,
      FuzzyConceptDescription text,
      LinguisticVariableType type,
      PortType portType) => Apply(
        new Events.LinguisticVariableAddedToFuzzyModel(
          Id,
          Guid.NewGuid(),
          title,
          text,
          type.ToString(),
          portType.ToString()));

    protected override void When(object @event)
    {
      LinguisticVariable lv;

      switch (@event)
      {
        case Events.FuzzyModelCreated e:
          Id = new FuzzyModelId(e.Id);
          OwnerId = new UserId(e.OwnerId);
          Status = FuzzyModelStatus.Inactive;
          break;

        case Events.FuzzyModelTitleChanged e:
          Title = new FuzzyConceptTitle(e.Title);
          break;

        case Events.FuzzyModelDescriptionUpdated e:
          Description = new FuzzyConceptDescription(e.Text);
          break;

        case Events.LinguisticVariableAddedToFuzzyModel e:
          lv = new LinguisticVariable(Apply);
          break;
      }
    }

    protected override void EnsureValidState() => throw new NotImplementedException();
  }
}
