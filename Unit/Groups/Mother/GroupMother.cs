using Bogus;
using Domain;
using Domain.Groups;

namespace Unit;

public class GroupMother
{
    private readonly Faker<Group> faker = new Faker<Group>()
        .UsePrivateConstructor()
        .RuleFor(x => x.Id, f => GroupId.Create(f.Random.Guid()))
        .RuleFor(x => x.Name, f => GroupName.Create(f.Lorem.Word()))
        .RuleFor(x => x.Admin, f => UserId.Create(f.Random.Guid()));

    public Group Build() => faker.Generate();

    public static Group Random() => 
        new GroupMother().Build();
}
