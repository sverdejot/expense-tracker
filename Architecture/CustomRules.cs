using Mono.Cecil;
using Mono.Cecil.Rocks;
using NetArchTest.Rules;

public static class NetArchTestRulesExtensions
{
    public static ConditionList HasPublicConstructor(this Conditions conditions)
    {
        return conditions.MeetCustomRule(new HasPublicConstructor());
    }
}

public class HasPublicConstructor : ICustomRule
{
    public bool MeetsRule(TypeDefinition type)
    {
        return type.GetConstructors().All(constructor => constructor.IsPublic);
    }
}