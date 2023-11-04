﻿using Domain.Budget;
using Application.Shared.Command;

namespace Application.Budgets;

public class CreateBudgetCommandHandler : ICommandHandler<CreateBudgetCommand>
{
    private readonly IBudgetRepository _budgetRepository;

    public CreateBudgetCommandHandler(IBudgetRepository budgetRepository)
    {
        _budgetRepository = budgetRepository;
    }

    public async Task Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
    {
        var id = new BudgetId(request.Id);
        var amount = new BudgetAmount(request.MaximumAmount, request.Currency);
        var period = BudgetPeriod.CreateMonthly();

        var budget = Budget.Create(id, amount, period);

        await _budgetRepository.Add(budget);
    }
}