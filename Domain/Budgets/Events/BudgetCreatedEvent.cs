using Domain.Shared.Base;

namespace Domain.Budget;

public record BudgetCreatedEvent(Guid Id) : IDomainEvent;