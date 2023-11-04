namespace Domain.Budget;

public record BudgetPeriod
{
    private DateTime StartDate { get; set; } = DateTime.UtcNow;

    private DateTime EndDate { get; set; }

    public bool IsExpired =>
        StartDate >= DateTime.Now && DateTime.Now <= EndDate;

    private BudgetPeriod(DateTime end)
    {
        EndDate = end;
    }

    protected BudgetPeriod(DateTime start, DateTime end)
    {
        StartDate = start;
        EndDate = end;
    }

    public static BudgetPeriod Create(DateTime startDate, DateTime endDate)
    {
        return new(startDate, endDate);
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