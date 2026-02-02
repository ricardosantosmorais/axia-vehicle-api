using Axia.VehicleApi.Application.Services;
using Axia.VehicleApi.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Axia.VehicleApi.WebApi.Seeding;

public static class SeedExtensions
{
    /// <summary>
    /// Seed de usuário admin no EF InMemory (extra bem-vindo no teste).
    /// Login: admin | Senha: Admin@123
    /// </summary>
    public static async Task SeedAdminUserAsync(this IServiceProvider services)
    {
        using var scope = services.CreateScope();

        var repo = scope.ServiceProvider.GetRequiredService<IUsuarioRepository>();
        var exists = await repo.ExistsByLoginAsync("admin", CancellationToken.None);
        if (exists) return;

        var usuarioService = scope.ServiceProvider.GetRequiredService<IUsuarioService>();
        await usuarioService.CreateAsync(
            nome: "Administrador",
            login: "admin",
            senha: "Admin@123",
            role: "Admin",
            cancellationToken: CancellationToken.None);
    }
}
