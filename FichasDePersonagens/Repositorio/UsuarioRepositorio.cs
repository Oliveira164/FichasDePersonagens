using System.Data;
using MySql.Data.MySqlClient;
using FichasDePersonagens.Models;

namespace FichasDePersonagens.Repositorio
{
    public class UsuarioRepositorio(IConfiguration configuration)
    {
        private readonly string _conexaoMySQL = configuration.GetConnectionString("ConexaoMySQL");

        public void AdicionarUsuario(Usuario usuario)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                var cmd = conexao.CreateCommand();

                cmd.CommandText = "INSERT INTO usuarios (Nome, Email, Senha) VALUES (@nome, @email, @senha)";

                cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = usuario.Nome;
                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = usuario.Email;
                cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = usuario.Senha;

                cmd.ExecuteNonQuery();

                conexao.Close();
            }
        }

        public Usuario ObterUsuario(string email)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new("SELECT * FROM usuarios WHERE email = @email", conexao);

                cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = email;

                using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    Usuario usuario = null;

                    if (dr.Read())
                    {
                        usuario = new Usuario
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            Nome = dr["nome"].ToString(),
                            Email = dr["email"].ToString(),
                            Senha = dr["senha"].ToString()
                        };
                    }
                    return usuario;
                }
            }  
        }
    }
}
