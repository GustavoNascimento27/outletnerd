﻿using Dapper;
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
                MySqlCommand comd = new MySqlCommand("insert into Produto(Nome,Descricao,Preco,ImageUrl,Quantidade, Categoria)values(@Nome,@Descricao,@Preco,@ImageUrl,@Quantidade,@Categoria);", conexao);
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

    }
}
