using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System.Reflection;
using WebAPI.Middleware;

namespace WebAPI;

public static class DependencyInjection
{
    public static readonly Assembly Assembly = typeof(DependencyInjection).Assembly;

    public static IServiceCollection AddMiddleware(this IServiceCollection services)
    {
        services.AddTransient<GlobalExceptionHandlingMiddleware>();

        return services;
    }

    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var mappingConfig = TypeAdapterConfig.GlobalSettings;

        mappingConfig.Scan(Assembly);

        services.AddSingleton(mappingConfig);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}
