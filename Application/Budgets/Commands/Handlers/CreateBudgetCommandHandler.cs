using Domain.Budgets;
using Application.Shared.Command;
using Domain;

namespace Application.Budgets;

public class CreateBudgetCommandHandler(IBudgetRepository budgetRepository) : ICommandHandler<CreateBudgetCommand>
{
    private readonly IBudgetRepository _budgetRepository = budgetRepository;

    public async Task Handle(CreateBudgetCommand request, CancellationToken cancellationToken = default)
    {
        var id = BudgetId.Create(request.Id);
        var amount = BudgetAmount.Create(request.MaximumAmount, request.Currency);
        var period = BudgetPeriod.CreateMonthly();
        var owner = UserId.Create(request.Owner);

        var budget = Budget.Create(id, amount, period, owner);

        await _budgetRepository.Add(budget);
    }
}