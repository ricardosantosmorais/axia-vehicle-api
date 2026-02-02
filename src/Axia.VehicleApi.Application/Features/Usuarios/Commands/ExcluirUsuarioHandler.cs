using Axia.VehicleApi.Application.Services;
using MediatR;

namespace Axia.VehicleApi.Application.Features.Usuarios.Commands;

public sealed class ExcluirUsuarioHandler : IRequestHandler<ExcluirUsuarioCommand, Unit>
{
    private readonly IUsuarioService _usuarioService;

    public ExcluirUsuarioHandler(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    public async Task<Unit> Handle(ExcluirUsuarioCommand request, CancellationToken cancellationToken)
    {
        await _usuarioService.DeleteAsync(request.Id, cancellationToken);
        return Unit.Value;
    }
}
