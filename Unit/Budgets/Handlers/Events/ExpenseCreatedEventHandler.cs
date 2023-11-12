using System.Diagnostics.Tracing;
using Application;
using Domain;
using Domain.Budget;
using Domain.Expenses;
using FluentAssertions;
using Moq;
using Moq.AutoMock;

namespace Unit;

public class TestExpenseCreatedEventHandler
{
    private readonly AutoMocker mocker = new();

    private readonly ExpenseCreatedEventHandler handler;

    public TestExpenseCreatedEventHandler()
    {
        handler = mocker.CreateInstance<ExpenseCreatedEventHandler>();
    }

    [Fact]
    public async Task Handle_ShoulThrowException_WhenBudgetIsBlocked()
    {
        // Given
        var budget = new BudgetMother()
            .WithRecordsReachingLimit(offsetToMax: 100)
            .Build();

        mocker.GetMock<IBudgetRepository>()
            .Setup(repo => repo.FindAll())
            .ReturnsAsync(new List<Budget> { budget });

        var newEvent = new ExpenseCreatedEvent(Guid.NewGuid(), 100, DateTime.Now);

        // When
        await handler.Handle(newEvent);

        // Then
        budget.GetEvents()
            .Should()
            .AllBeAssignableTo<BudgetLimitExceededEvent>();
    }
}
