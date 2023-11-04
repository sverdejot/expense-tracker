using Application.Shared.Command;

namespace Application.Expenses.Commands;

public record DeleteExpenseCommand(Guid Id) : ICommand;