namespace Domain.Budget;

public abstract class BudgetAlert
{
	public bool IsTriggered => Eval();

	protected abstract bool Eval();
}
