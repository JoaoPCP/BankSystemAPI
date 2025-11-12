using MyFirstAPI.Models;

namespace MyFirstAPI.DTO.ContaDTO
{
    public class ContaViewDTO
    { 
        public string TitularName { get; }
        public string Numero { get;}
        public decimal Saldo { get;}
        

        public ContaViewDTO(string numero, decimal saldo, string titular)
        {
            Numero = numero;
            Saldo = saldo;
            TitularName = titular;
        }
    }
}
