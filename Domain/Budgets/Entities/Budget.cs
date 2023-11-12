using Domain.Shared.Base;

namespace Domain.Budget;

public class Budget : AggregateRoot<Budget>
{
	#region Properties
	public BudgetId Id { get; private set; }

	public BudgetAmount MaximumAmount { get; private set; }

	private decimal RemainingAmountAfter(Decimal amount) => MaximumAmount.Amount - Records.Sum(r => r.Amount) - amount;

	private bool BudgetIsBlocked =>
		MaximumAmount.Amount - Records.Sum(r => r.Amount) < 0;

	public BudgetPeriod Period { get; private set; }

	public List<BudgetAlert> Alerts { get; private set; } = new();

	public List<BudgetRecord> Records { get; private set; } = new();
	#endregion

	#region Named Constructors

	private Budget()
	{
	}

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
	#endregion

	public void RecordNew(BudgetRecord record)
	{
		if (BudgetIsBlocked)
		{
			throw new BudgetIsBlockedException(LastRecord: Records.OrderByDescending(record => record.Created).First());
		}
		if (RemainingAmountAfter(record.Amount) < 0)
		{
			var currentTotalAmount = MaximumAmount.Amount + Math.Abs(RemainingAmountAfter(record.Amount));
			RecordEvent(new BudgetLimitExceededEvent(BudgetId: Id.Value, AmountLimit: MaximumAmount.Amount, CurrentAmount: currentTotalAmount));
		}

		EvaluateAlerts();

		Records.Add(record);
	}

	private void EvaluateAlerts()
	{
		var events = Alerts
			.Where(alert => alert.Eval(this))
			.Select(alert => alert.GenerateEvent(this))
			.ToList();
		
		foreach (var evnt in events)
		{
			RecordEvent(evnt);
		}
	}
}

