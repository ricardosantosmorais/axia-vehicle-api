using Axia.VehicleApi.Application.DTOs;
using MediatR;

namespace Axia.VehicleApi.Application.Features.Veiculos.Queries;

public sealed record ObterVeiculoPorIdQuery(Guid Id) : IRequest<VeiculoDto>;
