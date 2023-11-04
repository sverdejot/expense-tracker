using System;
using System.Linq.Expressions;
using Domain.Shared.Base;

namespace Domain.Expenses;

public class FindExpenseByIdCriteria : Criteria<Expense>
{
    public FindExpenseByIdCriteria(ExpenseId id) : base(expense => expense.Id == id)
    {
    }
}

