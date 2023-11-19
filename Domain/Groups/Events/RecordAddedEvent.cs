using Domain.Shared.Base;

namespace Domain;

public sealed class RecordAddedEvent : IDomainEvent
{
    public Guid Group { get; set; }

    public Decimal Amount { get; set; }

    public Dictionary<Guid, Decimal> Percentages = new();

    public RecordAddedEvent(Guid group, Decimal amount, Dictionary<Guid, Decimal> percentages)
    {
        Group = group;
        Amount = amount;
        Percentages = percentages;
    }
}
