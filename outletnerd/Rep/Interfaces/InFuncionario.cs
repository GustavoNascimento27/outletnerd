using outletnerd.Models;
namespace outletnerd.Rep.Interfaces
{
    public interface InFuncionario
    {
        void CadastrarFuncionario(Funcionario funcionario);
        public void CadastrarProduto(Produto produto);
        public void Excluir(int Id);
        public void Atualizar(Produto produto);
    }
}
