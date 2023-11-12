using Application.Shared.Command;

namespace Application.Budgets;

public sealed record DeleteBudgetCommand(Guid Id) : ICommand;
