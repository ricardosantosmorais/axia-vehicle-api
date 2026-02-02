using Axia.VehicleApi.Domain.Entities;
using Axia.VehicleApi.Domain.Interfaces;
using Axia.VehicleApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Axia.VehicleApi.Infrastructure.Repositories;

public sealed class UsuarioRepository : IUsuarioRepository
{
    private readonly AxiaDbContext _context;

    public UsuarioRepository(AxiaDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Usuario usuario, CancellationToken cancellationToken)
    {
        await _context.Usuarios.AddAsync(usuario, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Usuario usuario, CancellationToken cancellationToken)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Usuario usuario, CancellationToken cancellationToken)
    {
        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public Task<Usuario?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

    public Task<Usuario?> GetByLoginAsync(string login, CancellationToken cancellationToken)
        => _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Login == login, cancellationToken);

    public Task<bool> ExistsByLoginAsync(string login, CancellationToken cancellationToken)
        => _context.Usuarios.AsNoTracking().AnyAsync(u => u.Login == login, cancellationToken);

    public async Task<IReadOnlyList<Usuario>> ListAsync(CancellationToken cancellationToken)
        => await _context.Usuarios.AsNoTracking().OrderBy(u => u.Nome).ToListAsync(cancellationToken);
}
