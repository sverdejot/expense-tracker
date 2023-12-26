using Application.Shared.Command;
using Domain.Budgets;

namespace Application.Budgets;

public class DeleteBudgetCommandHandler(IBudgetRepository budgetRepository) : ICommandHandler<DeleteBudgetCommand>
{
    private readonly IBudgetRepository _budgetRepository = budgetRepository;

    public async Task Handle(DeleteBudgetCommand request, CancellationToken cancellationToken = default)
    {
        var criteria = new BudgetByIdCriteria(BudgetId.Create(request.Id));
        var budget = await _budgetRepository.MatchFirst(criteria);

        await _budgetRepository.Delete(budget);
    }
}
