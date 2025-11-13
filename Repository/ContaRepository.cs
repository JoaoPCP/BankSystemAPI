using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Data;
using MyFirstAPI.Models;

namespace MyFirstAPI.Repository
{
    public class ContaRepository : IContaRepository
    {
        private readonly BankContext _context;
        public ContaRepository(BankContext context)
        {
            _context = context;
        }

        public async Task<Conta> CreateAsync(Conta conta)
        {
            var response = await _context.AddAsync(conta);
            await _context.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            int response = await _context.Contas.Where(c => c.Id == id).ExecuteDeleteAsync();
            return response > 0;
        }

        public async Task<List<Conta>> GetAllAsync()
        {
            List<Conta> response = await _context.Contas.ToListAsync();
            return response;
        }

        public async Task<Conta?> GetByIdAsync(Guid id)
        {
            Conta? conta = await _context.Contas.AsNoTracking()
                                                .Include(c => c.Titular)
                                                .FirstAsync(c => c.Id == id);
                                                
            return conta;

        }

        public async Task<Conta?> UpdateAsync(Conta conta)
        {
            var response = await _context.Contas.Where(c => c.Id == conta.Id)
                .ExecuteUpdateAsync(c => c
                    .SetProperty(c => c.Numero, conta.Numero)
                    .SetProperty(c => c.Saldo, conta.Saldo)
                    .SetProperty(c => c.Status, conta.Status)
                    .SetProperty(c => c.Tipo, conta.Tipo)
                    .SetProperty(c => c.UpdatedAt, DateTime.UtcNow)
                );
            return response > 0 ? await GetByIdAsync(conta.Id) : null;
        }

        public async Task<List<Conta>> GetContaByTitularID(Guid clienteId)
        {
            List<Conta> contas = await _context.Contas
                                     .AsNoTracking()
                                     .Where(c => c.TitularID == clienteId)
                                     .ToListAsync();
            return contas;
        }
    }
}
