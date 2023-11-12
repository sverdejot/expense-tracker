using Bogus;

namespace Unit.Random;

public static class RandomNumberGenerator
{
    public static Decimal Random(decimal min = 0, decimal max = decimal.MaxValue) =>
        new Faker().Random.Decimal(min, max);
}
