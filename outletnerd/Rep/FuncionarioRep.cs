using Dapper;
using MySql.Data.MySqlClient;
using outletnerd.Models;
using outletnerd.Rep.Interfaces;
using System.Data;
using System.Text;
namespace outletnerd.Rep
{
    public class FuncionarioRep : InFuncionario
    {
        private readonly string _connectionString;
        
        public FuncionarioRep(IConfiguration conf)
        {
            _connectionString = conf.GetConnectionString("DefaultConnection");

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
        public void CadastrarProduto(Produto produto)
        {
            using (var conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();
                MySqlCommand comd = new MySqlCommand("insert into Produto(Nome,Descricao,Preco,ImageUrl,Quantidade,Categoria) values (@Nome,@Descricao,@Preco,@ImageUrl,@Quantidade,@Categoria);", conexao);
                comd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = produto.Nome;
                comd.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = produto.Descricao;
                comd.Parameters.Add("@Preco", MySqlDbType.Decimal).Value = produto.Preco;
                comd.Parameters.Add("@ImageUrl", MySqlDbType.VarChar).Value = produto.ImageUrl;
                comd.Parameters.Add("@Quantidade", MySqlDbType.Int32).Value = produto.Quantidade;
                comd.Parameters.Add("@Categoria", MySqlDbType.VarChar).Value = produto.Categoria;
                comd.ExecuteNonQuery();
                conexao.Close();
            }
        }
       
        public Funcionario Login(string Email, string Senha)
        {
            using (var conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT IdFuncionario, Email, Senha FROM Funcionario WHERE Email=@Email AND Senha=@Senha", conexao);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Senha", Senha);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        
                            Funcionario funcionario = new Funcionario
                            {
                                Senha = (string)dr["Senha"],
                                IdFuncionario = (int)dr["IdFuncionario"],
                                Email = (string)dr["Email"]
                            };
                            return funcionario;
                        
                    }
                    //MySqlDataAdapter da = new MySqlDataAdapter(cmd);



                }
            }
            return null;
        }

        public async Task<IEnumerable<Funcionario>> ListarTodos()
        {
            using var conexao = new MySqlConnection(_connectionString);
            var sql = "SELECT * FROM Funcionario";
            return await conexao.QueryAsync<Funcionario>(sql);
        }
        public async Task<Funcionario?> ExcluirF(int id)
        {
            using var conexao = new MySqlConnection(_connectionString);
            var funcionario = await conexao.QueryFirstOrDefaultAsync<Funcionario>(
                "SELECT * FROM Funcionario WHERE IdFuncionario = @Id",
                new { Id = id }
            );

            if (funcionario == null)
            {
                return null;
            }

            await conexao.ExecuteAsync(
                "DELETE FROM Funcionario WHERE IdFuncionario = @Id",
                new { Id = id }
            );

            return funcionario;
        }
        /* public async Task<Produto?> Excluir(int id)
         {
             using var conexao = new MySqlConnection(_connectionString);
             var produto = await conexao.QueryFirstOrDefaultAsync<Produto>(
                 "SELECT * FROM Produto WHERE IdProduto = @Id",
                 new { Id = id }
             );

             if (produto == null)
             {
                 return null;
             }

             await conexao.ExecuteAsync(
                 "DELETE FROM Produto WHERE IdProduto = @Id",
                 new { Id = id }
             );

             return produto;
         }
         public void Atualizar(Produto produto)
         {
             try
             {

                 using (var conexao = new MySqlConnection(_connectionString))
                 {
                     conexao.Open();
                     MySqlCommand cmd = new MySqlCommand("update Produto set Nome=@Nome, Descricao=@Descricao, Preco=@Preco,  ImageUrl=@ImageUrl, " +
                         " Quantidade=@Quantidade, Categoria=@Categoria WHERE IdProduto=@Id ", conexao);

                     cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = produto.Nome;
                     cmd.Parameters.Add("@Descricao", MySqlDbType.VarChar).Value = produto.Descricao;
                     cmd.Parameters.Add("@Preco", MySqlDbType.VarChar).Value = produto.Preco;
                     cmd.Parameters.Add("@ImageUrl", MySqlDbType.VarChar).Value = produto.ImageUrl;
                     cmd.Parameters.Add("@Quantidade", MySqlDbType.VarChar).Value = produto.Quantidade;
                     cmd.Parameters.Add("@Categoria", MySqlDbType.VarChar).Value = produto.Categoria;
                     cmd.ExecuteNonQuery();
                     conexao.Close();
                 }

             }
             catch (MySqlException ex)
             {
                 throw new Exception("Erro no banco ao atualizar cliente" + ex.Message);
             }
             catch (Exception ex)
             {
                 throw new Exception("Erro na aplicação ao atualizar cliente" + ex.Message);
             }
         }

         void InFuncionario.Excluir(int Id)
         {
             throw new NotImplementedException();
         }*/
    }
}
