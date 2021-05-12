using System.Collections.Generic;

namespace FuzzyInferenceSystem.SeedWork
{
  public abstract class Entity<TId> where TId : ValueObject
  {
    private int? _requestedHashCode;

    public TId Id { get; protected set; }

    public bool IsTransient() => Id is default(TId);

    public override bool Equals(object obj)
    {
      if (obj is null or not Entity<TId>)
      {
        return false;
      }

      if (ReferenceEquals(this, obj))
      {
        return true;
      }

      if (GetType() != obj.GetType())
      {
        return false;
      }

      if ((obj as Entity<TId>)?.IsTransient() == true || IsTransient())
      {
        return false;
      }
      else
      {
        return (obj as Entity<TId>)?.Id == Id;
      }
    }

    public override int GetHashCode()
    {
      if (!IsTransient())
      {
        if (!_requestedHashCode.HasValue)
        {
          _requestedHashCode = Id.GetHashCode() ^ 31;
        }

        return _requestedHashCode.Value;
      }
      else
      {
        return base.GetHashCode();
      }
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
      => (left is null) ? right is null : left.Equals(right);

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
      => !(left == right);
  }
}
