namespace MyFirstAPI.DTO.ClienteDTO
{
    public class ClienteInputDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }

        public ClienteInputDTO(string name, string email, string cpf)
        {
            Name = name;
            Email = email;
            CPF = cpf;
        }
    }
}
