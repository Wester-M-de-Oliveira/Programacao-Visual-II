using aula_lp2.Models;
using aula_lp2.Context;
using Microsoft.EntityFrameworkCore;

namespace aula_lp2.Services;

public class PropriedadeService
{
    private readonly ContextBD _context;
    
    public PropriedadeService(ContextBD con)
    {
        _context = con;
    }

    public async Task Add(List<Propriedade> bens)
    {
        if(bens != null)
        {
            await _context.Propriedades.AddRangeAsync(bens);
        }
    }
    
    public async Task Salvar()
    {
        await _context.SaveChangesAsync();
    }
    
    public async Task<List<Propriedade>> Propriedades()
    {
        return await _context.Propriedades.Include(p => p.Pessoa).ToListAsync();
    }

    public async Task<List<Propriedade>> GetPropriedadesByPessoa(int idPessoa)
    {
        return await _context.Propriedades
            .Where(p => p.IdPessoa == idPessoa)
            .Include(p => p.Pessoa)
            .ToListAsync();
    }

    public async Task<List<Propriedade>> FiltrarPropriedades(int? idPessoa, double? valorMinimo, string? descricao)
    {
        var query = _context.Propriedades.Include(p => p.Pessoa).AsQueryable();

        if (idPessoa.HasValue)
            query = query.Where(p => p.IdPessoa == idPessoa);

        if (valorMinimo.HasValue)
            query = query.Where(p => p.Valor.HasValue && p.Valor >= valorMinimo);

        if (!string.IsNullOrWhiteSpace(descricao))
            query = query.Where(p => p.Descricao != null && p.Descricao.ToLower().Contains(descricao.ToLower()));

        return await query.ToListAsync();
    }

    public async Task<List<Propriedade>> GetMaioresPropriedadesPorPessoa()
    {
        var propriedades = await _context.Propriedades
            .Include(p => p.Pessoa)
            .ToListAsync();

        return propriedades
            .GroupBy(p => p.IdPessoa)
            .Select(g => g.OrderByDescending(p => p.Valor).First())
            .ToList();
    }
}

