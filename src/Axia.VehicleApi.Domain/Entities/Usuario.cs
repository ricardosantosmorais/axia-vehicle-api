namespace Axia.VehicleApi.Domain.Entities;

public class Usuario
{
    // EF Core precisa de construtor sem parâmetros
    private Usuario() { }

    public Usuario(Guid id, string nome, string login, string senhaHash, string role = "User")
    {
        Id = id;
        Nome = nome;
        Login = login;
        SenhaHash = senhaHash;
        Role = role;
    }

    public Guid Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string Login { get; private set; } = string.Empty;
    public string SenhaHash { get; private set; } = string.Empty;

    // Extra (opcional no teste): roles/claims no JWT
    public string Role { get; private set; } = "User";

    public void AtualizarNome(string nome) => Nome = nome;

    public void AtualizarSenhaHash(string senhaHash) => SenhaHash = senhaHash;

    public void AtualizarRole(string role) => Role = role;
}
