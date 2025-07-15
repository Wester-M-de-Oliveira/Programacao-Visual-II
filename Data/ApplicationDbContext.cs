using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GestaoFreela.Models;

namespace GestaoFreela.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Servico> Servicos { get; set; }
    public DbSet<FreelancerServico> FreelancerServicos { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Configurações específicas para MySQL - usar tamanhos menores para chaves
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (property.ClrType == typeof(string))
                {
                    if (property.Name.Contains("Id") && 
                        (property.IsPrimaryKey() || property.IsForeignKey()))
                    {
                        property.SetColumnType("varchar(255)");
                        property.SetMaxLength(255);
                    }
                    else if (property.GetMaxLength() == null)
                    {
                        property.SetMaxLength(255);
                        property.SetColumnType("varchar(255)");
                    }
                }
            }
        }
        
        // Configuração específica para Identity com tamanhos reduzidos
        builder.Entity<IdentityRole>()
            .Property(r => r.Id)
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);
            
        builder.Entity<ApplicationUser>()
            .Property(u => u.Id)
            .HasColumnType("varchar(255)")
            .HasMaxLength(255);
        
        // Configuração da relação entre Servico e Categoria
        builder.Entity<Servico>()
            .HasOne(s => s.Categoria)
            .WithMany(c => c.Servicos)
            .HasForeignKey(s => s.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Configuração da relação entre Servico e Cliente (ApplicationUser)
        builder.Entity<Servico>()
            .HasOne(s => s.Cliente)
            .WithMany()
            .HasForeignKey(s => s.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Configuração da relação entre FreelancerServico e Freelancer (ApplicationUser)
        builder.Entity<FreelancerServico>()
            .HasOne(fs => fs.Freelancer)
            .WithMany()
            .HasForeignKey(fs => fs.FreelancerId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Configuração da relação entre FreelancerServico e Servico
        builder.Entity<FreelancerServico>()
            .HasOne(fs => fs.Servico)
            .WithMany(s => s.FreelancerServicos)
            .HasForeignKey(fs => fs.ServicoId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // Índice único para evitar duplicação de solicitação do mesmo freelancer para o mesmo serviço
        builder.Entity<FreelancerServico>()
            .HasIndex(fs => new { fs.FreelancerId, fs.ServicoId })
            .IsUnique();
        
        // Configuração de precisão decimal para o valor do serviço
        builder.Entity<Servico>()
            .Property(s => s.Valor)
            .HasPrecision(10, 2);
    }
}