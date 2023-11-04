using Domain.Shared.ValueObjects;

namespace Domain.Expenses;

public record ExpenseAmount(Decimal Quantity, Currency Currency);
