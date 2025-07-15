using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GestaoFreela.Data;
using GestaoFreela.Models.Enums;

namespace GestaoFreela.Models;

public class Servico
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(200)]
    public string Nome { get; set; } = string.Empty;
    
    [Required]
    [StringLength(1000)]
    public string Descricao { get; set; } = string.Empty;
    
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Valor { get; set; }
    
    [Required]
    public NivelServico Nivel { get; set; }
    
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "A quantidade de vagas deve ser maior que zero")]
    public int QuantidadeVagas { get; set; }
    
    [Required]
    public DateTime DataInicio { get; set; }
    
    [Required]
    public StatusServico Status { get; set; } = StatusServico.Ativo;
    
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    
    public DateTime? DataFinalizacao { get; set; }
    
    // Foreign Keys
    [Required]
    public int CategoriaId { get; set; }
    
    [Required]
    public string ClienteId { get; set; } = string.Empty;
    
    // Navigation properties
    public virtual Categoria Categoria { get; set; } = null!;
    public virtual ApplicationUser Cliente { get; set; } = null!;
    public virtual ICollection<FreelancerServico> FreelancerServicos { get; set; } = new List<FreelancerServico>();
}
