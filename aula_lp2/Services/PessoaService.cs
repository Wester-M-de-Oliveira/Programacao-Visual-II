using aula_lp2.Models;
using aula_lp2.Context;
using Microsoft.EntityFrameworkCore;

namespace aula_lp2.Services;

public class PessoaService
{
    private readonly ContextBD _context;
    public PessoaService(ContextBD con)
    {
        _context = con;
    }

    public async Task<List<Pessoa>>? Pessoas()
    {
        return await _context.Pessoas.Include(p=> p.Propriedades).ToListAsync();
    }
    
    public async Task<Pessoa> GetPessoa(int id)
    {
        var pessoa = await _context.Pessoas.Include(p => p.Propriedades).FirstOrDefaultAsync(p => p.Id == id);
        if (pessoa == null)
        {
            throw new Exception("Pessoa não encontrada");
        }
        return pessoa;
    }
    
    public async Task Add(Pessoa pessoa)
    {
        if (pessoa != null)
        {
            await _context.Pessoas.AddAsync(pessoa);
        }
    }

    public async Task Salvar()
    {
        await _context.SaveChangesAsync();
    }
}
