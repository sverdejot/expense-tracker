using Application;
using Domain;
using Domain.Budget;
using Domain.Expenses;
using FluentAssertions;
using Microsoft.VisualBasic;
using Moq;
using Moq.AutoMock;
using Unit.Random;

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
    public async void Handle_ShouldRecordNewExpenseOnBudget_WhenIsNotBlocked()
    {
        // Given
        var budget = BudgetMother.Random();

        mocker.GetMock<IBudgetRepository>()
            .Setup(repo => repo.FindAll())
            .ReturnsAsync(new List<Budget>() { budget });

        var evnt = new ExpenseCreatedEventMother()
            .WithRandomAmountBetweenRange(1, 10)
            .Build();

        // When
        await handler.Handle(evnt);

        // Then
        mocker.GetMock<IBudgetRepository>()
            .Verify(repo => repo.FindAll(), Times.Once);
        
        var expectedRecord = budget.Records
            .Where(record => record.ExpenseId == evnt.Id)
            .FirstOrDefault();

        Assert.True(expectedRecord is not null);
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

    [Fact]
    public async void Handle_ShouldThrowException_WhenBudgetIsBlocked()
    {
        // Given
        var budget = new BudgetMother()
            .WithAmount(1_000)
            .WithRecordsAtLimit()
            .Build();

        mocker.GetMock<IBudgetRepository>()
            .Setup(repo => repo.FindAll())
            .ReturnsAsync(new List<Budget>() { budget });

        var evnt = new ExpenseCreatedEvent(Guid.NewGuid(), 1_000, DateTime.Now);

        // When
        var handle = async () => await handler.Handle(evnt);

        // Then
        Assert.ThrowsAsync<BudgetIsBlockedException>(handle);
    }

    [Fact]
    public async void Handle_ShouldFireDateOverdueEvent_WhenExpenseCreatedWithDateAlertOverdue()
    {
        // Given
        var alert = BudgetAlertsMother.CreateDateOverdue();

        var budget = new BudgetMother()
            .WithAlert(alert)
            .Build();

        mocker.GetMock<IBudgetRepository>()
            .Setup(repo => repo.FindAll())
            .ReturnsAsync(new List<Budget>() { budget });

        var evnt = ExpenseCreatedEventMother.Random();

        // When
        await handler.Handle(evnt);

        // Then
        var alertEvents = budget.GetEvents()
            .Where(evnt => evnt is AlertEvent);

        budget.GetEvents()
            .Should()
            .HaveCount(1);
        
        Assert.True(budget.GetEvents().All(evnt => evnt is DateOverdueAlertEvent));
    }

}
