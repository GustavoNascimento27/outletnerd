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
        public async Task<IEnumerable<Compra>> ItemCompra()
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = "CALL GetProdutosCompra();";
            return await connection.QueryAsync<Compra>(sql);
        }
    }
}
