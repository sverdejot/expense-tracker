using Domain.Shared.Base;

namespace Domain.Expenses;

public interface IExpenseRepository : IRepository<Expense>
{
    public Task Delete(Expense expense);
}
