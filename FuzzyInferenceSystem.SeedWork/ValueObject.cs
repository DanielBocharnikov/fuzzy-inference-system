using System.Collections.Generic;
using System.Linq;

namespace FuzzyInferenceSystem.SeedWork
{
  public abstract class ValueObject
  {
    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object obj)
    {
      if (obj is null || GetType() != obj.GetType())
      {
        return false;
      }

      return GetEqualityComponents().SequenceEqual((obj as ValueObject)?.GetEqualityComponents());
    }

    public override int GetHashCode() => GetEqualityComponents()
      .Select(x => (x?.GetHashCode()) ?? 0)
      .Aggregate((x, y) => x ^ y);

    public static bool operator ==(ValueObject left, ValueObject right)
    {
      if (left is null ^ right is null)
      {
        return false;
      }

      return left?.Equals(right) != false;
    }

    public static bool operator !=(ValueObject left, ValueObject right) => !(left == right);

    public ValueObject GetCopy() => MemberwiseClone() as ValueObject;
  }
}
