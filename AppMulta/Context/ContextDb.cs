using AppMulta.Models;
using Microsoft.EntityFrameworkCore;

namespace AppMulta.Context;

public class ContextBD : DbContext
{
    public ContextBD()
    {
    }
    
    public ContextBD(DbContextOptions<ContextBD> options) : base(options)
    {
    }

    public DbSet<Veiculo>? Veiculos { get; set; }
    public DbSet<Multa>? Multas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Multa>()
            .HasOne(m => m.Veiculo)
            .WithMany(v => v.Multas)
            .HasForeignKey(m => m.IdVeiculo);

        base.OnModelCreating(modelBuilder);
    }
}