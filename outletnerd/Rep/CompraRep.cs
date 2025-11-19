using Dapper;
using MySql.Data.MySqlClient;
using outletnerd.Models;
using outletnerd.Rep.Interfaces;
namespace outletnerd.Rep
{

    public class CompraRep
    {
        private readonly string _connectionString;

        public CompraRep(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<Produto> ItemCompra(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = "SELECT IdProduto, Nome, Descricao, Preco, ImageUrl, Quantidade, Categoria FROM Produto WHERE IdProduto = @idProduto";
            return await connection.QueryFirstOrDefaultAsync<Produto>(sql, new { IdProduto = id });
        }
    }
}
