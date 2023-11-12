using Domain.Shared.ValueObjects;

namespace Domain.Expenses;

public record ExpenseAmount
{
    public Decimal Quantity { get; private set; }

    public Currency Currency { get; private set; }

    protected ExpenseAmount(Decimal quantity, Currency currency)
    {
        Quantity = quantity;
        Currency = currency;
    }

    public static ExpenseAmount Create(Decimal quantity, Currency currency) =>
        new(quantity, currency);
}