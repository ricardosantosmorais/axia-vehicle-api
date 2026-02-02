using Axia.VehicleApi.Application.Services;
using MediatR;

namespace Axia.VehicleApi.Application.Features.Veiculos.Commands;

public sealed class ExcluirVeiculoHandler : IRequestHandler<ExcluirVeiculoCommand, Unit>
{
    private readonly IVeiculoService _veiculoService;

    public ExcluirVeiculoHandler(IVeiculoService veiculoService)
    {
        _veiculoService = veiculoService;
    }

    public async Task<Unit> Handle(ExcluirVeiculoCommand request, CancellationToken cancellationToken)
    {
        await _veiculoService.DeleteAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}
