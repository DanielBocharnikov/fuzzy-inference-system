using System;

namespace FuzzyInferenceSystem.Domain.FuzzyModel
{
  public static class Events
  {
    public record FuzzyModelCreated(Guid Id, Guid OwnerId);

    public record FuzzyModelTitleChanged(Guid Id, string Title);

    public record FuzzyModelDescriptionUpdated(Guid Id, string Text);

    public record LinguisticVariableAddedToFuzzyModel(
      Guid ModelId,
      Guid LinguisticVariableId,
      string Title,
      string Description,
      string LinguisticVariableType,
      string PortType);
  }
}
