namespace Domain;

public record UserMail
{
    public string Value { get; private set; }

    private UserMail(string value) => 
        Value = value;

    public static UserMail Create(string value) => 
        new(value);
}
