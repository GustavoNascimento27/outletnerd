namespace outletnerd.Models
{
    public class Carrinho
    {

        public int IdCarrinho { get; set; }
        public int IdProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public Produto Produto { get; set; }
        public decimal Valor => Quantidade * Preco;
    }
}
