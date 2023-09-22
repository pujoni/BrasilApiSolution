namespace Domain.Models
{
    public class WeatherAirport
    {
        public string Codigo_icao { get; set; }
        public DateTime Atualizado_em { get; set; }
        public decimal Pressao_atmosferica { get; set; }
        public string Visibilidade { get; set; }
        public int Vento { get; set; }
        public int Direcao_vento { get; set; }
        public int Umidade { get; set; }
        public string Condicao { get; set; }
        public string Condicao_Desc { get; set; }
        public int Temp { get; set; }
    }

}
