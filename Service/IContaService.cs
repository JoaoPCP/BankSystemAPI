using MyFirstAPI.DTO.ContaDTO;

namespace MyFirstAPI.Service
{
    public interface IContaService
    {
        public Task<List<ContaViewDTO>> GetContasAsync();
        public Task<ContaViewDTO?> GetContaByIdAsync(Guid id);
        public Task<ContaViewDTO> CreateContaAsync(ContaInputDTO contaCreateDTO);
        public Task<ContaViewDTO> DepositarAsync(Guid id, decimal valor);
        public Task<ContaViewDTO> SacarAsync(Guid id, decimal valor);
        public Task<bool> DeleteContaAsync(Guid id);
    }
}
