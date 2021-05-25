namespace FuzzyInferenceSystem.SeedWork.Extensions
{
  public static class StringTools
  {
    public static bool IsEmpty(this string value)
      => string.IsNullOrWhiteSpace(value);
  }
}
