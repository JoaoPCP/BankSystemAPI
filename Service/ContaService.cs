using MyFirstAPI.DTO.ContaDTO;
using MyFirstAPI.Models;
using MyFirstAPI.Models.Enum;
using MyFirstAPI.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyFirstAPI.Service
{
    public class ContaService(IContaRepository repo, IClienteRepository clienteRepo) : IContaService
    {
        public async Task<List<ContaViewDTO>> GetContasAsync()
        {
            List<Conta> contas = await repo.GetAllAsync();
            List<ContaViewDTO> contasResponse = contas
               .Select(c => new ContaViewDTO(c.Numero, c.Saldo, c.Titular.Name))
               .ToList();
            return contasResponse;
        }

        public async Task<ContaViewDTO?> GetContaByIdAsync(Guid id)
        {
            Conta? conta = await repo.GetByIdAsync(id);
            if (conta == null) return null;
            ContaViewDTO response = new ContaViewDTO(conta.Numero, conta.Saldo, conta.Titular.Name);
            return response;
        }

        public async Task<ContaViewDTO> CreateContaAsync(ContaInputDTO input)
        {
            Random random = new Random();
            string numeroContaNova = random.NextInt64().ToString();
            bool isTipoValid = Enum.TryParse(input.Tipo, ignoreCase: true, out Tipo tipo);
            if (!isTipoValid)
            {
                throw new Exception("O Tipo inserido não é um tipo de conta válido");
            }
            Cliente? cliente = await clienteRepo.GetClienteByIdAsync(input.TitularID);
            if (cliente == null)
            {
                throw new Exception("O Cliente informado não foi encontrado");
            }
            Conta novaConta = new Conta(numeroContaNova, cliente, input.Saldo, tipo);
            var contaCriada = await repo.CreateAsync(novaConta);

            if (contaCriada == null)
            {
                throw new Exception("Houve um erro ao criar a conta");
            }

            ContaViewDTO response = new ContaViewDTO(contaCriada.Numero, contaCriada.Saldo, contaCriada.Titular.Name);

            return response;
        }

        public async Task<ContaViewDTO> DepositarAsync(Guid id, decimal value)
        {
            Conta? contaExistente = await repo.GetByIdAsync(id);
            if (contaExistente == null)
            {
                throw new Exception("Conta não encontrada");
            }
            contaExistente.Depositar(value);
            Conta? dbResponse = await repo.UpdateAsync(contaExistente);
            if (dbResponse == null)
            {
                throw new Exception("Houve um erro ao processar o saque");
            }
            ContaViewDTO response = new ContaViewDTO(contaExistente.Numero, contaExistente.Saldo, contaExistente.Titular.Name);
            return response;

        }

        public async Task<ContaViewDTO> SacarAsync(Guid id, decimal value)
        {
            Conta? contaExistente = await repo.GetByIdAsync(id);
            if (contaExistente == null)
            {
                throw new Exception("Conta não encontrada");
            }
            contaExistente.Sacar(value);
            Conta? dbResponse = await repo.UpdateAsync(contaExistente);
            if (dbResponse == null)
            {
                throw new Exception("Houve um erro ao processar o saque");
            }

            ContaViewDTO response = new ContaViewDTO(contaExistente.Numero, contaExistente.Saldo, contaExistente.Titular.Name);
            return response;
        }

        public async Task<bool> DeleteContaAsync(Guid id)
        {
            Conta? contaExistente = await repo.GetByIdAsync(id);
            if (contaExistente == null)
            {
                throw new Exception("Conta não encontrada");
            }
            bool result = await repo.DeleteAsync(id);
            return result;
        }

    }
}
