using FuzzyInferenceSystem.SeedWork;

namespace FuzzyInferenceSystem.Domain
{
  public class AlphaCutType : Enumeration
  {
    public static AlphaCutType Strong = new(1, nameof(Strong));
    public static AlphaCutType Weak = new(2, nameof(Weak));

    public AlphaCutType(int id, string name) : base(id, name)
    {
    }
  }
}
