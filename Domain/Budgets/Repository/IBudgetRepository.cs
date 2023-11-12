using Domain.Shared.Base;
namespace Domain.Budgets;

public interface IBudgetRepository : IRepository<Budget>
{
    public Task<List<Budget>> FindAll();

    public Task Delete(Budget budget);
}

