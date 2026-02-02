using Axia.VehicleApi.Domain.Entities;

namespace Axia.VehicleApi.Domain.Interfaces;

public interface IUsuarioRepository
{
    Task AddAsync(Usuario usuario, CancellationToken cancellationToken);
    Task UpdateAsync(Usuario usuario, CancellationToken cancellationToken);
    Task DeleteAsync(Usuario usuario, CancellationToken cancellationToken);

    Task<Usuario?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Usuario?> GetByLoginAsync(string login, CancellationToken cancellationToken);
    Task<bool> ExistsByLoginAsync(string login, CancellationToken cancellationToken);

    Task<IReadOnlyList<Usuario>> ListAsync(CancellationToken cancellationToken);
}
