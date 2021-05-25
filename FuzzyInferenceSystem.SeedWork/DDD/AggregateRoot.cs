using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzzyInferenceSystem.SeedWork.DDD
{
  public abstract class AggregateRoot<TId>
  {
    private readonly List<object> _changes;

    public TId Id { get; protected set; }

    public int Version { get; private set; } = -1;

    protected AggregateRoot() => _changes = new();

    public IReadOnlyList<object> GetChanges() => _changes;

    public void ClearChanges() => _changes.Clear();

    protected void Apply(object @event)
    {
      When(@event);
      EnsureValidState();
      _changes.Add(@event);
    }

    protected abstract void When(object @event);

    protected abstract void EnsureValidState();

    protected void ApplyToEntity(IInternalEventHandler entity, object @event)
      => entity?.Handle(@event);

    public void Load(IEnumerable<object> history)
    {
      foreach (var @event in history)
      {
        When(@event);
        Version++;
      }
    }
  }
}
