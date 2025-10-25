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

        public List<Ficha> ObterFicha()
        {
            var fichas = new List<Ficha>();

            using (var connection = new MySqlConnection(_conexaoMySQL))
            {
                connection.Open();
                var query = "SELECT * FROM fichas";
                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ficha = new Ficha
                        {
                            Id = reader.GetInt32("Id"),
                            Nome = reader.GetString("Nome"),
                            Idade = reader.GetInt32("Idade"),
                            Origem = reader.GetString("Origem"),
                            Classe = reader.GetString("Classe"),
                            Forca = reader.GetInt32("Forca"),
                            Agilidade = reader.GetInt32("Agilidade"),
                            Inteligencia = reader.GetInt32("Inteligencia"),
                            Defesa = reader.GetInt32("Defesa"),
                            Energia = reader.GetInt32("Energia"),
                            Habilidades = reader.GetString("Habilidades"),
                            Curiosidades = reader.GetString("Curiosidades")
                        };
                        fichas.Add(ficha);
                    }
                }
            }
            return fichas;
        }
    }
}
  

