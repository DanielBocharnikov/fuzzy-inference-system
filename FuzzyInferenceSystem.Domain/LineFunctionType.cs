using FuzzyInferenceSystem.SeedWork.DDD;

namespace FuzzyInferenceSystem.Domain
{
  public abstract class LineFunctionType : Enumeration
  {
    public static LineFunctionType Increasing { get; } = new IncreasingLine();
    public static LineFunctionType Decreasing { get; } = new DecreasingLine();

    private LineFunctionType(int id, string name) : base(id, name)
    {
    }

    private class IncreasingLine : LineFunctionType
    {
      public IncreasingLine() : base(0, "Increasing Line")
      {
      }
    }

    private class DecreasingLine : LineFunctionType
    {
      public DecreasingLine() : base(1, "Decreasing Line")
      {
      }
    }
  }
}
