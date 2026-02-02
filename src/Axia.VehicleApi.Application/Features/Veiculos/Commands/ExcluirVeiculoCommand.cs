using MediatR;

namespace Axia.VehicleApi.Application.Features.Veiculos.Commands;

public sealed record ExcluirVeiculoCommand(Guid Id) : IRequest<Unit>;
