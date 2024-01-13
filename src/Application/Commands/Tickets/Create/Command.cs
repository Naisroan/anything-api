using ErrorOr;
using MediatR;

namespace Application.Commands.Tickets.Create;

public record CreateTicketCommand
(
    string Subject
) : IRequest<ErrorOr<Unit>>;