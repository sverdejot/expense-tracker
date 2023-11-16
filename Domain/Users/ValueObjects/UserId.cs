namespace Domain;

public record UserId
{
    public Guid Value { get; private set; }

    private UserId(Guid value) =>
        Value = value;

    public static UserId Create(Guid value) => 
        new(value);
}
