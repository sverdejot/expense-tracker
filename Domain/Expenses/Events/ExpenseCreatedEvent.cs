using Domain.Shared.Base;

namespace Domain.Expenses;

public record ExpenseCreatedEvent(ExpenseId Id) : IDomainEvent;
