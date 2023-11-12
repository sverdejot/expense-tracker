using System;
using Application.Shared.Command;
using Domain.Expenses;

namespace Application.Expenses.Commands;

public class DeleteExpenseCommandHandler : ICommandHandler<DeleteExpenseCommand>
{
    private readonly IExpenseRepository _expenseRepository;

    public DeleteExpenseCommandHandler(IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
    }

    public async Task Handle(DeleteExpenseCommand request, CancellationToken cancellationToken = default)
    {
        var id = ExpenseId.Create(request.Id);
        var criteria = new FindExpenseByIdCriteria(id);

        var expense = await _expenseRepository.MatchFirstOrDefault(criteria);

        if (expense is null)
        {
            throw new ExpenseNotFoundException($"The Expense with ID [{request.Id}] has not been found in the database");
        }

        await _expenseRepository.Delete(expense);
    }
}

