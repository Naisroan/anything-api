using Application.Commands.Tickets.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace anything_api.Controllers;

[Route("[controller]")]
[ApiController]
public class TicketsController : ApiController
{
    private readonly ISender _mediator;

    public TicketsController(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTicketCommand cmd)
    {
        var result = await _mediator.Send(cmd);

        return result.Match(
            ticket => Ok(),
            errors => Problem(errors)
        );
    }
}