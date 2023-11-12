using NetArchTest.Rules;
using NetArchTest.Rules.Policies;
using System.Reflection;
using ApplicationDI = Application.DependencyInjection;

namespace Architecture;

public static class ArchitectureExtensions
{
    public static PolicyDefinition ShouldNotHaveDependencyOnInfrastructureLayer(this PolicyDefinition definition)
    {
        definition
            .ShouldNotHaveDependencyOn(typeof(Infrastructure.DependencyInjection).Assembly);
        return definition;
    }

    public static PolicyDefinition ShouldNotHaveDependencyOnPersistanceLayer(this PolicyDefinition definition)
    {
        definition
            .ShouldNotHaveDependencyOn(typeof(Persistance.DependencyInjection).Assembly);
        return definition;
    }

    public static PolicyDefinition ShouldNotHaveDependencyOnAPILayer(this PolicyDefinition definition)
    {
        definition
            .ShouldNotHaveDependencyOn(typeof(WebAPI.DependencyInjection).Assembly);
        return definition;
    }

    public static PolicyDefinition ShouldNotHaveDependencyOnApplicationLayer(this PolicyDefinition definition)
    {
        definition
            .ShouldNotHaveDependencyOn(typeof(ApplicationDI).Assembly);
        return definition;
    }

    public static PolicyDefinition ShouldNotHaveDependencyOn(this PolicyDefinition definition, Assembly assembly)
    {
        definition.Add(
                types => types.ShouldNot().HaveDependencyOnAny(GetNamespacesFromAssembly(assembly)),
                "Enforcing layered architecture",
                $"Application should not have dependencies on {assembly.GetType().Namespace} layer");
        return definition;
    }

    private static string?[] GetNamespacesFromAssembly(Assembly assembly) =>
        Types.InAssembly(assembly)
            .GetTypes()
            .Where(type => type.Namespace is not null)
            .Select(type => type.Namespace)
            .Distinct()
            .ToArray();
}
