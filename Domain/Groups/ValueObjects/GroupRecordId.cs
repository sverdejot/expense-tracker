namespace Domain;

public record GroupRecordId(Guid Value)
{
    public static GroupRecordId Create(Guid value) => new(value);
}
