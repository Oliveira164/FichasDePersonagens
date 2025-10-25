namespace FichasDePersonagens.Models
{
    public class Ficha
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Origem { get; set; }
        public string Classe { get; set; }
        public int Forca { get; set; }
        public int Agilidade { get; set; }
        public int Inteligencia { get; set; }
        public int Defesa { get; set; }
        public int Energia { get; set; }
        public string Habilidades { get; set; }
        public string Curiosidades { get; set; }
    }
}
