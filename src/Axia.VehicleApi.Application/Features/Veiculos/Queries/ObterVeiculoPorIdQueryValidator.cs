using FluentValidation;

namespace Axia.VehicleApi.Application.Features.Veiculos.Queries;

public sealed class ObterVeiculoPorIdQueryValidator : AbstractValidator<ObterVeiculoPorIdQuery>
{
    public ObterVeiculoPorIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id é obrigatório.");
    }
}
