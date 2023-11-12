using System.Net;
using System.Reflection.Metadata.Ecma335;
using Bogus;
using Domain.Expenses;
using Domain.Shared.ValueObjects;
using Unit.Random;

namespace Unit;

public class ExpenseMother
{
    private readonly Faker<Expense> faker = new Faker<Expense>()
        .UsePrivateConstructor()
        .RuleFor(
            expense => expense.Id,
            faker => ExpenseId.Create(faker.Random.Guid()))
        .RuleFor(
            expense => expense.Amount,
            faker => ExpenseAmount.Create(
                faker.Random.Decimal(1, 1000),
                faker.PickRandom<Currency>()))
        .RuleFor(
            expense => expense.Description,
            faker => ExpenseDescription.Create(faker.Lorem.Sentence()));

    public Expense Build() =>
        faker.Generate();

    public static Expense Random() =>
        new ExpenseMother().Build();
}
