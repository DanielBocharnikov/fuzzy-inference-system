using System;

namespace FuzzyInferenceSystem.SeedWork.DDD
{
  public abstract class Entity<TId> : IInternalEventHandler
    where TId : ValueObject
  {
    private int? _requestedHashCode;

    private readonly Action<object> _applier;

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
      => left is null ? right is null : left.Equals(right);

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
      => !(left == right);

    protected Entity(Action<object> applier) => _applier = applier;

    protected void Apply(object @event)
    {
      When(@event);
      _applier(@event);
    }

    protected abstract void When(object @event);

    void IInternalEventHandler.Handle(object @event) => When(@event);
  }
}
