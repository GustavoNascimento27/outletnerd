using Microsoft.AspNetCore.Routing.Constraints;

namespace outletnerd.Models
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco {  get; set; }
        public string ImageUrl { get; set; }
        public int Quantidade { get; set; }
        public string Categoria { get; set; }
        //public Fornecedor Fornecedor { get; set; }
    }
}
