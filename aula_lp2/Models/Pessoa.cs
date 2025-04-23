using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aula_lp2.Models;

[Table("pessoa")]
public class Pessoa
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("nome")]
    public string? Nome { get; set; }
    
    [Column("cpf")]
    public string? Cpf { get; set; }
    
    [Column("data_nascimento")]
    public DateTime? DataNasc { get; set; }
    
    [Column("telefone")]
    public string? Telefone { get; set; }
    
    // Lista de propriedades (relação 1:N)
    public List<Propriedade> Propriedades { get; set; }
}