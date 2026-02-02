using Axia.VehicleApi.Application.DTOs;
using Axia.VehicleApi.Application.Services;
using MediatR;

namespace Axia.VehicleApi.Application.Features.Veiculos.Commands;

public sealed class AdicionarVeiculoHandler : IRequestHandler<AdicionarVeiculoCommand, VeiculoDto>
{
    private readonly IVeiculoService _veiculoService;

    public AdicionarVeiculoHandler(IVeiculoService veiculoService)
    {
        _veiculoService = veiculoService;
    }

    public Task<VeiculoDto> Handle(AdicionarVeiculoCommand request, CancellationToken cancellationToken)
        => _veiculoService.CreateAsync(
            descricao: request.Descricao,
            marca: request.Marca,
            modelo: request.Modelo,
            opcionais: request.Opcionais,
            valor: request.Valor,
            cancellationToken: cancellationToken);
}
