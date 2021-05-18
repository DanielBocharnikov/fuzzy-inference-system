using System;
using System.Linq;

using FluentAssertions;

using FuzzyInferenceSystem.Domain;

using Xunit;

namespace FuzzyInferenceSystem.Tests
{
  public class TriangleMembershipFunctionsSpec
  {
    private readonly TriangleFunction _firstTriangleMembership
      = CreateTriangleWith(-6.0, -1.0, 4.0);
    private readonly TriangleFunction _secondTriangleMembership
      = CreateTriangleWith(-6.0, -1.0, 4.0);

    [Fact]
    public void With_correct_arguments_should_be_created()
    {
      Func<TriangleFunction> mfCreation = ()
        => CreateTriangleWith(-6.0, -1.0, 4.0);

      mfCreation.Should().NotThrow<ArgumentOutOfRangeException>();
      mfCreation.Should().NotThrow<ArgumentException>();

      TriangleFunction mf = mfCreation();
      mf.LeftEdge.Should().Be(-6.0);
      mf.Center.Should().Be(-1.0);
      mf.RightEdge.Should().Be(4.0);
    }

    [Fact]
    public void Creation_with_center_out_of_range_should_throw_ArgumentOutOfRangeException()
    {
      Action creation = () => _ = CreateTriangleWith(.0, -5.0, 10.0);

      creation.Should()
         .Throw<ArgumentOutOfRangeException>()
         .WithMessage(
          "The center must be greater or equal to left edge and less or equal to right edge. " +
          "Current values: left edge = 0, center = -5, right edge = 10. (Parameter 'center')");
    }

    [Fact]
    public void Creation_with_wrong_left_or_right_edges_should_throw_ArgumentException()
    {
      Action creation = () => _ = CreateTriangleWith(10.0, 5.0, 0.0);

      creation
        .Should()
        .Throw<ArgumentException>()
        .WithMessage(
          "Left edge must be less than right edge. " +
          "Current values: left edge = 10, right edge = 0.");

      creation = () => _ = CreateTriangleWith(.0, -2.0, -5.0);

      creation
        .Should()
        .Throw<ArgumentException>()
        .WithMessage(
          "Left edge must be less than right edge. " +
          "Current values: left edge = 0, right edge = -5.");
    }

    [Fact]
    public void Different_membership_functions_with_same_parameters_should_be_equal()
    {
      _firstTriangleMembership
        .Should()
        .Be(_secondTriangleMembership);

      _secondTriangleMembership
        .Should()
        .NotBeSameAs(_firstTriangleMembership);
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
    public void Different_membership_functions_with_same_parameters_should_return_same_grades(double domainValue)
    {
      _firstTriangleMembership
        .MapDegreeOfMembershipFor(domainValue)
        .Should()
        .Be(_secondTriangleMembership
          .MapDegreeOfMembershipFor(domainValue));

      _firstTriangleMembership
        .Should()
        .NotBeSameAs(_secondTriangleMembership);
    }

    [Fact]
    public void MapDegreeOfMemberShipFor_given_domain_values_should_return_expected_grades()
    {
      var actualInputDomainValues
        = new[] { -6.0, -5.0, -4.0, -3.0, -2.0, -1.0, .0, 1.0, 2.0, 3.0, 4.0 };
      var expectedGradesWhenCenterEqualsLeftEdge
        = new[] { 1.0, .9, .8, .7, .6, .5, .4, .3, .2, .1, .0 };
      var expectedGradesWhenCenterEqualsRightEdge
        = new[] { .0, .1, .2, .3, .4, .5, .6, .7, .8, .9, 1.0 };
      var expectedGradesWhenMembershipIsSymmetricTriangle
        = new[] { .0, .2, .4, .6, .8, 1, .8, .6, .4, .2, .0 };
      var expectedGradesWhenMembershipIsAsymmetricTriangle
        = new[] { .0, .17, .33, .5, .67, .83, 1.0, .75, .5, .25, .0 };

      actualInputDomainValues
        .Select(domainValue
          => CreateTriangleWith(-6.0, -6.0, 4.0)
            .MapDegreeOfMembershipFor(domainValue))
        .Should()
        .Equal(expectedGradesWhenCenterEqualsLeftEdge);

      actualInputDomainValues
        .Select(domainValue
          => CreateTriangleWith(-6.0, 4.0, 4.0)
            .MapDegreeOfMembershipFor(domainValue))
        .Should()
        .Equal(expectedGradesWhenCenterEqualsRightEdge);

      actualInputDomainValues
        .Select(domainValue
          => CreateTriangleWith(-6.0, -1.0, 4.0)
            .MapDegreeOfMembershipFor(domainValue))
        .Should()
        .Equal(expectedGradesWhenMembershipIsSymmetricTriangle);

      actualInputDomainValues
        .Select(domainValue
          => CreateTriangleWith(-6.0, .0, 4.0)
            .MapDegreeOfMembershipFor(domainValue))
        .Should()
        .Equal(expectedGradesWhenMembershipIsAsymmetricTriangle);
    }

    private static TriangleFunction CreateTriangleWith(double leftEdge, double center, double rightEdge)
      => TriangleFunction.Create(leftEdge, center, rightEdge);
  }
}
