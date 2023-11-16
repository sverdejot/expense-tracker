using Domain.Shared.Base;

namespace Domain.Expenses;

public class Expense : AggregateRoot<Expense>
{
	public ExpenseId Id { get; private set; }

	public UserId User { get; private set; }

	public ExpenseAmount Amount { get; private set; }

	public ExpenseDescription Description { get; private set; }

	private Expense()
	{
	}

	protected Expense(ExpenseId id, ExpenseAmount amount, ExpenseDescription description, UserId user)
	{
		Id = id;
		Amount = amount;
		Description = description;
		User = user;
	}

	public static Expense Create(ExpenseId id, ExpenseAmount amount, ExpenseDescription description, UserId user)
	{
		var expense = new Expense(id: id, amount: amount, description: description, user: user);

		expense.RecordEvent(new ExpenseCreatedEvent(id.Value, amount.Quantity, DateTime.Now, user.Value));

		return expense;
	}
}