using Axia.VehicleApi.Application.DTOs;
using Axia.VehicleApi.Application.Services;
using MediatR;

namespace Axia.VehicleApi.Application.Features.Usuarios.Commands;

public sealed class AtualizarUsuarioHandler : IRequestHandler<AtualizarUsuarioCommand, UsuarioDto>
{
    private readonly IUsuarioService _usuarioService;

    public AtualizarUsuarioHandler(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    public Task<UsuarioDto> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        => _usuarioService.UpdateAsync(
            id: request.Id,
            nome: request.Nome,
            senha: request.Senha,
            role: request.Role,
            cancellationToken: cancellationToken);
}
