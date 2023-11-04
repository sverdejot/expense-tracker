using Domain.Shared.Base;

namespace Domain.Budget;

public class Budget : AggregateRoot<Budget>
{
	public BudgetId Id { get; private set; }

	public BudgetAmount MaximumAmount { get; private set; }

	public BudgetPeriod Period { get; private set; }

	//public List<BudgetAlert> Alerts { get; private set; } = new();

	//public List<BudgetRecord> Records { get; private set; } = new();

    protected Budget(BudgetId id, BudgetAmount maximumAmount, BudgetPeriod period)
    {
        Id = id;
        MaximumAmount = maximumAmount;
		Period = period;
    }

	public static Budget Create(BudgetId id, BudgetAmount maximumAmount, BudgetPeriod period)
	{
		var budget = new Budget(id, maximumAmount, period);

		budget.RecordEvent(new BudgetCreatedEvent(id.Value));

		return budget;
	}
}

