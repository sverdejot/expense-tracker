using Application.Shared.Command;

namespace Application;

public sealed record CreateRecordCommand : ICommand
{
    public Guid Id { get; set; }
    public Guid Group { get; set; }

    public Guid Creator { get; set; }

    public Decimal TotalAmount { get; set; }

    public Dictionary<Guid, Decimal>  Percentages { get; set; } = new();
}
