using Axia.VehicleApi.Application.DTOs;
using Axia.VehicleApi.Domain.Enums;

namespace Axia.VehicleApi.Application.Services;

public interface IVeiculoService
{
    Task<VeiculoDto> CreateAsync(string descricao, Marca marca, string modelo, string? opcionais, decimal? valor, CancellationToken cancellationToken);
    Task<VeiculoDto> UpdateAsync(Guid id, string descricao, Marca marca, string modelo, string? opcionais, decimal? valor, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    Task<VeiculoDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IReadOnlyList<VeiculoDto>> ListAsync(CancellationToken cancellationToken);
}
