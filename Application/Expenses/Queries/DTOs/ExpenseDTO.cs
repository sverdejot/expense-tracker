namespace Application.Expenses.Queries;

public record ExpenseDTO
{
	public Guid Id { get; set; }

	public AmountDTO Amount { get; set; }

	public string Description { get; set; }
}

