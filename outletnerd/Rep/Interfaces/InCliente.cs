using outletnerd.Models;
namespace outletnerd.Rep.Interfaces
{
    public interface InCliente
    {
        void CadastrarCliente(Cliente cliente);
        public IEnumerable<Cliente> ObterCliente();

    }
}
