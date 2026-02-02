using Axia.VehicleApi.Application.DTOs;
using Axia.VehicleApi.Application.Services;
using MediatR;

namespace Axia.VehicleApi.Application.Features.Veiculos.Queries;

public sealed class ListarVeiculosHandler : IRequestHandler<ListarVeiculosQuery, IReadOnlyList<VeiculoDto>>
{
    private readonly IVeiculoService _veiculoService;

    public ListarVeiculosHandler(IVeiculoService veiculoService)
    {
        _veiculoService = veiculoService;
    }

    public Task<IReadOnlyList<VeiculoDto>> Handle(ListarVeiculosQuery request, CancellationToken cancellationToken)
        => _veiculoService.ListAsync(cancellationToken);
}
