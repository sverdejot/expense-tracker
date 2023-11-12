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

    protected override bool Eval() =>
        DateTime.Now > AlertingDate;
}
