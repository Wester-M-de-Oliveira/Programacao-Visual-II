using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMulta.Models;

[Table("multa")]
public class Multa
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("descricao")]
    public string? Descricao { get; set; }
    
    [Column("valor_multa")]
    public decimal? ValorMulta { get; set; }
    
    [Column("id_veiculo")]
    public int? IdVeiculo { get; set; }
    
    [ForeignKey("IdVeiculo")]
    public virtual Veiculo? Veiculo { get; set; }
}