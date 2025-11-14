using outletnerd.Models;
namespace outletnerd.Rep.Interfaces
{
    public interface InCliente
    {
        void CadastrarCliente(Cliente cliente);
        public IEnumerable<Cliente> ObterCliente();
        ClienteRep Login(string Email, string Senha);
        public Cliente ObterCliente(int Id);

    }
}
