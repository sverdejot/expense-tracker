using Application.Shared.Command;

namespace Application.Expenses.Commands;

public sealed record DeleteExpenseCommand(Guid Id) : ICommand;