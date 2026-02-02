using Axia.VehicleApi.Application.DTOs;
using MediatR;

namespace Axia.VehicleApi.Application.Features.Veiculos.Queries;

public sealed record ListarVeiculosQuery() : IRequest<IReadOnlyList<VeiculoDto>>;
