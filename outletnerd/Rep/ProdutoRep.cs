using Dapper;
using MySql.Data.MySqlClient;
using outletnerd.Models;
using outletnerd.Rep.Interfaces;
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
    }
}
