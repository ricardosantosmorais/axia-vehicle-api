using MediatR;

namespace Axia.VehicleApi.Application.Features.Usuarios.Commands;

public sealed record ExcluirUsuarioCommand(Guid Id) : IRequest<Unit>;
