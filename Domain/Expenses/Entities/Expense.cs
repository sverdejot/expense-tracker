using Domain.Shared.Base;

namespace Domain.Expenses;

public class Expense : AggregateRoot<Expense>
{
    public ExpenseId Id { get; private set; }

	public ExpenseAmount Amount { get; private set; }

	public ExpenseDescription Description { get; private set; }

	protected Expense(ExpenseId id, ExpenseAmount amount, ExpenseDescription description)
	{
		Id = id;
		Amount = amount;
		Description = description;
	}

	public static Expense Create(ExpenseId id, ExpenseAmount amount, ExpenseDescription description)
	{
		var expense = new Expense(id: id, amount: amount, description: description);

		expense.RecordEvent(new ExpenseCreatedEvent(id));

		return expense;
	}
}