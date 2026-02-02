using Axia.VehicleApi.Application.DTOs;

namespace Axia.VehicleApi.Application.Services;

public interface IUsuarioService
{
    Task<UsuarioDto> CreateAsync(string nome, string login, string senha, string role, CancellationToken cancellationToken);
    Task<UsuarioDto> UpdateAsync(Guid id, string nome, string? senha, string? role, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<UsuarioDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<UsuarioDto>> ListAsync(CancellationToken cancellationToken);

    Task<AuthResultDto> AuthenticateAsync(string login, string senha, CancellationToken cancellationToken);
}
