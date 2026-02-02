using Axia.VehicleApi.Application.DTOs;
using Axia.VehicleApi.Application.Services;
using MediatR;

namespace Axia.VehicleApi.Application.Features.Usuarios.Queries;

public sealed class ObterUsuarioPorIdHandler : IRequestHandler<ObterUsuarioPorIdQuery, UsuarioDto>
{
    private readonly IUsuarioService _usuarioService;

    public ObterUsuarioPorIdHandler(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    public Task<UsuarioDto> Handle(ObterUsuarioPorIdQuery request, CancellationToken cancellationToken)
        => _usuarioService.GetByIdAsync(request.Id, cancellationToken);
}
