using Axia.VehicleApi.Domain.Enums;

namespace Axia.VehicleApi.Application.DTOs;

public sealed record VeiculoDto(
    Guid Id,
    string Descricao,
    Marca Marca,
    string Modelo,
    string? Opcionais,
    decimal? Valor
);
