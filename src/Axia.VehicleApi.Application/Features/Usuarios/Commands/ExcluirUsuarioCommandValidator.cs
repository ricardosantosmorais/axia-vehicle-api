using FluentValidation;

namespace Axia.VehicleApi.Application.Features.Usuarios.Commands;

public sealed class ExcluirUsuarioCommandValidator : AbstractValidator<ExcluirUsuarioCommand>
{
    public ExcluirUsuarioCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id é obrigatório.");
    }
}
