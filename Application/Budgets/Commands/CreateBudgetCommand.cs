using Domain.Shared.ValueObjects;
using Application.Shared.Command;

namespace Application.Budgets;

public record CreateBudgetCommand(Guid Id, Decimal MaximumAmount, Currency Currency) : ICommand;