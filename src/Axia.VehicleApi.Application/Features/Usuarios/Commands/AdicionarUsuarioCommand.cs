using Axia.VehicleApi.Application.DTOs;
using MediatR;

namespace Axia.VehicleApi.Application.Features.Usuarios.Commands;

public sealed record AdicionarUsuarioCommand(
    string Nome,
    string Login,
    string Senha
) : IRequest<UsuarioDto>;
