using Domain.Budget;

namespace Domain;

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

    public override bool Eval(Budget.Budget budget) =>
        DateTime.Now > AlertingDate;

    public override AlertEvent GenerateEvent(Budget.Budget budget)
        => new DateOverdueAlertEvent() { 
            FiredAt = DateTime.Now,
            AlertingDate = AlertingDate,
            BudgetId = budget.Id.Value
        };
}
