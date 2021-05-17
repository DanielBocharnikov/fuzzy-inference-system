using System.Collections.Generic;

namespace FuzzyInferenceSystem.Domain
{
  public class LinguisticVariable<T> where T : notnull
  {
    private string _name;
    private List<FuzzySet<T>> _termSet = new();
    private List<T> _universeOfDiscourse;

    public void Do()
    {
      var fs = FuzzySet<double>.CreateFrom(
        "Cold",
        "Its temperature",
        new List<double> { .0, .1, .2 },
        TriangleMembershipFunction.Create(.0, .1, .2));

      var fs1 = FuzzySet<string>.CreateFrom(
        "Good Students",
        "About Students",
        new List<string> { "Bob", "Joe", "Alex" },
        new List<double> { .0, .1, .2 });
    }
  }
}
