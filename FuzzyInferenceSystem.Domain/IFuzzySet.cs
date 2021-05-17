namespace FuzzyInferenceSystem.Domain
{
  public interface IFuzzySet
  {
    IFuzzySet ApplyIntersectionWith(IFuzzySet other);
    IFuzzySet ApplyUnionWith(IFuzzySet other);
    IFuzzySet ApplyComplement();
  }
}
