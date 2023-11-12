using Domain.Shared.Base;

namespace Domain;

public sealed record BudgetLimitExceededEvent(Guid BudgetId, Decimal AmountLimit, Decimal CurrentAmount) : IDomainEvent;
