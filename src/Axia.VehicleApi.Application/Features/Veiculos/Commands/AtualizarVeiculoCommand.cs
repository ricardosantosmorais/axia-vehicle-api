using Axia.VehicleApi.Application.DTOs;
using Axia.VehicleApi.Domain.Enums;
using MediatR;

namespace Axia.VehicleApi.Application.Features.Veiculos.Commands;

public sealed record AtualizarVeiculoCommand(
    Guid Id,
    string Descricao,
    Marca Marca,
    string Modelo,
    string? Opcionais,
    decimal? Valor
) : IRequest<VeiculoDto>;
