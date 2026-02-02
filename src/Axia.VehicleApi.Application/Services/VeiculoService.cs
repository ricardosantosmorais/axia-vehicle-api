using Axia.VehicleApi.Application.Common.Exceptions;
using Axia.VehicleApi.Application.DTOs;
using Axia.VehicleApi.Domain.Entities;
using Axia.VehicleApi.Domain.Enums;
using Axia.VehicleApi.Domain.Interfaces;

namespace Axia.VehicleApi.Application.Services;

public sealed class VeiculoService : IVeiculoService
{
    private readonly IVeiculoRepository _veiculoRepository;

    public VeiculoService(IVeiculoRepository veiculoRepository)
    {
        _veiculoRepository = veiculoRepository;
    }

    public async Task<VeiculoDto> CreateAsync(string descricao, Marca marca, string modelo, string? opcionais, decimal? valor, CancellationToken cancellationToken)
    {
        var veiculo = new Veiculo(Guid.NewGuid(), descricao, marca, modelo, opcionais, valor);
        await _veiculoRepository.AddAsync(veiculo, cancellationToken);
        return ToDto(veiculo);
    }

    public async Task<VeiculoDto> UpdateAsync(Guid id, string descricao, Marca marca, string modelo, string? opcionais, decimal? valor, CancellationToken cancellationToken)
    {
        var veiculo = await _veiculoRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException("Veículo não encontrado.");

        veiculo.Atualizar(descricao, marca, modelo, opcionais, valor);

        await _veiculoRepository.UpdateAsync(veiculo, cancellationToken);

        return ToDto(veiculo);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var veiculo = await _veiculoRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException("Veículo não encontrado.");

        await _veiculoRepository.DeleteAsync(veiculo, cancellationToken);
    }

    public async Task<VeiculoDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var veiculo = await _veiculoRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException("Veículo não encontrado.");

        return ToDto(veiculo);
    }

    public async Task<IReadOnlyList<VeiculoDto>> ListAsync(CancellationToken cancellationToken)
    {
        var veiculos = await _veiculoRepository.ListAsync(cancellationToken);
        return veiculos.Select(ToDto).ToList();
    }

    private static VeiculoDto ToDto(Veiculo v) => new(v.Id, v.Descricao, v.Marca, v.Modelo, v.Opcionais, v.Valor);
}
