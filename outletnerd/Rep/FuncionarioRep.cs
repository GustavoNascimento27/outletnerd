using Dapper;
using MySql.Data.MySqlClient;
using outletnerd.Models;
using outletnerd.Rep.Interfaces;
namespace outletnerd.Rep
{
    public class FuncionarioRep : InFuncionario
    {
        private readonly string _connectionString;

        public FuncionarioRep(IConfiguration conf)
        {
            _connectionString = conf.GetConnectionString("DefaultConection");

        }
        public void CadastrarFuncionario(Funcionario funcionario)
        {
            using (var conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();
                MySqlCommand comd = new MySqlCommand("insert into Funcionario(Nome,Email,Senha) values (@Nome,@Email,@Senha);", conexao);
                comd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = funcionario.Nome;
                comd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = funcionario.Email;
                comd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = funcionario.Senha;
                comd.ExecuteNonQuery();
                conexao.Close();
            }
        }
    }
}
