﻿using Domain.Shared.Base;

namespace Domain.Budgets;

public abstract class BudgetAlert
{
	protected BudgetAlert()
	{
	}

	public abstract AlertEvent GenerateEvent(Budget budget);

	public abstract bool Eval(Budget budget);
}
