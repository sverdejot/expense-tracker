using Application.Shared.Command;
using NetArchTest.Rules;
using System.Reflection;

namespace Architecture.Application;

public class Command
{
    private readonly Assembly Assembly = typeof(ICommand).Assembly;

    [Fact]
    public void Command_ShouldBeSealed()
    {
        var result = Types.InAssembly(Assembly)
            .That()
            .ImplementInterface(typeof(ICommand))
            .Should()
            .BeSealed()
            .GetResult()
            .IsSuccessful;

        Assert.Equal(result, true);
    }
}
