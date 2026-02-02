using Axia.VehicleApi.Domain.Enums;

namespace Axia.VehicleApi.WebApi.Contracts.Veiculos;

public sealed record AtualizarVeiculoRequest(
    string Descricao,
    Marca Marca,
    string Modelo,
    string? Opcionais,
    decimal? Valor
);
