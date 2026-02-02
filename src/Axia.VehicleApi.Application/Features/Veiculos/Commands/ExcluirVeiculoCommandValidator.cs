using FluentValidation;

namespace Axia.VehicleApi.Application.Features.Veiculos.Commands;

public sealed class ExcluirVeiculoCommandValidator : AbstractValidator<ExcluirVeiculoCommand>
{
    public ExcluirVeiculoCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id é obrigatório.");
    }
}
