namespace outletnerd.Models
{
    public class Fornecedor
    {
       public int IdFornecedor { get; set; }
       public string Nome { get; set; }
       public Produto Produto { get; set; }
       
    }
}
