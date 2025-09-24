namespace outletnerd.Models
{
    public class ItemProduto
    {
     public int IdItem { get; set; }
     public Carrinho Carrinho { get; set; }
     public Produto Produto { get; set; }
     public int Quantidade { get; set; }
     
    }
}
