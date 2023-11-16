namespace Domain.Groups;

public record  GroupId(Guid Value)
{
    public static GroupId Create(Guid value) => new(value);
}
