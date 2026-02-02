using Axia.VehicleApi.Application.DTOs;
using Axia.VehicleApi.Application.Services;
using MediatR;

namespace Axia.VehicleApi.Application.Features.Veiculos.Commands;

public sealed class AtualizarVeiculoHandler : IRequestHandler<AtualizarVeiculoCommand, VeiculoDto>
{
    private readonly IVeiculoService _veiculoService;

    public AtualizarVeiculoHandler(IVeiculoService veiculoService)
    {
        _veiculoService = veiculoService;
    }

    public Task<VeiculoDto> Handle(AtualizarVeiculoCommand request, CancellationToken cancellationToken)
        => _veiculoService.UpdateAsync(
            id: request.Id,
            descricao: request.Descricao,
            marca: request.Marca,
            modelo: request.Modelo,
            opcionais: request.Opcionais,
            valor: request.Valor,
            cancellationToken: cancellationToken);
}
