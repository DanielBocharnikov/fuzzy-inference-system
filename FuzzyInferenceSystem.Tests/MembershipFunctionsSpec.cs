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
    public void TriangleMembershipFunctions_with_same_parameters_should_be_equal() {
      TriangleMembershipFunction firstMF = new (leftEdge: 0, center: 5, rightEdge: 10);
      TriangleMembershipFunction secondMF = new (leftEdge: 0, center: 5, rightEdge: 10);

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
      TriangleMembershipFunction firstMF = new(leftEdge: 0, center: 5, rightEdge: 10);
      TriangleMembershipFunction secondMF = new(leftEdge: 0, center: 5, rightEdge: 10);
      double firstMFGrade = firstMF.GetDegreeOfMembershipFor(domainValue);
      double secondMFGrade = secondMF.GetDegreeOfMembershipFor(domainValue);
      firstMFGrade.Should().Be(secondMFGrade);
    }
  }
}
