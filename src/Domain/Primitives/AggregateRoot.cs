namespace Domain.Primitives;

public abstract class AggregateRoot
{
    private readonly List<DomainEvent> _events = new();

    public ICollection<DomainEvent> GetDomainEvents() => _events;

    protected void Raise(DomainEvent e)
    {
        _events.Add(e);
    }
} 