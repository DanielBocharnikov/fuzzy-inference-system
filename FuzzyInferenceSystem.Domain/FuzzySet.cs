using System;
using System.Collections.Generic;
using System.Linq;

using FuzzyInferenceSystem.SeedWork.DDD;

namespace FuzzyInferenceSystem.Domain
{
  public static class FuzzySet
  {
    public static FuzzySet<T> CombinedOf<T>(ISet<T> domainValues, IReadOnlyCollection<MembershipDegree> membershipValues)
    {
      if (domainValues.Count is 0 || membershipValues.Count is 0)
      {
        throw new ArgumentException("Quantity of domain values and membership values must be greater than zero.");
      }

      if (domainValues.Count != membershipValues.Count)
      {
        throw new ArgumentException("Quantity of domain values and membership values must match.");
      }

      return new FuzzySet<T>(domainValues.Zip(membershipValues));
    }
  }

  public class FuzzySet<T> : ValueObject
  {
    private HashSet<(T domainValue, MembershipDegree degree)> _pairs;

    internal FuzzySet(IEnumerable<(T domainValue, MembershipDegree degree)> pairs)
      => _pairs = new(pairs);

    protected override IEnumerable<object> GetEqualityComponents()
    {
      foreach (var pair in _pairs)
      {
        yield return pair;
      }
    }


  }
}
