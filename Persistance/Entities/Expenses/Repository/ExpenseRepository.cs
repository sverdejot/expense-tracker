using Domain.Expenses;
using Persistance.Shared;

namespace Persistance.Expenses;

internal class ExpenseRepository : AbstractRepository<Expense>, IExpenseRepository
{
    public ExpenseRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Task Delete(Expense expense)
    {
        this._context.Set<Expense>().Remove(expense);
        return Task.CompletedTask;
    }
}

