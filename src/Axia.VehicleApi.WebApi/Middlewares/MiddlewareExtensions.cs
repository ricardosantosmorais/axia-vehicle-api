using Microsoft.Extensions.DependencyInjection;

namespace Axia.VehicleApi.WebApi.Middlewares;

public static class MiddlewareExtensions
{
    public static IServiceCollection AddWebApiMiddlewares(this IServiceCollection services)
    {
        services.AddTransient<ExceptionHandlingMiddleware>();
        return services;
    }
}
