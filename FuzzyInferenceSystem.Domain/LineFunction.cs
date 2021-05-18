
using System;
using System.Collections.Generic;

using FuzzyInferenceSystem.SeedWork;

namespace FuzzyInferenceSystem.Domain
{
  public class LineFunction : ValueObject, IMembershipFunction
  {
    private readonly double _leftEdge;
    private readonly double _rightEdge;
    private readonly LineFunctionType _lineType;

    public static LineFunction Create(double leftEdge, double rightEdge, LineFunctionType lineType)
    {
      if (leftEdge >= rightEdge)
      {
        throw new ArgumentException("Left edge cannot be equal or be greater that right edge", nameof(leftEdge));
      }

      return new LineFunction(leftEdge, rightEdge, lineType);
    }

    internal LineFunction(double leftEdge, double rightEdge, LineFunctionType lineType)
      => (_leftEdge, _rightEdge, _lineType) = (leftEdge, rightEdge, lineType);

    public double MapDegreeOfMembershipFor(double domainValue)
    {
      if (domainValue <= _leftEdge)
      {
        return 0;
      }

      if (domainValue > _rightEdge)
      {
        return 1;
      }

      double calculatedDegreeOfMembership = (domainValue - _leftEdge) / (_rightEdge - _leftEdge);

      if (_lineType.Equals(LineFunctionType.Decreasing))
      {
        return 1 - calculatedDegreeOfMembership;
      }

      return calculatedDegreeOfMembership;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return _leftEdge;
      yield return _rightEdge;
      yield return _lineType;
    }
  }
}
