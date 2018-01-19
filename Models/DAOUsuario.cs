using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace webforum.Models
{
    public class DAOUsuario
    {
        SqlConnection con = null;
        //variável para comando do BD
        SqlCommand cmd = null;
        //variavel para ler os dados do BD
        SqlDataReader rd = null;

        //string para a conexão com BD
        string connectionString = @"Data Source=.\SqlExpress;Initial Catalog=BancoForum;user id=sa;password=senai@123";

        public List<Usuario> Listar()
        {
            //lista para exibir os dados do SELECT do BD
            List<Usuario> listUsuarios = new List<Usuario>();
            try
            {
                con = new SqlConnection(connectionString);
                //abrir o BD
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                //definindo o tipo de comando q será enviado
                cmd.CommandText = "Select * from usuario";
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    listUsuarios.Add(new Usuario()
                    {
                        Id = rd.GetInt32(0),
                        Nome = rd.GetString(1),
                        Login = rd.GetString(2),
                        Senha = rd.GetString(3),
                        DataCadastro = rd.GetDateTime(4)
                    });
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao tentar apagar os dados na tabela. " + ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao tentar apagar os dados na tabela. " + e.Message);
            }
            finally
            {
                con.Close();
            }
            return listUsuarios;
        }

        public bool Cadastrar(Usuario usuario)
        {
            bool resultado = false;
            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into usuario (nome, login, senha) values (@n, @l, @s)";
                cmd.Parameters.AddWithValue("@n", usuario.Nome);
                cmd.Parameters.AddWithValue("@l", usuario.Login);
                cmd.Parameters.AddWithValue("@s", usuario.Senha);

                //executenonquery = para insert, update e delete. O reader é sé para ler.
                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                    resultado = true;
                //lembrar de limpar todos os parametros
                cmd.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar apagar os dados na tabela. " + se.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao tentar apagar os dados na tabela. " + e.Message);
            }
            finally
            {
                con.Close();
            }
            return resultado;

        }

         public string Excluir(int id)
        {
            string msg = "";

            try
            {
                con = new SqlConnection(connectionString);
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from usuario where Id=@i";
                cmd.Parameters.AddWithValue("@i", id);
                int r = cmd.ExecuteNonQuery();

                if (r > 0)
                    msg = "Registro apagado.";
                else
                    msg = "Não foi possível apagar";

                cmd.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar apagar os dados na tabela. " + se.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao tentar apagar os dados na tabela. " + e.Message);
            }
            finally
            {
                con.Close();
            }
            return msg;
        }

        public string Editar(Usuario usuario)
        {
            string msg = "";
            try
            {
                con = new SqlConnection(connectionString);
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update usuario set Nome = @n, Login = @l , Senha = @s where Id = @i";
                cmd.Parameters.AddWithValue("@n", usuario.Nome);
                cmd.Parameters.AddWithValue("@e", usuario.Login);
                cmd.Parameters.AddWithValue("@h", usuario.Senha);
                con.Open();

                int r = cmd.ExecuteNonQuery();

                if (r > 0)
                    msg = "Atualização Efetuada";
                else
                    msg = "Não foi possível atualizar";
                cmd.Parameters.Clear();

            }
            catch (SqlException se)
            {
                throw new Exception("Erro ao tentar atualizar dados " + se.Message);
            }
            catch (System.Exception e)
            {
                throw new Exception("Erro ao tentar atualizar dados " + e.Message);
            }
            finally
            {
                con.Close();
            }

            return msg;
        }
         public bool Logar(string DadoLogin, string DadoSenha)
        {
            //lista para exibir os dados do SELECT do BD
            List<Usuario> listUsuarios = new List<Usuario>();
            try
            {
                con = new SqlConnection(connectionString);
                //abrir o BD
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                //definindo o tipo de comando q será enviado
                cmd.CommandText = "Select * from usuario where login=@l and senha=@s";
                cmd.Parameters.AddWithValue("@l", DadoLogin);
                cmd.Parameters.AddWithValue("@s", DadoSenha);
                rd = cmd.ExecuteReader();
                
                //if(rd>0){

               // }
                
                
                
                while (rd.Read())
                {
                    listUsuarios.Add(new Usuario()
                    {
                        Login = rd.GetString(2),
                        Senha = rd.GetString(3),
                        y
                    });
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Erro ao tentar apagar os dados na tabela. " + ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao tentar apagar os dados na tabela. " + e.Message);
            }
            finally
            {
                con.Close();
            }
            return listUsuarios;
        }



    }
}