using MyFirstAPI.DTO.ClienteDTO;
using MyFirstAPI.DTO.ContaDTO;
using MyFirstAPI.Models;
using MyFirstAPI.Repository;

namespace MyFirstAPI.Service
{
    public class ClienteService(IClienteRepository ClienteRepo, IContaRepository ContaRepo) : IClienteService
    {
        public async Task<ClienteViewDTO> CreateClienteAsync(ClienteInputDTO input)
        {
            Cliente novoCliente = new Cliente(input.Name, input.Email, input.CPF);
            Cliente dbresponse = await ClienteRepo.CreateClienteAsync(novoCliente);
            ClienteViewDTO response = new ClienteViewDTO(
                dbresponse.Name,
                dbresponse.Email,
                dbresponse.CPF,
                []
            );
            return response;
            
        }

        public async Task<ClienteViewDTO?> GetClienteByIdAsync(Guid id)
        {
            Cliente? cliente = await ClienteRepo.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return null;
            }
            List<Conta> contasDoCliente = await ContaRepo.GetContaByTitularID(cliente.Id);
            ClienteViewDTO response = new ClienteViewDTO(
                cliente.Name,
                cliente.Email,
                cliente.CPF,
                contasDoCliente.Select(conta => new ContaByClienteViewDTO(
                    conta.Numero,
                    conta.Saldo,
                    conta.Tipo,
                    conta.Status
                )).ToList()
            );
            return response;
        }
    }
}
