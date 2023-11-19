using Domain.Shared.Base;

namespace Domain.Groups;

public class GroupRecord : Entity<GroupRecord>
{
    public GroupRecordId Id { get; private set; }

    public Decimal Amount { get; private set; }

    public UserId Creator { get; private set; }

    public List<RecordPercentage> Percentages { get; private set; } = new();

    private GroupRecord()
    {
    }

    protected GroupRecord(GroupRecordId id, Decimal amount, UserId creator, List<RecordPercentage> percentages)
    {
        Id = id;
        Amount = amount;
        Creator = creator;
        Percentages = percentages;
    }

    public static GroupRecord Create(GroupRecordId id, Decimal amount, UserId creator, List<RecordPercentage> percentages)
        => new(id, amount, creator, percentages);
}