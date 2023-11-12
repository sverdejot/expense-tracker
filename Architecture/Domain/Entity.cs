using Domain.Shared.Base;
using NetArchTest.Rules;
using System.Reflection;

namespace Architecture.Domain;

public class TestEntity
{
    private static readonly Assembly Entity = typeof(Entity<>).Assembly;

    [Fact]
    public void Entities_ShouldNotHavePublicConstructor()
    {
        var result = Types.InAssembly(Entity)
            .That()
            .Inherit(typeof(Entity<>))
            .ShouldNot()
            .HasPublicConstructor()
            .GetResult()
            .IsSuccessful;

        Assert.Equal(result, true);
    }
}
