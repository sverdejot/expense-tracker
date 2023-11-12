using Application.Shared.Command;
using Domain.Expenses;

namespace Application.Expenses.Commands;

public class CreateExpenseCommandHandler : ICommandHandler<CreateExpenseCommand>
{
    private readonly IExpenseRepository _expenseRepository;

    public CreateExpenseCommandHandler(IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
    }

    public async Task Handle(CreateExpenseCommand request, CancellationToken cancellationToken = default)
    {
        var id = ExpenseId.Create(request.Id);
        var amount = ExpenseAmount.Create(request.Amount, request.Currency);
        var description = ExpenseDescription.Create(request.Description);

        var expense = Expense.Create(id: id, amount: amount, description: description);

        await this._expenseRepository.Add(expense);
    }
}

