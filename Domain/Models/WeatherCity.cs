namespace Domain.Models
{
    public class WeatherCity
    {
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime Atualizado_em { get; set; }
        public List<WeatherDetails> Clima { get; set; } = new List<WeatherDetails>();
    }

    public class WeatherDetails
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Data { get; set; }
        public string Condicao { get; set;}
        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public decimal Indice_uv { get; set; }
        public string Condicao_desc { get; set; }
    }

}
