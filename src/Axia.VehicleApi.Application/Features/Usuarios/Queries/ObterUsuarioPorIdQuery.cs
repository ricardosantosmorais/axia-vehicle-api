using Axia.VehicleApi.Application.DTOs;
using MediatR;

namespace Axia.VehicleApi.Application.Features.Usuarios.Queries;

public sealed record ObterUsuarioPorIdQuery(Guid Id) : IRequest<UsuarioDto>;
