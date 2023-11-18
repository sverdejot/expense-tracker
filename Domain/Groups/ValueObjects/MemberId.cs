namespace Domain;

public record MemberId(Guid Value)
{
    public static MemberId Create(Guid value) => new(value);
}
