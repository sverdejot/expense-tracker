using Domain.Shared.ValueObjects;

namespace Domain.Budget;

public record BudgetRecord(Guid ExpenseId, Decimal Amount, Currency Currency, DateTime Created);
