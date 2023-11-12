namespace Domain.Budget;

public record BudgetId
{
    public Guid Value { get; }

    private BudgetId(Guid value) => Value = value;

    public static BudgetId Create(Guid Value) => new(Value);
}