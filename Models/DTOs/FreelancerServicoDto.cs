using GestaoFreela.Models.Enums;

namespace GestaoFreela.Models.DTOs;

public class FreelancerServicoDto
{
    public int Id { get; set; }
    public string FreelancerId { get; set; } = string.Empty;
    public int ServicoId { get; set; }
    public StatusParticipacao Status { get; set; }
    public DateTime DataSolicitacao { get; set; }
    public DateTime? DataResposta { get; set; }
    public string? ObservacoesCliente { get; set; }
    
    // Propriedades adicionais para exibição
    public string? FreelancerNome { get; set; }
    public string? FreelancerEmail { get; set; }
    public string? FreelancerTelefone { get; set; }
    public string? ServicoNome { get; set; }
    public decimal ServicoValor { get; set; }
    public NivelServico ServicoNivel { get; set; }
}
