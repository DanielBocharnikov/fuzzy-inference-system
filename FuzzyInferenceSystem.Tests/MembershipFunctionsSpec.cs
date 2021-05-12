using System;
using System.Linq;

using FluentAssertions;

using FuzzyInferenceSystem.Domain;

using Xunit;

namespace FuzzyInferenceSystem.Tests
{
  public class MembershipFunctionsSpec
  {
    private readonly TriangleMembershipFunction _firstTriangleMembership
      = new(leftEdge: -6, center: -1, rightEdge: 4);
    private readonly TriangleMembershipFunction _secondTriangleMembership
      = new(leftEdge: -6, center: -1, rightEdge: 4);

    [Fact]
    public void TriangleMembershipFunction_with_correct_arguments_should_be_created()
    {
      Func<TriangleMembershipFunction> mfCreation = () => new TriangleMembershipFunction(leftEdge: -6, center: -1, rightEdge: 4);

      mfCreation.Should().NotThrow<ArgumentOutOfRangeException>();
      mfCreation.Should().NotThrow<ArgumentException>();

      TriangleMembershipFunction mf = mfCreation();
      mf.LeftEdge.Should().Be(-6);
      mf.Center.Should().Be(-1);
      mf.RightEdge.Should().Be(4);
    }

    [Fact]
    public void TriangleMemberShipFunction_Creation_with_center_out_of_range_should_throw_ArgumentOutOfRangeException()
    {
      Action act = () => _ = new TriangleMembershipFunction(leftEdge: 0, center: -5, rightEdge: 10);
      act.Should()
         .Throw<ArgumentOutOfRangeException>()
         .WithMessage(
          "The center must be greater or equal to left edge and less or equal to right edge. " +
          "Current values: left edge = 0, center = -5, right edge = 10. (Parameter 'center')");
    }

    [Fact]
    public void TriangleMemberShipFunction_Creation_with_wrong_left_or_right_edges_should_throw_ArgumentException()
    {
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
    public void TriangleMembershipFunctions_with_same_parameters_should_be_equal()
    {
      _firstTriangleMembership.Should().Be(_secondTriangleMembership);
      _secondTriangleMembership.Should().NotBeSameAs(_firstTriangleMembership);
    }

    [Theory]
    [InlineData(-6)]
    [InlineData(-5)]
    [InlineData(-4)]
    [InlineData(-3)]
    [InlineData(-2)]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(4)]
    public void TriangleMembershipFunction_with_same_parameters_should_return_same_grades(double domainValue)
    {
      _firstTriangleMembership.GetDegreeOfMembershipFor(domainValue)
        .Should()
        .Be(_secondTriangleMembership.GetDegreeOfMembershipFor(domainValue));
      _firstTriangleMembership.Should().NotBeSameAs(_secondTriangleMembership);
    }

    [Fact]
    public void TriangleMembershipFunction_GetDegreeOfMemberShipFor_domain_values_should_return_expected_grades()
    {
      var actualInputDomainValues = new[] { -6.0, -5.0, -4.0, -3.0, -2.0, -1.0, .0, 1.0, 2.0, 3.0, 4.0 };
      var expectedGradesWhenCenterEqualsLeftEdge = new[] { 1.0, .9, .8, .7, .6, .5, .4, .3, .2, .1, .0 };
      var expectedGradesWhenCenterEqualsRightEdge = new[] { .0, .1, .2, .3, .4, .5, .6, .7, .8, .9, 1.0 };
      var expectedGradesWhenMembershipIsSymmetricTriangle = new[] { .0, .2, .4, .6, .8, 1, .8, .6, .4, .2, .0 };
      var expectedGradesWhenMembershipIsAsymmetricTriangle = new[] { .0, .17, .33, .5, .67, .83, 1.0, .75, .5, .25, .0 };

      actualInputDomainValues
        .Select(x => new TriangleMembershipFunction(-6, -6, 4).GetDegreeOfMembershipFor(x))
        .Should().Equal(expectedGradesWhenCenterEqualsLeftEdge);

      actualInputDomainValues
        .Select(x => new TriangleMembershipFunction(-6, 4, 4).GetDegreeOfMembershipFor(x))
        .Should().Equal(expectedGradesWhenCenterEqualsRightEdge);

      actualInputDomainValues
        .Select(x => new TriangleMembershipFunction(-6, -1, 4).GetDegreeOfMembershipFor(x))
        .Should().Equal(expectedGradesWhenMembershipIsSymmetricTriangle);

      actualInputDomainValues
        .Select(x => new TriangleMembershipFunction(-6, 0, 4).GetDegreeOfMembershipFor(x))
        .Should().Equal(expectedGradesWhenMembershipIsAsymmetricTriangle);
    }
  }
}
