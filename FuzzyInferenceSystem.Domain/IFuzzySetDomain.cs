using System;
using System.Collections.Generic;
using System.Linq;

namespace FuzzyInferenceSystem.Domain
{
  public interface IFuzzySetDomain<in T>
  {
    int FindPlaceOf(T domainValue);
  }

  public class NumbericFuzzySetDomain : IFuzzySetDomain<double>
  {
    private readonly SortedSet<double> _domainSet = new();
    private readonly double _starts;
    private readonly double _ends;
    private readonly int _range;

    public NumbericFuzzySetDomain(double starts, double ends)
    {
      _starts = starts;
      _ends = ends;
      _range = (int)Math.Round(_ends - _starts);
    }

    public int FindPlaceOf(double domainValue)
    {
      return (int)Math.Round(_domainSet.Count * (domainValue - _domainSet.Min()) / _range);
    }
  }
}
