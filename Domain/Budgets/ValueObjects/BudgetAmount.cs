using Domain.Shared.ValueObjects;

namespace Domain.Budget;

public record BudgetAmount(Decimal Amount, Currency Currency);