using System.Data;
using MySql.Data.MySqlClient;
using FichasDePersonagens.Models;

namespace FichasDePersonagens.Repositorio
{
    public class FichaRepositorio(IConfiguration configuration)
    {
        private readonly string _conexaoMySQL = configuration.GetConnectionString("ConexaoMySQL");

        public void AdicionarFicha(Ficha ficha)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                var cmd = conexao.CreateCommand();

                cmd.CommandText = "INSERT INTO fichas (Nome, Idade, Origem, Classe, Forca, Agilidade, Inteligencia, Defesa, Energia, Habilidades, " +
                    "Curiosidades)" +
                    "VALUES (@nome, @idade, @origem, @classe, @forca, @agilidade, @inteligencia, @defesa, @energia, @habilidades, @curiosidades)";

                cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = ficha.Nome;
                cmd.Parameters.Add("@idade", MySqlDbType.Int32).Value = ficha.Idade;
                cmd.Parameters.Add("@origem", MySqlDbType.VarChar).Value = ficha.Origem;
                cmd.Parameters.Add("@classe", MySqlDbType.VarChar).Value = ficha.Classe;
                cmd.Parameters.Add("@forca", MySqlDbType.Int32).Value = ficha.Forca;
                cmd.Parameters.Add("@agilidade", MySqlDbType.Int32).Value = ficha.Agilidade;
                cmd.Parameters.Add("@inteligencia", MySqlDbType.Int32).Value = ficha.Inteligencia;
                cmd.Parameters.Add("@defesa", MySqlDbType.Int32).Value = ficha.Defesa;
                cmd.Parameters.Add("@energia", MySqlDbType.Int32).Value = ficha.Energia;
                cmd.Parameters.Add("@habilidades", MySqlDbType.Text).Value = ficha.Habilidades;
                cmd.Parameters.Add("@curiosidades", MySqlDbType.Text).Value = ficha.Curiosidades;

                cmd.ExecuteNonQuery();

                conexao.Close();
            }
        }

        public Ficha ObterFicha(string nome)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new("SELECT * FROM fichas WHERE nome = @nome", conexao);

                cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = nome;

                using (MySqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    Ficha ficha = null;

                    if (dr.Read())
                    {
                        ficha = new Ficha
                        {
                            Id = Convert.ToInt32(dr["id"]),
                            Nome = dr["nome"].ToString(),
                            Idade = Convert.ToInt32(dr["idade"]),
                            Origem = dr["origem"].ToString(),
                            Classe = dr["classe"].ToString(),
                            Forca = Convert.ToInt32(dr["forca"]),
                            Agilidade = Convert.ToInt32(dr["agilidade"]),
                            Inteligencia = Convert.ToInt32(dr["inteligencia"]),
                            Defesa = Convert.ToInt32(dr["defesa"]),
                            Energia = Convert.ToInt32(dr["energia"]),
                            Habilidades = dr["habilidades"].ToString(),
                            Curiosidades = dr["curiosidades"].ToString()
                        };
                    }
                    return ficha;
                }
            }
        }
    }
}
