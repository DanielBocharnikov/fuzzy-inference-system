namespace FuzzyInferenceSystem.Domain
{
  public class FuzzyVariable
  {
    public FuzzyConceptName Name { get; private set; }

    public FuzzyConceptDescription Description { get; private set; }

    public DegreeOfMembership ReferenceDegreeOfMembership { get; private set; }

    public static FuzzyVariable CombinedOf(FuzzyConceptName name, FuzzyConceptDescription description, DegreeOfMembership referenceDegreeOfMembership)
    {

    }

    internal FuzzyVariable(FuzzyConceptName name, FuzzyConceptDescription description, DegreeOfMembership referenceDegreeOfMembership)
      => (Name, Description, ReferenceDegreeOfMembership) = (name, description, referenceDegreeOfMembership);
  }
}