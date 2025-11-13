using MyFirstAPI.DTO.ClienteDTO;
using MyFirstAPI.Models;

namespace MyFirstAPI.Service
{
    public interface IClienteService
    {
        public Task<ClienteViewDTO> CreateClienteAsync(ClienteInputDTO cliente);
        public Task<ClienteViewDTO?> GetClienteByIdAsync(Guid id);
    }
}
