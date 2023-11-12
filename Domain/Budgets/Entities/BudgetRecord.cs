using Domain.Shared.ValueObjects;

namespace Domain.Budget;

public record BudgetRecord
{
    public Guid ExpenseId { get; private set; }

    public Decimal Amount { get; private set; }

    public Currency Currency { get; private set; }

    public DateTime Created { get; private set; }

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