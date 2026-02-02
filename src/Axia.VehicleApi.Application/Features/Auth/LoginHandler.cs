using Axia.VehicleApi.Application.DTOs;
using Axia.VehicleApi.Application.Services;
using MediatR;

namespace Axia.VehicleApi.Application.Features.Auth;

public sealed class LoginHandler : IRequestHandler<LoginCommand, AuthResultDto>
{
    private readonly IUsuarioService _usuarioService;

    public LoginHandler(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    public Task<AuthResultDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        => _usuarioService.AuthenticateAsync(request.Login, request.Senha, cancellationToken);
}
