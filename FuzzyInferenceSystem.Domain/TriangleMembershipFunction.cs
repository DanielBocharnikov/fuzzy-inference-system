using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FuzzyInferenceSystem.SeedWork;

namespace FuzzyInferenceSystem.Domain {
  public class TriangleMembershipFunction:ValueObject,IMembershipFunction {
    public double LeftEdge { get; init; }

    public double Center { get; init; }

    public double RightEdge { get; init; }

    public TriangleMembershipFunction(double leftEdge, double center, double rightEdge) {
      if (leftEdge > rightEdge || rightEdge < leftEdge) {
        throw new ArgumentException(
          "Left edge must be less than right edge. " +
          $"Current values: left edge = {leftEdge}, right edge = {rightEdge}.");
      }

      if (center < leftEdge || center > rightEdge) {
        throw new ArgumentOutOfRangeException(nameof(center),
          "The center must be greater or equal to left edge and less or equal to right edge. " +
          $"Current values: left edge = {leftEdge}, center = {center}, right edge = {rightEdge}.");
      }


      (LeftEdge, Center, RightEdge) = (leftEdge, center, rightEdge);
    }

    public double GetDegreeOfMembershipFor(double domainValue) {
      if (Center == LeftEdge) {
        return Math.Max((RightEdge - domainValue) / (RightEdge - Center), 0);
      } else if (Center == RightEdge) {
        return Math.Max((domainValue - LeftEdge) / (Center - LeftEdge), 0);
      } else {
        return Math.Max(Math.Min((domainValue - LeftEdge) / (Center - LeftEdge), (RightEdge - domainValue) / (RightEdge - Center)), 0);
      }
    }

    protected override IEnumerable<object> GetEqualityComponents() {
       yield return LeftEdge;
       yield return Center;
       yield return RightEdge;
    }
  }
}
