using Application.Shared;
using Domain.Budget;
using Domain.Expenses;

namespace Application;

public class ExpenseCreatedEventHandler : IEventHandler<ExpenseCreatedEvent>
{
    private readonly IBudgetRepository _budgetRepository;

    public ExpenseCreatedEventHandler(IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
    }

    public async Task Handle(ExpenseCreatedEvent notification, CancellationToken cancellationToken = default)
    {
        var budgets = await _budgetRepository.FindAll();

        foreach (var budget in budgets)
        {
            var budgetRecord = BudgetRecord.Create(notification.Id, notification.Amount, budget.MaximumAmount.Currency, notification.CreatedAt);

            budget.RecordNew(budgetRecord);
        }
    }
}
