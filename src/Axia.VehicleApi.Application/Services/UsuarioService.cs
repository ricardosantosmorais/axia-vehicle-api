using Axia.VehicleApi.Application.Auth;
using Axia.VehicleApi.Application.Common.Exceptions;
using Axia.VehicleApi.Application.DTOs;
using Axia.VehicleApi.Domain.Entities;
using Axia.VehicleApi.Domain.Interfaces;
using BCrypt.Net;

namespace Axia.VehicleApi.Application.Services;

public sealed class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IAuthService _authService;

    public UsuarioService(IUsuarioRepository usuarioRepository, IAuthService authService)
    {
        _usuarioRepository = usuarioRepository;
        _authService = authService;
    }

    public async Task<UsuarioDto> CreateAsync(string nome, string login, string senha, string role, CancellationToken cancellationToken)
    {
        if (await _usuarioRepository.ExistsByLoginAsync(login, cancellationToken))
            throw new ConflictException("Login já está em uso.");

        var senhaHash = BCrypt.Net.BCrypt.HashPassword(senha);

        var usuario = new Usuario(
            id: Guid.NewGuid(),
            nome: nome,
            login: login,
            senhaHash: senhaHash,
            role: string.IsNullOrWhiteSpace(role) ? "User" : role
        );

        await _usuarioRepository.AddAsync(usuario, cancellationToken);

        return ToDto(usuario);
    }

    public async Task<UsuarioDto> UpdateAsync(Guid id, string nome, string? senha, string? role, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException("Usuário não encontrado.");

        usuario.AtualizarNome(nome);

        if (!string.IsNullOrWhiteSpace(senha))
        {
            usuario.AtualizarSenhaHash(BCrypt.Net.BCrypt.HashPassword(senha));
        }

        if (!string.IsNullOrWhiteSpace(role))
        {
            usuario.AtualizarRole(role);
        }

        await _usuarioRepository.UpdateAsync(usuario, cancellationToken);

        return ToDto(usuario);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException("Usuário não encontrado.");

        await _usuarioRepository.DeleteAsync(usuario, cancellationToken);
    }

    public async Task<UsuarioDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new NotFoundException("Usuário não encontrado.");

        return ToDto(usuario);
    }

    public async Task<IReadOnlyList<UsuarioDto>> ListAsync(CancellationToken cancellationToken)
    {
        var usuarios = await _usuarioRepository.ListAsync(cancellationToken);
        return usuarios.Select(ToDto).ToList();
    }

    public async Task<AuthResultDto> AuthenticateAsync(string login, string senha, CancellationToken cancellationToken)
    {
        var usuario = await _usuarioRepository.GetByLoginAsync(login, cancellationToken);

        if (usuario is null || !BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaHash))
            throw new UnauthorizedException("Login ou senha inválidos.");

        return _authService.GenerateToken(usuario);
    }

    private static UsuarioDto ToDto(Usuario u) => new(u.Id, u.Nome, u.Login, u.Role);
}
