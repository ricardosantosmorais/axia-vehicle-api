namespace Axia.VehicleApi.Application.DTOs;

public sealed record AuthResultDto(
    string Token,
    DateTimeOffset ExpiresAt,
    Guid UsuarioId,
    string Login,
    string Role
);
