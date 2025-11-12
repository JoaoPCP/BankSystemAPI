namespace MyFirstAPI.DTO.ContaDTO
{
    public class ContaInputDTO
    {
        public decimal Saldo { get; }
        public Guid TitularID { get; }
        public string Tipo { get; }

        public ContaInputDTO( Guid titularId, string tipo, decimal saldo = 0.00m)
        {
            TitularID = titularId;
            Saldo = saldo;
            Tipo = tipo;
        }
    }
}
