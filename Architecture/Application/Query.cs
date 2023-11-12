using Application.Shared.Query;
using NetArchTest.Rules;
using System.Reflection;

namespace Architecture.Application;

public class Query
{
    private readonly Assembly Assembly = typeof(IQuery<>).Assembly;

    [Fact]
    public void Query_ShouldBeSealed()
    {
        var result = Types.InAssembly(Assembly)
            .That()
            .ImplementInterface(typeof(IQuery<>))
            .Should()
            .BeSealed()
            .GetResult()
            .IsSuccessful;

        Assert.Equal(result, true);
    }
}
