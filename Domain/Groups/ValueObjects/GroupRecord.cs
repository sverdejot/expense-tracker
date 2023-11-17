namespace Domain.Groups;

public class GroupRecord
{
    public Decimal Amount { get; private set; }

    public UserId Creator { get; private set; }

    public List<RecordPercentage> Percentages { get; private set; }
}
