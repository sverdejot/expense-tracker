using Domain.Shared.Base;

namespace Domain.Expenses;

public sealed record ExpenseCreatedEvent(Guid Id, Decimal Amount, DateTime createdAt) : IDomainEvent;
