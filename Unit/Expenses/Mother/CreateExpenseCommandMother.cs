using Application.Expenses.Commands;
using Domain.Expenses;

namespace Unit;

public static class CreateExpenseCommandMother
{
    public static CreateExpenseCommand FromExpense(Expense expense) =>
        new CreateExpenseCommand(
            expense.Id.Value, 
            expense.Amount.Quantity, 
            expense.Amount.Currency, 
            expense.Description.Value, 
            Guid.NewGuid());
}
