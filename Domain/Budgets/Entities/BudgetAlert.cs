namespace Domain.Budget;

public abstract class BudgetAlert
{
	protected BudgetAlert()
	{
	}

	public bool IsTriggered => Eval();

	protected abstract bool Eval();
}
