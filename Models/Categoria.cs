using System.ComponentModel.DataAnnotations;

namespace GestaoFreela.Models;

public class Categoria
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Nome { get; set; } = string.Empty;
    
    [Required]
    [StringLength(500)]
    public string Descricao { get; set; } = string.Empty;
    
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    
    // Navigation properties
    public virtual ICollection<Servico> Servicos { get; set; } = new List<Servico>();
}
