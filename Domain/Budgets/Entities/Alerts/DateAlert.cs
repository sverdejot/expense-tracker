using Domain.Budget;

namespace Domain;

public class DateAlert : BudgetAlert
{
    public DateTime AlertingDate { get; private set; }

    private DateAlert()
    {
    }

    protected DateAlert(DateTime alertingDate) =>
        AlertingDate = alertingDate;

    public static DateAlert Create(DateTime alertingDate) =>
        new(alertingDate);

    protected override bool Eval() =>
        DateTime.Now > AlertingDate;
}
