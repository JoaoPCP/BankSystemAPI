using MyFirstAPI.DTO.ContaDTO;
namespace MyFirstAPI.DTO.ClienteDTO
{
    public class ClienteViewDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }

        public List<ContaByClienteViewDTO> contas { get; set; }

        public ClienteViewDTO(string name, string email, string cpf, List<ContaByClienteViewDTO> contas)
        {
            Name = name;
            Email = email;
            CPF = cpf;
            this.contas = contas;
        }
    }
}
