using Domain.Expenses;
using Mapster;

namespace Application.Expenses.Queries;

public class ExpenseMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Expense, ExpenseDTO>()
            .Map(dto => dto.Id, expense => expense.Id.Value)
            .Map(dto => dto.Description, expense => expense.Description.Value)
            .Map(dto => dto.Amount, expense => expense.Amount.Adapt<AmountDTO>());
    }
}

