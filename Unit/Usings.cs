global using Xunit;
using MapsterMapper;

public static class TestingExtensions
{
    public static Mapper GetMapper()
    {
        return new Mapper(Application.DependencyInjection.GetMappingConfiguration());
    }
}