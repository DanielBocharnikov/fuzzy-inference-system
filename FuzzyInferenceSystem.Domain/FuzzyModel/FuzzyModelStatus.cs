using FuzzyInferenceSystem.SeedWork.DDD;

namespace FuzzyInferenceSystem.Domain.FuzzyModel
{
  public sealed class FuzzyModelStatus : Enumeration
  {
    public static FuzzyModelStatus Inactive { get; } = new FuzzyModelStatus(0, "Inactive");

    public static FuzzyModelStatus Active { get; } = new FuzzyModelStatus(1, "Active");

    private FuzzyModelStatus(int id, string name) : base(id, name)
    {
    }
  }
}
