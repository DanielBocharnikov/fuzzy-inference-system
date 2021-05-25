using System;

using FluentAssertions;

using Xunit;

namespace FuzzyInferenceSystem.Tests
{
  public class FuzzySystemSpec
  {
    [Fact]
    public void CreateFuzzySystem_WithCorrectArguments_ShouldReturnExpectedObject()
    {
      // Given
      var userId = new UserId(Guid.NewGuid());
      var systemId = new SystemId(Guid.NewGuid());
      var systemName = new SystemName("Risk Assessment");
      // When
      var fs = FuzzyModel.Create(
        ownerId: userId,
        systemId: systemId,
        systemName: "Risk Assessment"
      );
      // Then
    }
  }
}
