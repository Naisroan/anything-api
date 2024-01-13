using FluentValidation;

namespace Application.Commands.Tickets.Create;

public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
{
    public CreateTicketCommandValidator()
    {
        RuleFor(r => r.Subject)
            .NotEmpty()
            .MaximumLength(250)
            .WithName("Asunto");
    }
}