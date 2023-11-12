namespace Domain.Budgets;

public record BudgetPeriod
{
    public DateTime StartDate { get; private set; } = DateTime.UtcNow;

    public DateTime EndDate { get; private set; }

    public bool IsExpired =>
        StartDate >= DateTime.Now && DateTime.Now <= EndDate;

    protected BudgetPeriod(DateTime end)
    {
        EndDate = end;
    }

    protected BudgetPeriod(DateTime startDate, DateTime endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }

    public static BudgetPeriod Create(DateTime startDate, DateTime endDate)
    {
        return new(startDate, endDate);
    }

    public static BudgetPeriod Create(DateTime endDate)
    {
        return new(endDate);
    }

    public static BudgetPeriod CreateMonthly()
    {
        return new(DateTime.Now.AddMonths(1));
    }

    public static BudgetPeriod CreateAnnualy()
    {
        return new(DateTime.Now.AddYears(1));
    }
}