namespace Domain.Budgets;

public class DateBudgetAlert : BudgetAlert
{
    public DateTime AlertingDate { get; private set; }

    private DateBudgetAlert()
    {
    }

    protected DateBudgetAlert(DateTime alertingDate) =>
        AlertingDate = alertingDate;

    public static DateBudgetAlert Create(DateTime alertingDate) =>
        new(alertingDate);

    public override bool Eval(Budget budget) =>
        DateTime.Now > AlertingDate;

    public override AlertEvent GenerateEvent(Budget budget)
        => new DateOverdueAlertEvent()
        {
            FiredAt = DateTime.Now,
            AlertingDate = AlertingDate,
            BudgetId = budget.Id.Value
        };
}
