using Axia.VehicleApi.Application.DTOs;
using Axia.VehicleApi.Application.Services;
using MediatR;

namespace Axia.VehicleApi.Application.Features.Usuarios.Commands;

public sealed class AdicionarUsuarioHandler : IRequestHandler<AdicionarUsuarioCommand, UsuarioDto>
{
    private readonly IUsuarioService _usuarioService;

    public AdicionarUsuarioHandler(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    public Task<UsuarioDto> Handle(AdicionarUsuarioCommand request, CancellationToken cancellationToken)
        => _usuarioService.CreateAsync(
            nome: request.Nome,
            login: request.Login,
            senha: request.Senha,
            role: "User",
            cancellationToken: cancellationToken);
}
