namespace Domain.Shared.Base;

public interface IDomainEventRecorder
{
    public IReadOnlyCollection<IDomainEvent> GetEvents();

    public void ClearEvents();
}

public abstract class AggregateRoot<T> : Entity<T>, IDomainEventRecorder
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public IReadOnlyCollection<IDomainEvent> GetEvents() => _domainEvents.ToList();

    public void ClearEvents() => this._domainEvents.Clear();

    protected void RecordEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
