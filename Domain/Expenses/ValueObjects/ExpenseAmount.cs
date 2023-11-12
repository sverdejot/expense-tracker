using Domain.Shared.ValueObjects;

namespace Domain.Expenses;

public record ExpenseAmount
{
    public Decimal Quantity { get; }

    public Currency Currency { get; }

    private ExpenseAmount(Decimal quantity, Currency currency)
    {
        Quantity = quantity;
        Currency = currency;
    }

    public static ExpenseAmount Create(Decimal quantity, Currency currency) =>
        new(quantity, currency);
}