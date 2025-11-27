using outletnerd.Models;
namespace outletnerd.Rep.Interfaces
{
    public interface InCliente
    {
        public void CadastrarCliente(Cliente cliente);
        public IEnumerable<Cliente> ObterCliente();
        public Cliente Login(string Email, string Senha, string Nome);
        public Cliente ObterCliente(int Id);
        public Cliente BuscaEmailCliente(string email);

    }
}
