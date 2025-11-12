using MyFirstAPI.Models;
namespace MyFirstAPI.DTO.ClienteDTO
{
    public class ClienteViewDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }

        //public List<Conta> contas { get; set; }

        public ClienteViewDTO(string name, string email, string cpf)
        {
            Name = name;
            Email = email;
            CPF = cpf;
        }
    }
}
