using Axia.VehicleApi.Domain.Interfaces;
using FluentValidation;

namespace Axia.VehicleApi.Application.Features.Usuarios.Commands;

public sealed class AdicionarUsuarioCommandValidator : AbstractValidator<AdicionarUsuarioCommand>
{
    public AdicionarUsuarioCommandValidator(IUsuarioRepository usuarioRepository)
    {
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage("Nome é obrigatório.")
            .MinimumLength(3).WithMessage("Nome deve ter no mínimo 3 caracteres.");

        RuleFor(x => x.Login)
            .NotEmpty().WithMessage("Login é obrigatório.")
            .MinimumLength(3).WithMessage("Login deve ter no mínimo 3 caracteres.")
            .MustAsync(async (login, ct) => !(await usuarioRepository.ExistsByLoginAsync(login, ct)))
            .WithMessage("Login já está em uso.");

        RuleFor(x => x.Senha)
            .NotEmpty().WithMessage("Senha é obrigatória.")
            .MinimumLength(6).WithMessage("Senha deve ter no mínimo 6 caracteres.");
    }
}
