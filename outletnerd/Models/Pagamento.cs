using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace outletnerd.Models
{
    public class Pagamento
    {
        public int IdPagamento { get; set; }
        public string Nome { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco {  get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataPagamento = DateTime.Now;
    }
}
