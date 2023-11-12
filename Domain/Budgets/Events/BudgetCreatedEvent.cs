using Domain.Shared.Base;

namespace Domain.Budget;

public sealed record BudgetCreatedEvent(Guid Id) : IDomainEvent;