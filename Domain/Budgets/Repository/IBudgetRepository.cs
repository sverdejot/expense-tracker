using Domain.Shared.Base;
namespace Domain.Budget;

public interface IBudgetRepository : IRepository<Budget>
{
    public Task<List<Budget>> FindAll();
}

