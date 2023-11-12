using Domain.Budgets;
using Domain.Shared.Base;

namespace Domain.Budgets;

public class BudgetByIdCriteria : Criteria<Budget>
{
    public BudgetByIdCriteria(BudgetId id) : base(budget => budget.Id == id)
    {
    }
}
