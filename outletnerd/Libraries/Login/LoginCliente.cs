using outletnerd.Libraries.Sessao;
using outletnerd.Models;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace outletnerd.Libraries.Login
{
    public class LoginCliente
    {
        private string Key = "Login.Cliente";
        private Sessao.Sessao _sessao;
        public LoginCliente(Sessao.Sessao sessao)
        {
            _sessao = sessao;
        }
        public void Login(Cliente cliente)
        {
            string clienteJSONstring = JsonConvert.SerializeObject(cliente);
            _sessao.Cadastrar(Key, clienteJSONstring);
        }
        public Cliente GetCliente()
        {
            if (_sessao.Existe(Key))
            {
                string clienteJSONstring = _sessao.Consultar(Key);
                return JsonConvert.DeserializeObject<Cliente>(clienteJSONstring);
            }
            else
            {
                return null;
            }
        }
    }
}