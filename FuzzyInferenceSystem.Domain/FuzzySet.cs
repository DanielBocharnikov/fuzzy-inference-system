using System;
using System.Collections.Generic;
using System.Linq;

namespace FuzzyInferenceSystem.Domain
{
  public class FuzzySet<T> where T : notnull
  {
    public static FuzzySet<T> CreateFromMembershipFunction(
      string linguisticValue,
      string description,
      IReadOnlyList<T> domain,
      IMembershipFunction membershipFunction)
    {
      if (domain.Count == 0)
      {
        throw new ArgumentException("The domain collection cannot be empty.", nameof(domain));
      }

      IEnumerable<double> degreesOfMembership = domain.Select(element => membershipFunction.MapDegreeOfMembershipFor(element));

      IEnumerable<(T, double)> mapping = domain.Zip(degreesOfMembership);

      return new FuzzySet<T>(linguisticValue, description, mapping);
    }

    public static FuzzySet<T> CreateFromDiscreteRepresentation(
      string linguisticValue,
      string description,
      IReadOnlyList<T> domain,
      IReadOnlyList<double> degreesOfMemberships)
    {
      if (domain.Count == 0)
      {
        throw new ArgumentException("The domain collection cannot be empty.", nameof(domain));
      }

      if (domain.Count != degreesOfMemberships.Count)
      {
        throw new ArgumentException("The domain and degrees of membership collections should have equal count of elements.", nameof(domain));
      }

      IEnumerable<(T, double)> mapping = domain.Zip(degreesOfMemberships);

      return new FuzzySet<T>(linguisticValue, description, mapping);
    }

    public string LinguisticValue { get; private set; }

    public string Description { get; private set; }

    public int Power { get; private set; }

    public double Height { get; private set; }

    public FuzzySet<T> ApplyAlphaCutAt(double value, AlphaCutType alphaCutType) => throw new NotImplementedException();

    public enum AlphaCutType
    {
      Strong,
      Weak
    }

    public FuzzySet<T> Normalize()
      => throw new NotImplementedException();

    public bool IsEmpty()
      => !_mapping.Any(element => element.degreeOfMembership > .0);

    public bool IsUniversal()
      => !_mapping.Any(element => element.degreeOfMembership < 1.0);

    public bool IsInMaximumNormalForm()
      => _mapping.Any(element => element.degreeOfMembership == 1.0)
      && _mapping.Any(element => element.degreeOfMembership == .0);

    public bool IsInMinimumNormalForm()
      => _mapping.Any(element => element.degreeOfMembership == 1.0);

    internal FuzzySet(string linguisticValue, string description, IEnumerable<(T, double)> mapping)
    {
      (LinguisticValue, Description, _mapping) = (linguisticValue, description, mapping.ToList());
    }

    private readonly List<(T domainElement, double degreeOfMembership)> _mapping;
  }
}