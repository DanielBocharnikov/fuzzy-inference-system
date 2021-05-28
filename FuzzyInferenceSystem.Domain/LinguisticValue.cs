using System.Collections.Generic;

namespace FuzzyInferenceSystem.Domain
{
  public class LinguisticValue
  {
    private List<DegreeOfMembership> _referenceDegreesOfMemberships;

    public ConceptName Name { get; private set; }

    public ConceptDescription Description { get; private set; }

    public IReadOnlyList<DegreeOfMembership> ReferenceDegreesOfMembership => _referenceDegreesOfMemberships;


  }
}
