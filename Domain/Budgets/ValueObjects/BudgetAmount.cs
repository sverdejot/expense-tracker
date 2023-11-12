using Domain.Shared.ValueObjects;

namespace Domain.Budgets;

public record BudgetAmount
{
    public Decimal Amount { get; private set; }

    public Currency Currency { get; private set; }

    private BudgetAmount(Decimal Amount, Currency currency)
    {
        this.Amount = Amount;
        this.Currency = currency;
    }

    public static BudgetAmount Create(Decimal Amount, Currency Currency) => new(Amount, Currency);
}