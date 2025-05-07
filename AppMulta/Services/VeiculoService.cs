using AppMulta.Models;
using AppMulta.Context;
using Microsoft.EntityFrameworkCore;

namespace AppMulta.Services;

public class VeiculoService
{
    private readonly ContextBD _context;
    public VeiculoService(ContextBD con)
    {
        _context = con;
    }

    public async Task<List<Veiculo>>? Veiculos()
    {
        return await _context.Veiculos.Include(v => v.Multas).ToListAsync();
    }
    
    public async Task<Veiculo> GetVeiculo(int id)
    {
        var veiculo = await _context.Veiculos.Include(v => v.Multas).FirstOrDefaultAsync(v => v.Id == id);
        if (veiculo == null)
        {
            throw new Exception("Veículo não encontrado");
        }
        return veiculo;
    }
    
    public async Task Add(Veiculo veiculo)
    {
        if (veiculo != null)
        {
            await _context.Veiculos.AddAsync(veiculo);
        }
    }

    public async Task Salvar()
    {
        await _context.SaveChangesAsync();
    }
}
