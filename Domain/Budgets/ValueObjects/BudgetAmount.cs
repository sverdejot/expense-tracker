using Domain.Shared.ValueObjects;

namespace Domain.Budget;

public record BudgetAmount
{
    public Decimal Amount { get; }

    public Currency Currency { get; }

    private BudgetAmount(Decimal Amount, Currency currency)
    {
        this.Amount = Amount;
        this.Currency = currency;
    }

    public static BudgetAmount Create(Decimal Amount, Currency Currency) => new(Amount, Currency);
}