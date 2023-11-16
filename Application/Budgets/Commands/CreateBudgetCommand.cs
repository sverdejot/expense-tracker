using Domain.Shared.ValueObjects;
using Application.Shared.Command;

namespace Application.Budgets;

public sealed record CreateBudgetCommand(Guid Id, Decimal MaximumAmount, Currency Currency, Guid Owner) : ICommand;