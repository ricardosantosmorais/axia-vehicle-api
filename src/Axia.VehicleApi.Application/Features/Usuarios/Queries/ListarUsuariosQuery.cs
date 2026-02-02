using Axia.VehicleApi.Application.DTOs;
using MediatR;

namespace Axia.VehicleApi.Application.Features.Usuarios.Queries;

public sealed record ListarUsuariosQuery() : IRequest<IReadOnlyList<UsuarioDto>>;
