namespace WebAPI.Controllers.Expenses;


public record FindExpenseResponse(Guid ExpenseId, AmountDTO Amount, string Description);
