using Domain.Shared.Base;

namespace Domain;

public abstract record AlertEvent : IDomainEvent {
    public Guid BudgetId { get; set; }

    public DateTime FiredAt { get; set; } = DateTime.Now;
}
