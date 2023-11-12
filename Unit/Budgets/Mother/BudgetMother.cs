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

    public BudgetMother WithId()
    {
        faker.RuleFor(budget => budget.Id, BudgetId.Create(Guid.NewGuid()));
        return this;
    }

    public BudgetMother WithRecordsReachingLimit(int offsetToMax = 1)
    {
        // TODO: Such a mess
        faker.RuleFor(
            budget => budget.Records,
            (faker, budget) =>
            {
                var almostMaximumAmount = budget.MaximumAmount.Amount - offsetToMax;
                var rec = new List<BudgetRecord>();
                while (almostMaximumAmount > 0)
                {
                    var newRecord = BudgetRecordMother.Random();

                    if (almostMaximumAmount - newRecord.Amount < 0)
                    {
                        var lastRecord = new BudgetRecordMother()
                            .WithQuantity(almostMaximumAmount)
                            .Build();

                        rec.Add(lastRecord);
                        break;
                    }

                    rec.Add(newRecord);
                }

                return rec;
            }
        );

        return this;
    }
}
