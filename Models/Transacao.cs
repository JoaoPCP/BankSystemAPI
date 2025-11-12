using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFirstAPI.Models
{
    public class Transacao
    {
        public Guid id { get; } = Guid.NewGuid();
        public int ContaId { get; }
        public DateTime Data { get; }
        public decimal Valor { get;  }
        public string Tipo { get; set; }
        public Transacao(DateTime data, decimal valor, string tipo, int contaId)
        {
            Data = data;
            Valor = valor;
            Tipo = tipo;
            ContaId = contaId;
        }

        public static Transacao NovaTransacao()
        {
            Console.WriteLine("Digite o ID da conta:");
            int contaId = int.Parse(Console.ReadLine());
            DateTime data = DateTime.Now;
            Console.WriteLine("Qual foi o tipo de transacao realizada?");
            Console.WriteLine("1 - Débito");
            Console.WriteLine("2 - Crédito");
            string tipoInput = Console.ReadLine();
            string tipo = tipoInput == "1" ? "Débito" : "Crédito";
            Console.WriteLine("Digite o valor da transação:");
            decimal valor = decimal.Parse(Console.ReadLine());
            if (tipo == "Débito")
            {
                valor = -Math.Abs(valor);
            }
            else
            {
                valor = Math.Abs(valor);
            }
            return new Transacao(data, valor, tipo, contaId);
        }
    }
}
