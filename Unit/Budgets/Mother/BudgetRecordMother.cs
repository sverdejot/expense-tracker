using System.Security.Cryptography.X509Certificates;
using Bogus;
using Domain.Budget;
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

}
