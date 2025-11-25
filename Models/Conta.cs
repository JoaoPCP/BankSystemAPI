using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text;
using MyFirstAPI.Models.Enum;

namespace MyFirstAPI.Models
{
    public class Conta
    {
        public Guid Id { get; set; }
        public string Numero { get; set; } = string.Empty;
        public Cliente Titular { get; set; } = null!;
        public Guid TitularID { get; set; } 
        public DateTime CreatedAt { get; } 
        public DateTime? UpdatedAt { get; set;}
        private decimal _saldo;
        public decimal Saldo { get { return _saldo; } set { _saldo = value; } }
        public Tipo Tipo { get; set; }

        public Status Status { get; set; } = Status.Ativa;

        public Conta() { }

        public Conta(string numero, Cliente titular, decimal saldo, Tipo tipo)
        {
            Numero = numero;
            TitularID = titular.Id;
            Titular = titular;
            _saldo = saldo;
            Tipo = tipo;
            CreatedAt = DateTime.Now;
        }
        
        public void Depositar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new Exception("O valor do depósito deve ser maior que zero");
            }
            _saldo += valor;
        }

        public void Sacar(decimal valor)
        {
            if (valor <= 0)
            {
                throw new Exception("O valor do saque deve ser maior que zero");
            }
            if (valor > _saldo)
            {
                throw new Exception("Saldo insuficiente para o saque");
            }
            _saldo -= valor;
        }
    }
}

