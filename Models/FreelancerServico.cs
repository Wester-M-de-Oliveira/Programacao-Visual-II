using System.ComponentModel.DataAnnotations;
using GestaoFreela.Data;
using GestaoFreela.Models.Enums;

namespace GestaoFreela.Models;

public class FreelancerServico
{
    public int Id { get; set; }
    
    [Required]
    public string FreelancerId { get; set; } = string.Empty;
    
    [Required]
    public int ServicoId { get; set; }
    
    [Required]
    public StatusParticipacao Status { get; set; } = StatusParticipacao.EmEspera;
    
    public DateTime DataSolicitacao { get; set; } = DateTime.UtcNow;
    
    public DateTime? DataResposta { get; set; }
    
    [StringLength(500)]
    public string? ObservacoesCliente { get; set; }
    
    // Navigation properties
    public virtual ApplicationUser Freelancer { get; set; } = null!;
    public virtual Servico Servico { get; set; } = null!;
}
