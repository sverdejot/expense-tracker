using System;
namespace Application.Expenses.Queries;

public record FindExpenseByIdResult(ExpenseDTO? Expense);