using GestaoFreela.Models;
using GestaoFreela.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace GestaoFreela.Extensions;

public static class QueryExtensions
{
    public static IQueryable<Servico> PorStatus(this IQueryable<Servico> query, StatusServico status)
    {
        return query.Where(s => s.Status == status);
    }
    
    public static IQueryable<Servico> PorCategoria(this IQueryable<Servico> query, int categoriaId)
    {
        return query.Where(s => s.CategoriaId == categoriaId);
    }
    
    public static IQueryable<Servico> PorCliente(this IQueryable<Servico> query, string clienteId)
    {
        return query.Where(s => s.ClienteId == clienteId);
    }
    
    public static IQueryable<Servico> PorNivel(this IQueryable<Servico> query, NivelServico nivel)
    {
        return query.Where(s => s.Nivel == nivel);
    }
    
    public static IQueryable<Servico> ComVagasDisponiveis(this IQueryable<Servico> query)
    {
        return query.Where(s => s.FreelancerServicos.Count(fs => fs.Status == StatusParticipacao.Aceito) < s.QuantidadeVagas);
    }
    
    public static IQueryable<Servico> IncluirRelacionamentos(this IQueryable<Servico> query)
    {
        return query
            .Include(s => s.Categoria)
            .Include(s => s.Cliente)
            .Include(s => s.FreelancerServicos)
                .ThenInclude(fs => fs.Freelancer);
    }
    
    public static IQueryable<FreelancerServico> PorFreelancer(this IQueryable<FreelancerServico> query, string freelancerId)
    {
        return query.Where(fs => fs.FreelancerId == freelancerId);
    }
    
    public static IQueryable<FreelancerServico> PorServico(this IQueryable<FreelancerServico> query, int servicoId)
    {
        return query.Where(fs => fs.ServicoId == servicoId);
    }
    
    public static IQueryable<FreelancerServico> PorStatusParticipacao(this IQueryable<FreelancerServico> query, StatusParticipacao status)
    {
        return query.Where(fs => fs.Status == status);
    }
}
