using Axia.VehicleApi.Application.Features.Veiculos.Commands;
using Axia.VehicleApi.Application.Features.Veiculos.Queries;
using Axia.VehicleApi.WebApi.Contracts.Veiculos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Axia.VehicleApi.WebApi.Controllers;

[ApiController]
[Route("api/veiculos")]
[Authorize]
public sealed class VeiculosController : ControllerBase
{
    private readonly IMediator _mediator;

    public VeiculosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>Cadastra veículo (protegido por JWT).</summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Cadastrar([FromBody] CadastrarVeiculoRequest request, CancellationToken cancellationToken)
    {
        var veiculo = await _mediator.Send(
            new AdicionarVeiculoCommand(request.Descricao, request.Marca, request.Modelo, request.Opcionais, request.Valor),
            cancellationToken);

        return CreatedAtAction(nameof(ObterPorId), new { id = veiculo.Id }, veiculo);
    }

    /// <summary>Atualiza veículo (protegido por JWT).</summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Atualizar([FromRoute] Guid id, [FromBody] AtualizarVeiculoRequest request, CancellationToken cancellationToken)
    {
        var veiculo = await _mediator.Send(
            new AtualizarVeiculoCommand(id, request.Descricao, request.Marca, request.Modelo, request.Opcionais, request.Valor),
            cancellationToken);

        return Ok(veiculo);
    }

    /// <summary>Obtém veículo por Id (protegido por JWT).</summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ObterPorId([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var veiculo = await _mediator.Send(new ObterVeiculoPorIdQuery(id), cancellationToken);
        return Ok(veiculo);
    }

    /// <summary>Lista veículos (protegido por JWT).</summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Listar(CancellationToken cancellationToken)
    {
        var veiculos = await _mediator.Send(new ListarVeiculosQuery(), cancellationToken);
        return Ok(veiculos);
    }

    /// <summary>Remove veículo (protegido por JWT).</summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Remover([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new ExcluirVeiculoCommand(id), cancellationToken);
        return NoContent();
    }
}
