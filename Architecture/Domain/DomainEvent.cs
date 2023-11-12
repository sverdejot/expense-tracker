using Domain.Shared.Base;
using NetArchTest.Rules;
using System.Reflection;

namespace Architecture.Domain;

public class TestDomainEvent
{
    private readonly Assembly Assembly = typeof(IDomainEvent).Assembly;

    [Fact]
    public void DomainEvent_ShouldBeSealed()
    {
        var result = Types.InAssembly(Assembly)
            .That()
            .ImplementInterface(typeof(IDomainEvent))
            .Should()
            .BeSealed()
            .GetResult()
            .IsSuccessful;

        Assert.Equal(result, true);
    }
}
