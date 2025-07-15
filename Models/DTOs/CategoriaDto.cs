using System.ComponentModel.DataAnnotations;

namespace GestaoFreela.Models.DTOs;

public class CategoriaDto
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
    public string Nome { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "A descrição é obrigatória")]
    [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres")]
    public string Descricao { get; set; } = string.Empty;
    
    public DateTime DataCriacao { get; set; }
    public int QuantidadeServicos { get; set; }
}
