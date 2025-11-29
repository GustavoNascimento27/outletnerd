using Dapper;
using MySql.Data.MySqlClient;
using NuGet.Protocol.Plugins;
using outletnerd.Models;
using outletnerd.Rep.Interfaces;
using static outletnerd.Models.Constantes.ClienteC;
namespace outletnerd.Rep
{
    public class ProdutoRep : InProduto
    {
        private readonly string _connectionString;

        public ProdutoRep(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<IEnumerable<Produto>>TodosProdutos()
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = "Select IdProduto, Nome, Descricao, Preco, ImageUrl, Quantidade, Categoria from Produto";
            return await connection.QueryAsync<Produto>(sql);
        }
        public async Task<Produto?> ProdutoPorId(int idProduto)
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = "SELECT IdProduto, Nome, Descricao, Preco, ImageUrl, Quantidade, Categoria FROM Produto WHERE IdProduto = @idProduto";
            return await connection.QueryFirstOrDefaultAsync<Produto>(sql, new { IdProduto = idProduto });
        }
        public async Task<IEnumerable<Produto>> Brinquedos()
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = "Select IdProduto, Nome, Descricao, Preco, ImageUrl, Quantidade, Categoria from Produto where Categoria = 'Brinquedos'";
            return await connection.QueryAsync<Produto>(sql);
        }
        public async Task<IEnumerable<Produto>> Decoracoes()
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = "Select IdProduto, Nome, Descricao, Preco, ImageUrl, Quantidade, Categoria from Produto where Categoria = 'Decorações'";
            return await connection.QueryAsync<Produto>(sql);
        }
        public async Task<IEnumerable<Produto>> Livros()
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = "Select IdProduto, Nome, Descricao, Preco, ImageUrl, Quantidade, Categoria from Produto where Categoria = 'Livros'";
            return await connection.QueryAsync<Produto>(sql);
        }
        public async Task<IEnumerable<Produto>> Roupas()
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = "Select IdProduto, Nome, Descricao, Preco, ImageUrl, Quantidade, Categoria from Produto where Categoria = 'Roupas'";
            return await connection.QueryAsync<Produto>(sql);
        }
        public async Task Excluir(int id)
        {
            using var conexao = new MySqlConnection(_connectionString);
            var produto = await conexao.QueryFirstOrDefaultAsync<Produto>(
                "SELECT * FROM Produto WHERE IdProduto = @Id",
                new { Id = id }
            );   
            await conexao.ExecuteAsync(
                "DELETE FROM Produto WHERE IdProduto = @Id",
                new { Id = id }
            );

            
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

        /*void InProduto.Excluir(int Id)
        {
            throw new NotImplementedException();
        }*/
    }
}
