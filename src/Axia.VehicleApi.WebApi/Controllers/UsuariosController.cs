using Axia.VehicleApi.Application.Features.Usuarios.Commands;
using Axia.VehicleApi.Application.Features.Usuarios.Queries;
using Axia.VehicleApi.WebApi.Contracts.Usuarios;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Axia.VehicleApi.WebApi.Controllers;

[ApiController]
[Route("api/usuarios")]
public sealed class UsuariosController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsuariosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>Cadastra um novo usuário.</summary>
    [HttpPost]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarUsuarioRequest request, CancellationToken cancellationToken)
    {
        var usuario = await _mediator.Send(new AdicionarUsuarioCommand(request.Nome, request.Login, request.Senha), cancellationToken);

        return CreatedAtAction(nameof(ObterPorId), new { id = usuario.Id }, usuario);
    }

    /// <summary>Obtém usuário por Id.</summary>
    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterPorId([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var usuario = await _mediator.Send(new ObterUsuarioPorIdQuery(id), cancellationToken);
        return Ok(usuario);
    }

    /// <summary>Lista usuários (opcional no teste).</summary>
    [HttpGet]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Listar(CancellationToken cancellationToken)
    {
        var usuarios = await _mediator.Send(new ListarUsuariosQuery(), cancellationToken);
        return Ok(usuarios);
    }

    /// <summary>Atualiza usuário (opcional no teste).</summary>
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Atualizar([FromRoute] Guid id, [FromBody] AtualizarUsuarioRequest request, CancellationToken cancellationToken)
    {
        var usuario = await _mediator.Send(new AtualizarUsuarioCommand(id, request.Nome, request.Senha, request.Role), cancellationToken);
        return Ok(usuario);
    }

    /// <summary>Remove usuário (opcional no teste).</summary>
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Remover([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new ExcluirUsuarioCommand(id), cancellationToken);
        return NoContent();
    }
}
