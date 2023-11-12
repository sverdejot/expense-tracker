using Domain.Budget;
using Microsoft.EntityFrameworkCore;
using Persistance.Shared;
namespace Persistance.Budgets;

internal class BudgetRepository : AbstractRepository<Budget>, IBudgetRepository
{
    public BudgetRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Budget>> FindAll()
    {
        return await this._context.Set<Budget>().ToListAsync();
    }
}

