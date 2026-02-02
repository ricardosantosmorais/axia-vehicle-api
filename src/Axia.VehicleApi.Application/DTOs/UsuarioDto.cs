namespace Axia.VehicleApi.Application.DTOs;

public sealed record UsuarioDto(
    Guid Id,
    string Nome,
    string Login,
    string Role
);
