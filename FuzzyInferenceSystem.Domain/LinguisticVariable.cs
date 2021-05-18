using System.Collections.Generic;

namespace FuzzyInferenceSystem.Domain
{
  public class LinguisticVariable<T> where T : notnull
  {
    private string _name;
    private List<IFuzzySet> _termSet = new();
    private List<T> _universeOfDiscourse;

  }
}
