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
    {
        CheckTotalPercentage(percentages);
        
        return new(id, amount, creator, percentages);;
    }

    private static void CheckTotalPercentage(List<RecordPercentage> percentages) 
    {
        var totalPercentage = percentages.Select(percentage => percentage.Percentage).Sum();

        if (totalPercentage is not 1)
            throw new InvalidTotalPercentageException(percentages);
    }
}