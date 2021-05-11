using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyInferenceSystem.Domain {
  public interface IMembershipFunction {
    double GetDegreeOfMembershipFor(double domainValue);
  }
}
