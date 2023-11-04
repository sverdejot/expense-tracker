using Domain.Budget;
using Persistance.Shared;
namespace Persistance.Budgets;

internal class BudgetRepository : AbstractRepository<Budget>, IBudgetRepository
{
    public BudgetRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

