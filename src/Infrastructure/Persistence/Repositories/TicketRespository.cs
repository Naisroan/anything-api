using Domain.Entitites.Tickets;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class TicketRespository : ITicketRepository
{
    private readonly ApplicationDbContext _context;

    public TicketRespository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentException(nameof(ApplicationDbContext));
    }

    public async Task Add(Ticket ticket) => await _context.Tickets.AddAsync(ticket);

    public async Task<Ticket?> GetByIdAsync(Guid id) => await _context.Tickets.SingleOrDefaultAsync(e => e.Id == id);
}