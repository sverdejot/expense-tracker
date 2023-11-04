using Application.Shared.Command;
using Domain.Shared.ValueObjects;

namespace Application.Expenses.Commands;

public record CreateExpenseCommand(Guid Id, decimal Amount, Currency Currency, string Description) : ICommand;
