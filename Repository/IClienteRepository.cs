using MyFirstAPI.Models;

namespace MyFirstAPI.Repository
{
    public interface IClienteRepository
    {
        public Task<Cliente> CreateClienteAsync(Cliente cliente);
        public Task<Cliente?> GetClienteByIdAsync(Guid id);
    }
}
