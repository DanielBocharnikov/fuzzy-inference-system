
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
      return _lineType.MapDegreeOfMembershipFor(domainValue, _leftEdge, _rightEdge);
    }

    public abstract class LineFunctionType : Enumeration
    {
      public static readonly LineFunctionType Increasing = new IncreasingLineFunctionType();
      public static readonly LineFunctionType Decreasing = new DecreasingLineFunctionType();

      private LineFunctionType(int value, string displayName) : base(value, displayName)
      {
      }

      public abstract double MapDegreeOfMembershipFor(double domainValue, double leftEdge, double rightEdge);

      private class IncreasingLineFunctionType : LineFunctionType
      {
        public IncreasingLineFunctionType() : base(0, "Increasing")
        {
        }

        public override double MapDegreeOfMembershipFor(double domainValue, double leftEdge, double rightEdge)
        {
          if (domainValue <= leftEdge)
          {
            return 0;
          }

          if (domainValue > rightEdge)
          {
            return 1;
          }

          return (domainValue - leftEdge) / (rightEdge - leftEdge);
        }
      }

      private class DecreasingLineFunctionType : LineFunctionType
      {
        public DecreasingLineFunctionType() : base(1, "Decreasing")
        {
        }

        public override double MapDegreeOfMembershipFor(double domainValue, double leftEdge, double rightEdge)
          => 1 - Increasing.MapDegreeOfMembershipFor(domainValue, leftEdge, rightEdge);
      }
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return _leftEdge;
      yield return _rightEdge;
      yield return _lineType;
    }
  }
}
