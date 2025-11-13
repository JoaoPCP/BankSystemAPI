using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Models;

namespace MyFirstAPI.Repository
{
    public interface IContaRepository
    {
        public Task<List<Conta>> GetAllAsync();
        public Task<Conta?> GetByIdAsync(Guid id);
        public Task<Conta> CreateAsync(Conta conta);
        public Task<Conta?> UpdateAsync(Conta conta);
        public Task<bool> DeleteAsync(Guid id);
        public Task<List<Conta>> GetContaByTitularID(Guid clienteId);
    }
}
