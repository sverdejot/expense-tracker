using System.Security.Cryptography.X509Certificates;
using Bogus;
using Domain.Budgets;
using Domain.Shared.ValueObjects;

namespace Unit;

public class BudgetRecordMother
{
    private Faker<BudgetRecord> faker = new Faker<BudgetRecord>()
        .CustomInstantiator(faker =>
            BudgetRecord.Create(
                faker.Random.Guid(),
                faker.Random.Decimal(max: 100),
                faker.PickRandom<Currency>(),
                faker.Date.Past()));
    public static BudgetRecord Random() =>
        new BudgetRecordMother().Build();

    public BudgetRecordMother WithQuantity(Decimal quantity)
    {
        faker.RuleFor(record => record.Amount, quantity);
        return this;
    }

    public BudgetRecord Build()
    {
        return faker.Generate();
    }

    public static List<BudgetRecord> RecordListUpToQuantity(decimal quantity = 1_000)
    {
        var mother = new BudgetRecordMother();
        var currentSum = 0;
        var targetSum = quantity;
        var random = new Faker();
        var qs = Enumerable.Range(1, int.MaxValue)
            .Select(_ =>
            {
                return random.Random.Number(1, (int)Math.Floor(Math.Min(targetSum - currentSum, 10) + 1));
            })
            .TakeWhile(value => (currentSum += value) < targetSum)
            .ToList();

        var records = new List<BudgetRecord>(qs.Count);
        foreach (var q in qs)
        {
            records.Add(mother.WithQuantity(q).Build());
        }
        return records;
    }

}
