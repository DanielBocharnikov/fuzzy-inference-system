using System.Collections.Generic;

namespace FuzzyInferenceSystem.Domain
{
  public interface IFuzzySet
  {
    double Power { get; }

    double Height { get; }

    double GetDegreeOfMembershipFor(double domainValue);

    double GetDomainValueBy(double degreeOfMembership);

    HashSet<double> GetSupportSet();

    IFuzzySet ApplyAlphaCut(double alphaValue, AlphaCutType alphaCutType);

    IFuzzySet ApplyIntersectionWith(IFuzzySet other);

    IFuzzySet ApplyUnionWith(IFuzzySet other);

    IFuzzySet ApplyComplement();

    IFuzzySet Normilize();

    bool IsInMaximumNormalForm();

    bool IsInMinimumNormalForm();
  }
}
