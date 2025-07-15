using System.ComponentModel.DataAnnotations;
using GestaoFreela.Models.Enums;

namespace GestaoFreela.Models.DTOs;

public class ServicoDto
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(200, ErrorMessage = "O nome deve ter no máximo 200 caracteres")]
    public string Nome { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "A descrição é obrigatória")]
    [StringLength(1000, ErrorMessage = "A descrição deve ter no máximo 1000 caracteres")]
    public string Descricao { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "O valor é obrigatório")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero")]
    public decimal Valor { get; set; }
    
    [Required(ErrorMessage = "O nível é obrigatório")]
    public NivelServico Nivel { get; set; }
    
    [Required(ErrorMessage = "A quantidade de vagas é obrigatória")]
    [Range(1, int.MaxValue, ErrorMessage = "A quantidade de vagas deve ser maior que zero")]
    public int QuantidadeVagas { get; set; }
    
    [Required(ErrorMessage = "A data de início é obrigatória")]
    public DateTime DataInicio { get; set; }
    
    public StatusServico Status { get; set; }
    
    [Required(ErrorMessage = "A categoria é obrigatória")]
    public int CategoriaId { get; set; }
    
    public string ClienteId { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; }
    
    // Propriedades adicionais para exibição
    public string? CategoriaNome { get; set; }
    public string? ClienteNome { get; set; }
    public int FreelancersAceitos { get; set; }
    public int TotalSolicitacoes { get; set; }
}
