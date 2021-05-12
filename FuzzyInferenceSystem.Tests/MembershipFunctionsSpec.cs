using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using FluentAssertions;
using FuzzyInferenceSystem.Domain;

namespace FuzzyInferenceSystem.Tests {
  public class MembershipFunctionsSpec {
    [Fact]
    public void TriangleMembershipFunction_with_correct_arguments_should_be_created() {
      Func<TriangleMembershipFunction> mfCreation = () => new TriangleMembershipFunction(leftEdge: 0, center: 5, rightEdge: 10);

      mfCreation.Should().NotThrow<ArgumentOutOfRangeException>();
      mfCreation.Should().NotThrow<ArgumentException>();

      var mf = mfCreation();
      mf.LeftEdge.Should().Be(0);
      mf.Center.Should().Be(5);
      mf.RightEdge.Should().Be(10);
    }

    [Fact]
    public void TriangleMemberShipFunction_Creation_with_center_out_of_range_should_throw_ArgumentOutOfRangeException() {
      Action act = () => _ = new TriangleMembershipFunction(leftEdge: 0, center: -5, rightEdge: 10);
      act.Should()
         .Throw<ArgumentOutOfRangeException>()
         .WithMessage(
          "The center must be greater or equal to left edge and less or equal to right edge. " +
          "Current values: left edge = 0, center = -5, right edge = 10. (Parameter 'center')");
    }

    [Fact]
    public void TriangleMemberShipFunction_Creation_with_wrong_left_or_right_edges_should_throw_ArgumentException() {
      Action act = () => _ = new TriangleMembershipFunction(leftEdge: 10, center: 5, rightEdge: 0);
      act.Should()
         .Throw<ArgumentException>()
         .WithMessage(
          "Left edge must be less than right edge. " +
          "Current values: left edge = 10, right edge = 0.");
      act = () => _ = new TriangleMembershipFunction(leftEdge: 0, center: -2, rightEdge: -5);
      act.Should()
         .Throw<ArgumentException>()
         .WithMessage(
          "Left edge must be less than right edge. " +
          "Current values: left edge = 0, right edge = -5.");
    }

    [Fact]
    public void TriangleMembershipFunctions_with_same_parameters_should_be_equal() {
      TriangleMembershipFunction firstMF = new(leftEdge: 0, center: 5, rightEdge: 10);
      TriangleMembershipFunction secondMF = new(leftEdge: 0, center: 5, rightEdge: 10);

      firstMF.Should().Be(secondMF);
      firstMF.Should().NotBeSameAs(secondMF);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(7)]
    [InlineData(8)]
    [InlineData(9)]
    [InlineData(10)]
    public void TriangleMembershipFunction_with_same_parameters_should_give_same_domain_values_grades(double domainValue) {
      TriangleMembershipFunction firstMF = new(leftEdge: 0, center: 50, rightEdge: 100);
      TriangleMembershipFunction secondMF = new(leftEdge: 0, center: 50, rightEdge: 100);
      firstMF.GetDegreeOfMembershipFor(domainValue).Should().Be(secondMF.GetDegreeOfMembershipFor(domainValue));
    }
  }
}
