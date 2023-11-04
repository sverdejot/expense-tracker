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

    public async Task Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
    {
        var id = new ExpenseId(request.Id);
        var amount = new ExpenseAmount(request.Amount, request.Currency);
        var description = new ExpenseDescription(request.Description);

        var expense = Expense.Create(id: id, amount: amount, description: description);

        await this._expenseRepository.Add(expense);
    }
}

