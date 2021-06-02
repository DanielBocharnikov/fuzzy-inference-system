using System;

namespace FuzzyInferenceSystem.Domain.Shared
{
  public static class DomainExceptions
  {
    public class InvalidEntityState : Exception
    {
      public InvalidEntityState(object entity, string message)
        : base($"Entity {entity.GetType().Name} state change rejected, {message}")
      {
      }
    }
  }
}
