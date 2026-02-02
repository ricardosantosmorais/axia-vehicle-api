using Axia.VehicleApi.Application.DTOs;
using Axia.VehicleApi.Application.Services;
using MediatR;

namespace Axia.VehicleApi.Application.Features.Veiculos.Queries;

public sealed class ObterVeiculoPorIdHandler : IRequestHandler<ObterVeiculoPorIdQuery, VeiculoDto>
{
    private readonly IVeiculoService _veiculoService;

    public ObterVeiculoPorIdHandler(IVeiculoService veiculoService)
    {
        _veiculoService = veiculoService;
    }

    public Task<VeiculoDto> Handle(ObterVeiculoPorIdQuery request, CancellationToken cancellationToken)
        => _veiculoService.GetByIdAsync(request.Id, cancellationToken);
}
