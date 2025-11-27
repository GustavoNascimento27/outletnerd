using outletnerd.Models;
namespace outletnerd.Rep.Interfaces
{
    public interface InCliente
    {
        void CadastrarCliente(Cliente cliente);
        public IEnumerable<Cliente> ObterCliente();
        public Cliente Login(string Email, string Senha);
        public Cliente ObterCliente(int Id);
        public Cliente BuscaEmailCliente(string email);

    }
}
