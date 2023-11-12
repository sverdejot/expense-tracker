namespace Domain.Expenses;

public record ExpenseDescription
{
    public string Value { get; }

    private ExpenseDescription(string value)
    {
        Value = value;
    }

    public static ExpenseDescription Create(string value) => new(value);
}
