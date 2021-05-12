namespace FuzzyInferenceSystem.Domain
{
  public interface IMembershipFunction
  {
    double GetDegreeOfMembershipFor(double domainValue);
  }
}
