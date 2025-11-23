using outletnerd.Models;
namespace outletnerd.Rep.Interfaces
{
    public interface InFuncionario
    {
        void CadastrarFuncionario(Funcionario funcionario);
        public void CadastrarProduto(Produto produto);
        public Funcionario Login(string Email, string Senha);
        public Task<IEnumerable<Funcionario>> ListarTodos();
        public Task<Funcionario?> ExcluirF(int id);
    }
}
