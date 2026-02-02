using Axia.VehicleApi.Domain.Enums;
using FluentValidation;

namespace Axia.VehicleApi.Application.Features.Veiculos.Commands;

public sealed class AdicionarVeiculoCommandValidator : AbstractValidator<AdicionarVeiculoCommand>
{
    public AdicionarVeiculoCommandValidator()
    {
        RuleFor(x => x.Descricao)
            .NotEmpty().WithMessage("Descrição é obrigatória.")
            .MaximumLength(100).WithMessage("Descrição deve ter no máximo 100 caracteres.");

        RuleFor(x => x.Modelo)
            .NotEmpty().WithMessage("Modelo é obrigatório.")
            .MaximumLength(30).WithMessage("Modelo deve ter no máximo 30 caracteres.");

        RuleFor(x => x.Marca)
            .IsInEnum().WithMessage("Marca inválida.")
            .Must(m => m != Marca.NaoInformado).WithMessage("Marca é obrigatória.");
    }
}
