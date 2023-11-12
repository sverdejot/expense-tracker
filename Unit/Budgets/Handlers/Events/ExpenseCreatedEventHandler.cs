using Application;
using Domain;
using Domain.Budget;
using Domain.Expenses;
using Moq;
using Moq.AutoMock;

namespace Unit;

public class TestExpenseCreatedEventHandler
{
    private readonly AutoMocker mocker = new AutoMocker();

    private readonly ExpenseCreatedEventHandler handler;

    public TestExpenseCreatedEventHandler()
    {
        handler = mocker.CreateInstance<ExpenseCreatedEventHandler>();
    }

    [Fact]
    public async void Handler_ShouldBlockExpense_WhenLastRecordExceedAmount()
    {
        // Given
        var budget = new BudgetMother()
            .WithRecordsReachingLimit()
            .Build()!;

        mocker.GetMock<IBudgetRepository>()
            .Setup(repo => repo.FindAll())
            .ReturnsAsync(new List<Budget>() { budget });

        var evnt = new ExpenseCreatedEvent(Guid.NewGuid(), 100, DateTime.Now);

        // When
        await handler.Handle(evnt);

        // Then
        Assert.True(budget.GetEvents().All(evnt => evnt is BudgetLimitExceededEvent));
        Assert.True(budget.GetEvents().Count == 1);
    }

}
