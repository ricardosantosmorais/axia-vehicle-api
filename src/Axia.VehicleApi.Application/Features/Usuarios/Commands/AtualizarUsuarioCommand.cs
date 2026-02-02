using Axia.VehicleApi.Application.DTOs;
using MediatR;

namespace Axia.VehicleApi.Application.Features.Usuarios.Commands;

public sealed record AtualizarUsuarioCommand(
    Guid Id,
    string Nome,
    string? Senha,
    string? Role
) : IRequest<UsuarioDto>;
