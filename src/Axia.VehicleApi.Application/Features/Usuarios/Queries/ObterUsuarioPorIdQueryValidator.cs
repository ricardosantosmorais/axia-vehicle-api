using FluentValidation;

namespace Axia.VehicleApi.Application.Features.Usuarios.Queries;

public sealed class ObterUsuarioPorIdQueryValidator : AbstractValidator<ObterUsuarioPorIdQuery>
{
    public ObterUsuarioPorIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id é obrigatório.");
    }
}
