using Axia.VehicleApi.Domain.Entities;

namespace Axia.VehicleApi.Domain.Interfaces;

public interface IVeiculoRepository
{
    Task AddAsync(Veiculo veiculo, CancellationToken cancellationToken);
    Task UpdateAsync(Veiculo veiculo, CancellationToken cancellationToken);
    Task DeleteAsync(Veiculo veiculo, CancellationToken cancellationToken);

    Task<Veiculo?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<Veiculo>> ListAsync(CancellationToken cancellationToken);
}
