using Axia.VehicleApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Axia.VehicleApi.Infrastructure.Persistence;

public sealed class AxiaDbContext : DbContext
{
    public AxiaDbContext(DbContextOptions<AxiaDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Veiculo> Veiculos => Set<Veiculo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(x => x.Login)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(x => x.SenhaHash)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(x => x.Role)
                .IsRequired()
                .HasMaxLength(20);

            // Observação: EF InMemory não garante unicidade por índice,
            // então também validamos via FluentValidation/Service.
            entity.HasIndex(x => x.Login).IsUnique();
        });

        modelBuilder.Entity<Veiculo>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(x => x.Modelo)
                .IsRequired()
                .HasMaxLength(30);

            entity.Property(x => x.Opcionais)
                .HasMaxLength(500);

            entity.Property(x => x.Valor)
                .HasPrecision(18, 2);

            entity.Property(x => x.Marca)
                .IsRequired();
        });
    }
}
