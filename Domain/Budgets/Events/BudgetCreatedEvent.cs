using Domain.Shared.Base;

namespace Domain.Budgets;

public sealed record BudgetCreatedEvent(Guid Id) : IDomainEvent;