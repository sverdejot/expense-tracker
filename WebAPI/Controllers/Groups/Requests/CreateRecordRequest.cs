namespace WebAPI;

public record CreateRecordRequest
{
    public Decimal Amount { get; set; }

    public Dictionary<Guid, Decimal> Percentages { get; set; } = new();
}
