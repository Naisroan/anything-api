using ErrorOr;

namespace Domain.Errors;

public static partial class Errors
{
    public static class Ticket
    {
        public static Error SubjectEmpty =>
            Error.Validation("Ticket.SubjectEmpty", "El asunto es vacio.");
    }
}