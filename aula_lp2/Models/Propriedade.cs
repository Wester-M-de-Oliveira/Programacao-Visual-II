using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aula_lp2.Models;

[Table("propriedade")]
public class Propriedade
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("descricao")]
    public string? Descricao { get; set; }
    
    [Column("valor")]
    public double? Valor { get; set; }
    
    [Column("id_pessoa")]
    public int? IdPessoa { get; set; }
    
    [ForeignKey("IdPessoa")]
    public virtual Pessoa? Pessoa { get; set; }
}