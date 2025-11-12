using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Data;
using MyFirstAPI.Models;

namespace MyFirstAPI.Repository
{
    public class ClienteRepository(BankContext _context) : IClienteRepository
    {
        public async Task<Cliente> CreateClienteAsync(Cliente cliente)
        {
            var response = await _context.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return response.Entity;
        }
        public async Task<Cliente?> GetClienteByIdAsync(Guid id)
        {
            Cliente? cliente = await _context.Clientes
                                                      .Where(c => c.Id == id)
                                                      .FirstAsync();
            return cliente;
        }
    }
}
