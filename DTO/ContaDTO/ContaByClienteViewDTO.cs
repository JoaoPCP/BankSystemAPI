using MyFirstAPI.Models.Enum;

namespace MyFirstAPI.DTO.ContaDTO
{
    public class ContaByClienteViewDTO
    {
        public string Numero { get; }
        public decimal Saldo { get; }

        public Tipo Tipo { get; }
        public Status Status { get; }

        public ContaByClienteViewDTO(string numero, decimal saldo, Tipo tipo, Status status)
        {
            Numero = numero;
            Saldo = saldo;
            Tipo = tipo;
            Status = status;
        }
    }
}
