using System;
using System.Collections.Generic;
using System.Linq;

using FuzzyInferenceSystem.SeedWork;

namespace FuzzyInferenceSystem.Domain
{
  public class FuzzySet : ValueObject
  {
     ISet
     protected override IEnumerable<object> GetEqualityComponents() => throw new NotImplementedException();
  }
}
