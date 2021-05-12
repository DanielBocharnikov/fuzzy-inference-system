namespace FuzzyInferenceSystem.Domain
{
  public interface IMembershipFunction
  {
    double MapDegreeOfMembershipFor(double domainValue);
  }
}
