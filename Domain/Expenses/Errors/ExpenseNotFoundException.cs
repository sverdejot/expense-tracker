using Domain.Shared.Base;

namespace Domain.Expenses;

public class ExpenseNotFoundException : DomainException
{
	public ExpenseNotFoundException(string message) : base(message)
	{
	}
}

