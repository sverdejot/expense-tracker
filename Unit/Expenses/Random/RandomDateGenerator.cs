using Bogus;

namespace Unit;

public class RandomDateGenerator
{
    public static DateTime Future() =>
        new Faker().Date.Future();
}
