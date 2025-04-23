using aula_lp2.Models;
using Microsoft.EntityFrameworkCore;

namespace aula_lp2.Context;

public class ContextBD : DbContext
{
    public ContextBD()
    {
    }
    
    public ContextBD(DbContextOptions<ContextBD> options) : base(options)
    {
    }

    public DbSet<Pessoa>? Pessoas { get; set; }
    public DbSet<Propriedade>? Propriedades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Propriedade>()
            .HasOne(p => p.Pessoa)
            .WithMany(p => p.Propriedades)
            .HasForeignKey(p => p.IdPessoa);

        base.OnModelCreating(modelBuilder);
    }
}