using System;
using Application.Expenses.Commands;
using Application.Expenses.Queries;
using Domain.Shared.ValueObjects;
using Mapster;

namespace WebAPI.Controllers.Expenses.Mappings;

public class ExpenseMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(Guid Id, CreateExpenseRequest Request), CreateExpenseCommand>()
            .Map(command => command.Id, request => request.Id)
            .Map(command => command.Amount, request => request.Request.Amount.Quantity)
            .Map(command => command.Currency, request => Enum.Parse<Currency>(request.Request.Amount.Currency))
            .Map(command => command.Description, request => request.Request.Description);

        config.NewConfig<Guid, FindExpenseByIdQuery>()
            .Map(query => query.Id, id => id);

        config.NewConfig<FindExpenseByIdResult, FindExpenseResponse>()
            .Map(response => response, result => result.Expense);

        config.NewConfig<Guid, DeleteExpenseCommand>()
            .Map(command => command.Id, id => id);
    }
}

