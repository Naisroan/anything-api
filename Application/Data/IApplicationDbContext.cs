using Domain.Entitites.Tickets;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Ticket> Tickets { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}