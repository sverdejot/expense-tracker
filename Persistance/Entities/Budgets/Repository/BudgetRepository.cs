using Domain.Budgets;
using Microsoft.EntityFrameworkCore;
using Persistance.Shared;
namespace Persistance.Budgets;

internal class BudgetRepository : AbstractRepository<Budget>, IBudgetRepository
{
    public BudgetRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Task Delete(Budget budget)
    {
        _context.Set<Budget>().Remove(budget);
        return Task.CompletedTask;
    }

    public async Task<List<Budget>> FindAll()
    {
        return await this._context.Set<Budget>().ToListAsync();
    }

    
}

