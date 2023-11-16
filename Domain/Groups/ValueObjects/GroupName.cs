namespace Domain.Groups;

public record GroupName(string Value)
{
    public static GroupName Create(string name) => new(name);
}
