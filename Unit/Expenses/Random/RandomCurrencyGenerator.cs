using Bogus;
using Domain.Shared.ValueObjects;

namespace Unit;

public static class RandomCurrencyGenerator
{
    public static Currency Random() =>
        new Faker().PickRandom<Currency>();
}
