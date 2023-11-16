using Bogus;
using Domain;
using Domain.Expenses;

namespace Unit;

public class ExpenseCreatedEventMother
{
    private readonly Faker<ExpenseCreatedEvent> faker = new Faker<ExpenseCreatedEvent>()
        .RuleFor(evnt => evnt.User, faker => faker.Random.Guid())
        .RuleFor(evnt => evnt.Id, faker => faker.Random.Guid())
        .RuleFor(evnt => evnt.Amount, faker => faker.Random.Decimal(max: 10_0))
        .RuleFor(evnt => evnt.CreatedAt, faker => faker.Date.Past());

    public ExpenseCreatedEvent Build() =>
        faker.Generate();

    public ExpenseCreatedEventMother WithAmount(decimal quantity)
    {
        faker.RuleFor(evnt => evnt.Amount, quantity);
        return this;
    }

    public ExpenseCreatedEventMother WithRandomAmountBetweenRange(double min = 0.0, double max = double.MaxValue)
    {
        faker.RuleFor(evnt => evnt.Amount, faker => faker.Random.Decimal(new decimal(min), new decimal(max)));
        return this;
    }

    public ExpenseCreatedEventMother WithAmountLessThan(double max = double.MaxValue)
    {
        faker.RuleFor(evnt => evnt.Amount, faker => faker.Random.Decimal(max: new decimal(max)));
        return this;
    }

    public static ExpenseCreatedEvent Random() =>
        new ExpenseCreatedEventMother().Build();
}
