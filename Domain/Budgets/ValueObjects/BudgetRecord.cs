using Domain.Shared.ValueObjects;

namespace Domain.Budget;

public record BudgetRecord
{
    public Guid ExpenseId { get; }

    public Decimal Amount { get; }

    public Currency Currency { get; }

    public DateTime Created { get; }

    protected BudgetRecord(Guid expenseId, Decimal amount, Currency currency, DateTime created)
    {
        ExpenseId = expenseId;
        Amount = amount;
        Currency = currency;
        Created = created;
    }
    public static BudgetRecord Create(Guid expenseId, Decimal amount, Currency currency, DateTime created) =>
        new(expenseId, amount, currency, created);
}