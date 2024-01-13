using Domain.Entitites.Tickets;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Commands.Tickets.Create;

public sealed class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, ErrorOr<Unit>>
{
    private readonly ITicketRepository _repository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateTicketCommandHandler(ITicketRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository ?? throw new ArgumentException(nameof(ITicketRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentException(nameof(IUnitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        // return Error.Validation("Ticket.Duplicate", "El ticket ya existe.");

        var ticket = new Ticket
        (
            id: new Guid(),
            subject: request.Subject
        );

        await _repository.Add(ticket);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}