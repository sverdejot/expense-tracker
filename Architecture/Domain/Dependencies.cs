using NetArchTest.Rules;
using NetArchTest.Rules.Policies;
using Domain.Shared.Base;

namespace Architecture.Domain;

public class Dependencies
{
    [Fact]
    public void Domain_ShouldNotHaveReferences_OuterLayers()
    {
        var outerLayersPolicy = Policy.Define(
                "Outer layers dependencies",
                "An inner layer should not have dependencies on outer layers")
            .For(Types.InAssembly(typeof(Entity<>).Assembly))
            .ShouldNotHaveDependencyOnInfrastructureLayer()
            .ShouldNotHaveDependencyOnPersistanceLayer()
            .ShouldNotHaveDependencyOnApplicationLayer()
            .ShouldNotHaveDependencyOnAPILayer();

        var result = outerLayersPolicy.Evaluate()
            .Results.All(result => result.IsSuccessful);

        Assert.True(result);
    }
}
