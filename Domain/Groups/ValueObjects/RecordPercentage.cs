namespace Domain;

public class RecordPercentage
{
    public UserId Member { get; set; }

    public Decimal Percentage { get; set; }

    private RecordPercentage()
    {
    }

    private RecordPercentage(UserId member, Decimal percentage)
    {
        Member = member;
        Percentage = percentage;
    }

    public static RecordPercentage Create(UserId member, Decimal percentage)
    {
        if (percentage < 0 || percentage > 1)
            throw new ArgumentOutOfRangeException(nameof(percentage));
        
        return new RecordPercentage(member, percentage);
    }
}
