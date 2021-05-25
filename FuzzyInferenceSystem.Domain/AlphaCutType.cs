using FuzzyInferenceSystem.SeedWork.DDD;

namespace FuzzyInferenceSystem.Domain
{
  public abstract class AlphaCutType : Enumeration
  {
    public static AlphaCutType Strong { get; } = new StrongType();
    public static AlphaCutType Weak { get; } = new WeakType();

    private AlphaCutType(int value, string displayName) : base(value, displayName)
    {
    }

    public abstract bool IsAboveAlphaCut(double degreeOfMembership, double alphaValue);

    private class StrongType : AlphaCutType
    {
      public StrongType() : base(0, "Strong Alpha Cut")
      {
      }

      public override bool IsAboveAlphaCut(double degreeOfMembership, double alphaValue) => degreeOfMembership > alphaValue;
    }

    private class WeakType : AlphaCutType
    {
      public WeakType() : base(1, "Weak Alpha Cut")
      {
      }

      public override bool IsAboveAlphaCut(double degreeOfMembership, double alphaValue) => degreeOfMembership >= alphaValue;
    }
  }
}
