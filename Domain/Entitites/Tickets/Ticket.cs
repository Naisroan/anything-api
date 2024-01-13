using Domain.Primitives;

namespace Domain.Entitites.Tickets;

public sealed class Ticket : AggregateRoot
{
    private Ticket() { }

    public Ticket(Guid id, string subject)
    {
        Id = id;
        Subject = subject;
    }

    public Guid Id { get; private set; }

    public string Subject { get; set; } = string.Empty;
}