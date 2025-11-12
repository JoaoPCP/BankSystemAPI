using MyFirstAPI.DTO.ClienteDTO;
using MyFirstAPI.Models;
using MyFirstAPI.Repository;

namespace MyFirstAPI.Service
{
    public class ClienteService(IClienteRepository repo) : IClienteService
    {
        public async Task<ClienteViewDTO> CreateClienteAsync(ClienteInputDTO input)
        {
            Cliente novoCliente = new Cliente(input.Name, input.Email, input.CPF);
            Cliente dbresponse = await repo.CreateClienteAsync(novoCliente);
            ClienteViewDTO response = new ClienteViewDTO(
                dbresponse.Name,
                dbresponse.Email,
                dbresponse.CPF
            );
            return response;
            
        }

        public async Task<ClienteViewDTO?> GetByClienteIdAsync(Guid id)
        {
            var cliente = await repo.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return null;
            }
            ClienteViewDTO response = new ClienteViewDTO(
                cliente.Name,
                cliente.Email,
                cliente.CPF
            );
            return response;
        }
    }
}
