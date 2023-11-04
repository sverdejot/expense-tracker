namespace WebAPI.Middleware;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder builder)
    {
        return builder
             .UseMiddleware<GlobalExceptionHandlingMiddleware>();
    }
}
