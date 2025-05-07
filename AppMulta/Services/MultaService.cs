using AppMulta.Models;
using AppMulta.Context;
using Microsoft.EntityFrameworkCore;

namespace AppMulta.Services;

public class MultaService
{
    private readonly ContextBD _context;
    
    public MultaService(ContextBD con)
    {
        _context = con;
    }

    public async Task Add(List<Multa> multas)
    {
        if(multas != null)
        {
            await _context.Multas.AddRangeAsync(multas);
        }
    }
    
    public async Task Salvar()
    {
        await _context.SaveChangesAsync();
    }
    
    public async Task<List<Multa>> Multas()
    {
        return await _context.Multas.Include(m => m.Veiculo).ToListAsync();
    }

    public async Task<List<Multa>> GetMultasByVeiculo(int idVeiculo)
    {
        return await _context.Multas
            .Where(m => m.IdVeiculo == idVeiculo)
            .Include(m => m.Veiculo)
            .ToListAsync();
    }

    public async Task<List<Multa>> FiltrarMultas(int? idVeiculo, decimal? valorMinimo, string? descricao)
    {
        var query = _context.Multas.Include(m => m.Veiculo).AsQueryable();

        if (idVeiculo.HasValue)
            query = query.Where(m => m.IdVeiculo == idVeiculo);

        if (valorMinimo.HasValue)
            query = query.Where(m => m.ValorMulta.HasValue && m.ValorMulta >= valorMinimo);

        if (!string.IsNullOrWhiteSpace(descricao))
            query = query.Where(m => m.Descricao != null && m.Descricao.ToLower().Contains(descricao.ToLower()));

        return await query.ToListAsync();
    }

    public async Task<List<Multa>> GetMaioresMultasPorVeiculo()
    {
        var multas = await _context.Multas
            .Include(m => m.Veiculo)
            .ToListAsync();

        return multas
            .GroupBy(m => m.IdVeiculo)
            .Select(g => g.OrderByDescending(m => m.ValorMulta).First())
            .ToList();
    }
}
