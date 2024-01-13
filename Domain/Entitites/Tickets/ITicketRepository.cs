namespace Domain.Entitites.Tickets;

public interface ITicketRepository
{
    Task<Ticket?> GetByIdAsync(Guid id);

    Task Add(Ticket ticket);
}