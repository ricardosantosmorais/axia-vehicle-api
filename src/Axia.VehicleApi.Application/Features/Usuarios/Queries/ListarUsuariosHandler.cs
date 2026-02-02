using Axia.VehicleApi.Application.DTOs;
using Axia.VehicleApi.Application.Services;
using MediatR;

namespace Axia.VehicleApi.Application.Features.Usuarios.Queries;

public sealed class ListarUsuariosHandler : IRequestHandler<ListarUsuariosQuery, IReadOnlyList<UsuarioDto>>
{
    private readonly IUsuarioService _usuarioService;

    public ListarUsuariosHandler(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    public Task<IReadOnlyList<UsuarioDto>> Handle(ListarUsuariosQuery request, CancellationToken cancellationToken)
        => _usuarioService.ListAsync(cancellationToken);
}
