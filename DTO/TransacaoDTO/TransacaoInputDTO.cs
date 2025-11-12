namespace MyFirstAPI.DTO.TransacaoDTO
{
    public class TransacaoInputDTO
    {
        public decimal Valor { get; set; }

        public TransacaoInputDTO(Guid contaId, decimal valor)
        {
            Valor = valor;
        }
    }
}