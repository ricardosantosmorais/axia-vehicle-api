namespace Axia.VehicleApi.WebApi.Contracts.Usuarios;

public sealed record AtualizarUsuarioRequest(string Nome, string? Senha, string? Role);
