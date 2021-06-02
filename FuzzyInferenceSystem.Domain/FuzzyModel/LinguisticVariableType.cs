using FuzzyInferenceSystem.SeedWork.DDD;

namespace FuzzyInferenceSystem.Domain.FuzzyModel
{
  public sealed class LinguisticVariableType : Enumeration
  {
    public static LinguisticVariableType TrueLinguistic { get; } = new LinguisticVariableType(0, "True linguistic");

    public static LinguisticVariableType Numeric { get; } = new LinguisticVariableType(1, "Numeric");

    private LinguisticVariableType(int id, string name) : base(id, name)
    {
    }
  }
}
