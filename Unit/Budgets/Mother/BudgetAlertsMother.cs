using Bogus;
using Domain;
using Domain.Budgets;

namespace Unit;

public class BudgetAlertsMother
{
    public static DateBudgetAlert CreateDateOverdue()
    {
        return new Faker<DateBudgetAlert>()
            .UsePrivateConstructor()
            .RuleFor(alert => alert.AlertingDate,
                faker => faker.Date.Past())
            .Generate();
    }
}
