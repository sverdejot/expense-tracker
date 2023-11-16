using Domain.Shared.Base;

namespace Domain.Expenses;

public sealed record ExpenseCreatedEvent : IDomainEvent
{
    public Guid Id { get; set; }

    public Decimal Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public Guid User { get; set; }
    
    public ExpenseCreatedEvent()
    {
    }

    public ExpenseCreatedEvent(Guid id, Decimal amount, DateTime createdAt, Guid user)
    {
        Id = id;
        Amount = amount;
        CreatedAt = createdAt;
        User = user;
    } 
}
