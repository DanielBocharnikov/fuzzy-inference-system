using FuzzyInferenceSystem.Domain.FuzzyModel;

namespace FuzzyInferenceSystem.Domain
{
  public abstract class Term
  {
    public FuzzyConceptTitle Name { get; protected set; }

    public FuzzyConceptDescription Description { get; protected set; }
  }
}
