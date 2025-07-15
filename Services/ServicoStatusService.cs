using GestaoFreela.Data;
using GestaoFreela.Models;
using GestaoFreela.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace GestaoFreela.Services;

public interface IServicoStatusService
{
    Task AtualizarStatusServicoAsync(int servicoId);
    Task<bool> PodeAceitarFreelancerAsync(int servicoId);
    Task<int> ContarFreelancersAceitosAsync(int servicoId);
}

public class ServicoStatusService : IServicoStatusService
{
    private readonly ApplicationDbContext _context;
    
    public ServicoStatusService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task AtualizarStatusServicoAsync(int servicoId)
    {
        var servico = await _context.Servicos
            .Include(s => s.FreelancerServicos)
            .FirstOrDefaultAsync(s => s.Id == servicoId);
            
        if (servico == null) return;
        
        var freelancersAceitos = servico.FreelancerServicos
            .Count(fs => fs.Status == StatusParticipacao.Aceito);
            
        // Se o número de freelancers aceitos for menor que as vagas disponíveis
        if (freelancersAceitos < servico.QuantidadeVagas && 
            servico.Status != StatusServico.Cancelado && 
            servico.Status != StatusServico.Finalizado)
        {
            servico.Status = StatusServico.AguardandoCompletarTime;
        }
        // Se o número de freelancers aceitos for igual às vagas disponíveis
        else if (freelancersAceitos == servico.QuantidadeVagas && 
                 servico.Status == StatusServico.AguardandoCompletarTime)
        {
            servico.Status = StatusServico.Ativo;
        }
        
        await _context.SaveChangesAsync();
    }
    
    public async Task<bool> PodeAceitarFreelancerAsync(int servicoId)
    {
        var servico = await _context.Servicos
            .Include(s => s.FreelancerServicos)
            .FirstOrDefaultAsync(s => s.Id == servicoId);
            
        if (servico == null) return false;
        
        var freelancersAceitos = servico.FreelancerServicos
            .Count(fs => fs.Status == StatusParticipacao.Aceito);
            
        return freelancersAceitos < servico.QuantidadeVagas;
    }
    
    public async Task<int> ContarFreelancersAceitosAsync(int servicoId)
    {
        return await _context.FreelancerServicos
            .CountAsync(fs => fs.ServicoId == servicoId && fs.Status == StatusParticipacao.Aceito);
    }
}
