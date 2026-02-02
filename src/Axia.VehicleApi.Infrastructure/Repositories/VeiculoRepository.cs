using Axia.VehicleApi.Domain.Entities;
using Axia.VehicleApi.Domain.Interfaces;
using Axia.VehicleApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Axia.VehicleApi.Infrastructure.Repositories;

public sealed class VeiculoRepository : IVeiculoRepository
{
    private readonly AxiaDbContext _context;

    public VeiculoRepository(AxiaDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Veiculo veiculo, CancellationToken cancellationToken)
    {
        await _context.Veiculos.AddAsync(veiculo, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Veiculo veiculo, CancellationToken cancellationToken)
    {
        _context.Veiculos.Update(veiculo);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Veiculo veiculo, CancellationToken cancellationToken)
    {
        _context.Veiculos.Remove(veiculo);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public Task<Veiculo?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => _context.Veiculos.AsNoTracking().FirstOrDefaultAsync(v => v.Id == id, cancellationToken);

    public async Task<IReadOnlyList<Veiculo>> ListAsync(CancellationToken cancellationToken)
        => await _context.Veiculos.AsNoTracking().OrderBy(v => v.Marca).ThenBy(v => v.Modelo).ToListAsync(cancellationToken);
}
