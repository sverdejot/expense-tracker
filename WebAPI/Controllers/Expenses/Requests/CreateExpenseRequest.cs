namespace WebAPI.Controllers.Expenses;

public record CreateExpenseRequest(AmountDTO Amount, string Description);

