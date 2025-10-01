
using MySql.Data.MySqlClient;
using outletnerd.Models;
using outletnerd.Rep.Interfaces;
using System.Data;

namespace outletnerd.Rep
{
    public class ClienteRep : InCliente
    {
        private readonly string _connectionString;

        public ClienteRep(IConfiguration conf)
        {
            _connectionString = conf.GetConnectionString("DefaultConnection");

        }
        public void CadastrarCliente(Cliente cliente)
        {
            using (var conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();
                MySqlCommand comand = new MySqlCommand("insert into Cliente(Email, Nome, Senha, Telefone) values (@Email, @Nome, @Senha, @Telefone)", conexao);

                comand.Parameters.Add("@Email", MySqlDbType.VarChar).Value = cliente.Email;
                comand.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cliente.Name;
                comand.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = cliente.Senha;
                comand.Parameters.Add("@Telefone", MySqlDbType.Int32).Value = cliente.Telefone;

                comand.ExecuteNonQuery();
                conexao.Close();
            }
        }
        public IEnumerable<Cliente> ObterCliente()
        {
            List<Cliente> CList = new List<Cliente>();
            using (var conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();
                MySqlCommand command = new MySqlCommand("select * from Cliente;", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);

                conexao.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    CList.Add(
                        new Cliente
                        {
                            IdCliente = Convert.ToInt32(dr["IdCliente"]),
                            Email = (string)dr["Email"],
                            Name = (string)dr["Nome"],
                            Senha = (string)dr["Senha"],
                            Telefone = (Int32)dr["Telefone"],
                        }
                        );
                }
                return CList;
            }
        }

    }
}

