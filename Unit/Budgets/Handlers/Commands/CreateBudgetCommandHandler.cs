using Application.Budgets;
using Domain.Budgets;
using Moq;
using Moq.AutoMock;

namespace Unit;

public class TestCreateBudgetCommandHandler
{
    private readonly AutoMocker mocker = new AutoMocker();

    private readonly CreateBudgetCommandHandler handler;

    public TestCreateBudgetCommandHandler()
    {
        handler = mocker.CreateInstance<CreateBudgetCommandHandler>();
    }

    [Fact]
    public async Task Handle_ShouldCreateBudget()
    {
        // Given
        var expectedBudget = BudgetMother.Random();

        var command = new CreateBudgetCommand(
            expectedBudget.Id.Value,
            expectedBudget.MaximumAmount.Amount,
            expectedBudget.MaximumAmount.Currency,
            Guid.NewGuid()
        );

        // When
        await handler.Handle(command);

        // Then
        mocker.GetMock<IBudgetRepository>()
            .Verify(repo => repo.Add(It.IsAny<Budget>()), Times.Once);

    }
}
