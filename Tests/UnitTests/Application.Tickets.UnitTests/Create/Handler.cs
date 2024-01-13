using Application.Commands.Tickets.Create;
using Domain.Entitites.Tickets;
using Domain.Primitives;

namespace Application.Tickets.UnitTests.Create;

public class CreateTicketCommandHandlerUnitTests
{
    private readonly Mock<ITicketRepository> _mockRepository;

    private readonly Mock<IUnitOfWork> _mockUnitOfWork;

    private readonly CreateTicketCommandHandler _handler;

    public CreateTicketCommandHandlerUnitTests()
    {
        _mockRepository = new Mock<ITicketRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _handler = new CreateTicketCommandHandler(_mockRepository.Object, _mockUnitOfWork.Object);
    }

    [Fact]
    public async void HandleCreateTicket_WhenSubjectIsEmpty_ShouldReturnValidationError()
    {
        // Arrange (setting inputs params)
        CreateTicketCommand cmd = new CreateTicketCommand(string.Empty);

        // Act (invoke the method to test)
        var result = await _handler.Handle(cmd, default);

        // Assert (check the return data)
        result.IsError.Should().BeTrue();
        result.FirstError.Type.Should().Be(ErrorType.Validation);
    }
}