using outletnerd.Models;
namespace outletnerd.Rep.Interfaces
{
    public interface InProduto
    {
        public Task<IEnumerable<Produto>> TodosProdutos();
        public Task<Produto?> ProdutoPorId(int idProduto);
        public Task<IEnumerable<Produto>> Brinquedos();
        public Task<IEnumerable<Produto>> Decoracoes();
        public Task<IEnumerable<Produto>> Livros();
        public Task<IEnumerable<Produto>> Roupas();
        public Task Excluir(int id);
        public void Atualizar(Produto produto);

    }
}
