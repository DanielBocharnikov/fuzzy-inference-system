using System;
using System.Collections.Generic;

using FuzzyInferenceSystem.SeedWork;

namespace FuzzyInferenceSystem.Domain
{
  public sealed class TriangleFunction : ValueObject, IMembershipFunction
  {
    public double LeftEdge { get; init; }

    public double Center { get; init; }

    public double RightEdge { get; init; }

    public static TriangleFunction Create(double leftEdge, double center, double rightEdge)
    {
      if (leftEdge > rightEdge || rightEdge < leftEdge)
      {
        throw new ArgumentException(
          "Left edge must be less than right edge. " +
          $"Current values: left edge = {leftEdge}, right edge = {rightEdge}.");
      }

      if (center < leftEdge || center > rightEdge)
      {
        throw new ArgumentOutOfRangeException(nameof(center),
          "The center must be greater or equal to left edge and less or equal to right edge. " +
          $"Current values: left edge = {leftEdge}, center = {center}, right edge = {rightEdge}.");
      }

      return new TriangleFunction(leftEdge, center, rightEdge);
    }

    private TriangleFunction(double leftEdge, double center, double rightEdge) => (LeftEdge, Center, RightEdge) = (leftEdge, center, rightEdge);

    public double MapDegreeOfMembershipFor(double domainValue)
    {
      if (Center == LeftEdge)
      {
        return Math.Max((RightEdge - domainValue) / (RightEdge - Center), 0);
      }

      if (Center == RightEdge)
      {
        return Math.Max((domainValue - LeftEdge) / (Center - LeftEdge), 0);
      }

      if ((Center - LeftEdge) == (RightEdge - Center))
      {
        double distanceFromCenter = RightEdge - Center;
        int logicalValue = (domainValue >= LeftEdge && domainValue < RightEdge) ? 1 : 0;
        return logicalValue * (distanceFromCenter - Math.Abs(domainValue - Center)) / distanceFromCenter;
      }

      double grade = Math.Max(Math.Min((domainValue - LeftEdge) / (Center - LeftEdge), (RightEdge - domainValue) / (RightEdge - Center)), 0);
      return Math.Round(grade, 2);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
      yield return LeftEdge;
      yield return Center;
      yield return RightEdge;
    }
  }
}
