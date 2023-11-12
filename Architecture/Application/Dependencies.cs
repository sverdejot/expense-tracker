using NetArchTest.Rules;
using NetArchTest.Rules.Policies;
using ApplicationDI = Application.DependencyInjection;

namespace Architecture.Application;

public class Dependencies
{
    

    [Fact]
    public void Application_ShouldNotHaveReferences_OuterLayers()
    {
        var outerLayersPolicy = Policy.Define(
                "Outer layers dependencies", 
                "An inner layer should not have dependencies on outer layers")
            .For(Types.InAssembly(typeof(ApplicationDI).Assembly))
            .ShouldNotHaveDependencyOnInfrastructureLayer()
            .ShouldNotHaveDependencyOnPersistanceLayer()
            .ShouldNotHaveDependencyOnAPILayer();

        var result = outerLayersPolicy.Evaluate()
            .Results.All(result => result.IsSuccessful);

        Assert.True(result);
    }
}
