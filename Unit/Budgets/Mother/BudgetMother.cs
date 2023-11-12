using System.Diagnostics.Tracing;
using Bogus;
using Bogus.Extensions.Norway;
using Domain.Budget;
using Domain.Shared.ValueObjects;
using Unit.Random;

namespace Unit;

public class BudgetMother
{
    private Faker<Budget> faker = new Faker<Budget>()
        .UsePrivateConstructor()
                .RuleFor(
                    budget => budget.Id,
                    faker => BudgetId.Create(faker.Random.Guid()))
                .RuleFor(
                    budget => budget.MaximumAmount,
                    faker => BudgetAmount.Create(
                        faker.Random.Decimal(1, 1000),
                        faker.PickRandom<Currency>()))
                .RuleFor(
                    budget => budget.Period,
                    faker => BudgetPeriod.Create(faker.Date.Future()));

    public Budget Build() =>
        faker.Generate();

    public static Budget Random() =>
        new BudgetMother().Build();

    public BudgetMother WithAmount(decimal quantity)
    {
        faker.RuleFor(
            budget => budget.MaximumAmount,
            faker => BudgetAmount.Create(quantity, faker.PickRandom<Currency>()));
        return this;
    }

    public BudgetMother WithId()
    {
        faker.RuleFor(budget => budget.Id, BudgetId.Create(Guid.NewGuid()));
        return this;
    }

    public BudgetMother WithRecordsReachingLimit()
    {
        faker.RuleFor(
            budget => budget.Records,
            (faker, budget) => BudgetRecordMother.RecordListUpToQuantity(budget.MaximumAmount.Amount - 1));
        return this;
    }

    public BudgetMother WithRecordsAtLimit()
    {
        faker.RuleFor(
            budget => budget.Records,
            (faker, budget) => BudgetRecordMother.RecordListUpToQuantity(budget.MaximumAmount.Amount));
        return this;
    }

    public BudgetMother WithAlert(BudgetAlert alert)
    {
        faker.FinishWith((faker, budget) => budget.Alerts.Add(alert));
        return this;
    }
}
