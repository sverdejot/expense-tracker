using System.Net.Http.Headers;
using Application.Expenses.Commands;
using Castle.Core.Logging;
using Domain.Expenses;
using Moq;
using Moq.AutoMock;

namespace Unit;

public class TestCreateExpenseCommandHandler
{
    private readonly AutoMocker mocker = new AutoMocker();

    private readonly CreateExpenseCommandHandler handler;
    public TestCreateExpenseCommandHandler() =>
        handler = mocker.CreateInstance<CreateExpenseCommandHandler>();

    [Fact]
    public async Task Handle_ShouldCreateExpense()
    {
        // Given
        var expectedExpense = ExpenseMother.Random();
        var command = CreateExpenseCommandMother.FromExpense(expectedExpense);

        // When
        await handler.Handle(command);

        // Then
        mocker.GetMock<IExpenseRepository>()
            .Verify(repo => repo.Add(It.IsAny<Expense>()), Times.Exactly(1));
    }
}
