using Dapper;
using MySql.Data.MySqlClient;
using outletnerd.Models;
namespace outletnerd.Rep
{
    public class ProdutoRep
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
    }
}
