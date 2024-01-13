using Domain.Entitites.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Tickets");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Subject)
            .HasMaxLength(250);

        builder.HasIndex(e => e.Subject);

        // # If a prop is strong type
        //builder.Property(e => e.Id).HasConversion
        //(
        //    ticketId => ticketId.Value,
        //    value => new TicketId(value)
        //);

        // # If required ignore calculated prop
        //builder.Ignore(e => e.anyProp)
    }
}