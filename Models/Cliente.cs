namespace MyFirstAPI.Models
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;

        public ICollection<Conta> Contas { get; } = new List<Conta>();

        private Cliente() { }
        public Cliente(string name, string email, string cpf)
        {
            Name = name;
            Email = email;
            CPF = cpf;
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

    }
}
