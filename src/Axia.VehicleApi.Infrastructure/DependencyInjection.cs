using Axia.VehicleApi.Domain.Interfaces;
using Axia.VehicleApi.Infrastructure.Persistence;
using Axia.VehicleApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Axia.VehicleApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // EF Core InMemory obrigatório no teste
        services.AddDbContext<AxiaDbContext>(options =>
            options.UseInMemoryDatabase("AxiaVehicleDb"));

        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IVeiculoRepository, VeiculoRepository>();

        return services;
    }
}
