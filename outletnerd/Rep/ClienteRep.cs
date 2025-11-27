
using MySql.Data.MySqlClient;
using outletnerd.Models;
using outletnerd.Rep.Interfaces;
using System.Data;
using X.PagedList;
using X.PagedList.Mvc;
using X.PagedList.Extensions;
using static Org.BouncyCastle.Math.EC.ECCurve;
using static outletnerd.Models.Constantes.Cliente;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace outletnerd.Rep
{
    public class ClienteRep : InCliente
    {
        private readonly string _connectionString;
        IConfiguration _config;

        public ClienteRep(IConfiguration conf)
        {
            _connectionString = conf.GetConnectionString("DefaultConnection");
            _config = conf;

        }
        public void CadastrarCliente(Cliente cliente)
        {
            using (var conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();
                MySqlCommand comand = new MySqlCommand("insert into Cliente (Email, Nome, Senha, Telefone) values (@Email, @Nome, @Senha, @Telefone);", conexao);

                comand.Parameters.Add("@Email", MySqlDbType.VarChar).Value = cliente.Email;
                comand.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cliente.Nome;
                comand.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = cliente.Senha;
                comand.Parameters.Add("@Telefone", MySqlDbType.Int32).Value = cliente.Telefone;

                comand.ExecuteNonQuery();
                conexao.Close();
            }
        }
        public IEnumerable<Cliente> ObterTodosClientes()
        {
            List<Cliente> cliList = new List<Cliente>();
            using (var conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM CLIENTE;", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                conexao.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    cliList.Add(
                        new Cliente
                        {
                            IdCliente = Convert.ToInt32(dr["Id"]),
                            Nome = (string)(dr["Nome"]),
                            Telefone = Convert.ToInt32(dr["Telefone"]),
                            Email = Convert.ToString(dr["Email"]),
                            Senha = Convert.ToString(dr["Senha"]),
                         
                        });
                }
                return cliList;
            }
        }
        public void Atualizar(Cliente cliente)
        {
            try
            {
                string Situacao = SituacaoConstantes.Ativo;
                using (var conexao = new MySqlConnection(_connectionString))
                {
                    conexao.Open();
                    MySqlCommand cmd = new MySqlCommand("update Cliente set Nome=@Nome, Nascimento=@Nascimento, Sexo=@Sexo,  CPF=@CPF, Telefone=@Telefone, Email=@Email, Senha=@Senha, Situacao=@Situacao WHERE Id=@Id;", conexao);

                    cmd.Parameters.Add("@Id", MySqlDbType.VarChar).Value = cliente.IdCliente;
                    cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = cliente.Nome;
                    cmd.Parameters.Add("@Telefone", MySqlDbType.VarChar).Value = cliente.Telefone;
                    cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = cliente.Email;
                    cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = cliente.Senha;
                    cmd.Parameters.Add("@Situacao", MySqlDbType.VarChar).Value = Situacao;
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
        public void Ativar(int Id)
        {
            string Situacao = SituacaoConstantes.Ativo;
            using (var conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("update Cliente set Situacao=@Situacao WHERE Id=@Id;", conexao);

                cmd.Parameters.Add("@Id", MySqlDbType.VarChar).Value = Id;
                cmd.Parameters.Add("@Situacao", MySqlDbType.VarChar).Value = Situacao;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Desativar(int Id)
        {
            string Situacao = SituacaoConstantes.Inativo;
            using (var conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("update Cliente set Situacao=@Situacao WHERE Id=@Id; ", conexao);

                cmd.Parameters.Add("@Id", MySqlDbType.VarChar).Value = Id;
                cmd.Parameters.Add("@Situacao", MySqlDbType.VarChar).Value = Situacao;
                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }
        public void Excluir(int Id)
        {
            using (var conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from Cliente WHERE Id=@Id;", conexao);
                cmd.Parameters.AddWithValue("@Id", Id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public Cliente ObterCliente(int Id)
        {
            using (var conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Cliente WHERE IdCliente=@Id;", conexao);
                cmd.Parameters.AddWithValue("@Id", Id);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Cliente cliente = new Cliente();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    cliente.IdCliente = (Int32)(dr["Id"]);
                    cliente.Nome = (string)(dr["Nome"]);
                    cliente.Telefone = (Int32)(dr["Telefone"]);
                    cliente.Email = (string)(dr["Email"]);
                    cliente.Senha = (string)(dr["Senha"]);

                }
                return cliente;
            }
        }
        /*public Cliente BuscaCpfCliente(string CPF)
        {
            using (var conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select CPF from Cliente WHERE CPF=@CPF ", conexao);
                cmd.Parameters.AddWithValue("@CPF", CPF);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Cliente cliente = new Cliente();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    cliente.CPF = (string)(dr["CPF"]);

                }
                return cliente;
            }
        }*/
        public Cliente BuscaEmailCliente(string email)
        {
            using (var conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select Email from Cliente WHERE Email=@Email ", conexao);
                cmd.Parameters.AddWithValue("@Email", email);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Cliente cliente = new Cliente();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    cliente.Email = (string)(dr["Email"]);

                }
                return cliente;
            }
        }
        public IPagedList<Cliente> ObterTodosClientes(int? pagina, string pesquisa)
        {
            int RegistroPorPagina = _config.GetValue<int>("RegistroPorPagina");

            int NumeroPagina = pagina ?? 1;

            var clientePesquisadoEmail = BuscaEmailCliente(pesquisa);

            //if (!string.IsNullOrEmpty(pesquisa))
            //{
            //    clientePesquisadoEmail = clientePesquisadoEmail.Where(a => a.Email == pesquisa);
            //}           

            List<Cliente> cliList = new List<Cliente>();
            using (var conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM CLIENTE", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                conexao.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    cliList.Add(
                        new Cliente
                        {
                            IdCliente = Convert.ToInt32(dr["Id"]),
                            Nome = (string)(dr["Nome"]),
                            Telefone = Convert.ToInt32(dr["Telefone"]),
                            Email = Convert.ToString(dr["Email"]),
                            Senha = Convert.ToString(dr["Senha"]),
                        });
                }
                ;
                return cliList.ToPagedList<Cliente>(NumeroPagina, RegistroPorPagina);
            }
        }


        public Cliente Login(string Email, string Senha, string Nome)
        {
            using (var conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT IdCliente, Nome, Email, Senha FROM Cliente WHERE @Nome=@Nome and Email=@Email AND Senha=@Senha", conexao);
                cmd.Parameters.AddWithValue("@Nome", Nome);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Senha", Senha);

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {

                        Cliente cliente = new Cliente
                        {
                            Nome = (string)dr["Nome"],
                            Senha = (string)dr["Senha"],
                            IdCliente = (int)dr["IdCliente"],
                            Email = (string)dr["Email"]
                        };
                        return cliente;

                    }
                    //MySqlDataAdapter da = new MySqlDataAdapter(cmd);



                }
            }
            return null;
        }

        public Cliente BuscaCPFCliente(string CPF)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> ObterCliente()
        {
            throw new NotImplementedException();
        }

        public Cliente Login(string Email, string Senha)
        {
            throw new NotImplementedException();
        }
    }


    }


