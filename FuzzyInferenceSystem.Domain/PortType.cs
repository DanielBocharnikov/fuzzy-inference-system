using FuzzyInferenceSystem.SeedWork.DDD;

namespace FuzzyInferenceSystem.Domain
{
  public sealed class PortType : Enumeration
  {
    public static PortType Input { get; } = new PortType(0, "Model Input");

    public static PortType Output { get; } = new PortType(1, "Model Output");

    private PortType(int id, string name) : base(id, name)
    {
    }
  }
}
