using Application.Shared.Command;
using Domain;
using Domain.Expenses;

namespace Application.Expenses.Commands;

public class CreateExpenseCommandHandler(IExpenseRepository expenseRepository) : ICommandHandler<CreateExpenseCommand>
{
    private readonly IExpenseRepository _expenseRepository = expenseRepository;

    public async Task Handle(CreateExpenseCommand request, CancellationToken cancellationToken = default)
    {
        var id = ExpenseId.Create(request.Id);
        var amount = ExpenseAmount.Create(request.Amount, request.Currency);
        var description = ExpenseDescription.Create(request.Description);
        var user = UserId.Create(request.User);

        var expense = Expense.Create(id: id, amount: amount, description: description, user: user);

        await _expenseRepository.Add(expense);
    }
}

