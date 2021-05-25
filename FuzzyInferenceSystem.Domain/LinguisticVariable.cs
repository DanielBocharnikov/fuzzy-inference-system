using System.Collections.Generic;

namespace FuzzyInferenceSystem.Domain
{
  public class LinguisticVariable
  {
    public FuzzyConceptName Name { get; private set; }

    public FuzzyConceptDescription Description { get; private set; }

    public IReadOnlyList<FuzzyVariable> TermSet { get; private set; } = new List<FuzzyVariable>();

    public UniverseOfDiscourse UniverseOfDiscourse { get; private set; }
  }
}
