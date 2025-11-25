using MyFirstAPI.DTO.ContaDTO;
using MyFirstAPI.Models;
using MyFirstAPI.Repository;

namespace MyFirstAPI.UseCase.Contas.GetAllContas
{
    public class GetAllContasHandler(IContaRepository repo)
    {
        public async Task<List<ContaViewDTO>> Execute()
        {
            List<Conta> contas = await repo.GetAllAsync();
            List<ContaViewDTO> contasResponse = contas
               .Select(c => new ContaViewDTO(c.Numero, c.Saldo, c.Titular.Name))
               .ToList();
            return contasResponse;
        }
    }
}
