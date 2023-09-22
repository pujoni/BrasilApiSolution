using System.Data;
using Dapper;
using Domain.Models;

namespace Repository.WeatherRepository
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly IDbConnection _connection;

        public WeatherRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void SaveCityWeather(WeatherCity cityWeather)
        {
            var query = @"
        INSERT INTO WeatherCity (Cidade, Estado, Atualizado_em) 
        VALUES (@Cidade, @Estado, @Atualizado_em);
        SELECT CAST(SCOPE_IDENTITY() as int)";
            var cityId = _connection.ExecuteScalar<int>(query, cityWeather);

            cityWeather.Clima.ForEach(c =>
            {
                SaveWeatherDetails(c, cityId);
            });
        }

        public int SaveWeatherDetails(WeatherDetails weatherDetails, int cityId)
        {
            weatherDetails.CityId = cityId;
            var query = @"
        INSERT INTO WeatherDetails (CityId, Data, Condicao, Min, Max, Indice_uv, Condicao_desc) 
        VALUES (@CityId, @Data, @Condicao, @Min, @Max, @Indice_uv, @Condicao_desc);
        SELECT CAST(SCOPE_IDENTITY() as int)";
            return _connection.ExecuteScalar<int>(query, weatherDetails);
        }

        public void SaveAirportWeather(WeatherAirport airportWeather)
        {
            var query = @"
                INSERT INTO WeatherAirport (
                    Codigo_icao, Atualizado_em, Pressao_atmosferica,
                    Visibilidade, Vento, Direcao_vento,
                    Umidade, Condicao, Condicao_Desc, Temp
                ) 
                VALUES (
                    @Codigo_icao, @Atualizado_em, @Pressao_atmosferica,
                    @Visibilidade, @Vento, @Direcao_vento,
                    @Umidade, @Condicao, @Condicao_Desc, @Temp
                )";
            _connection.Execute(query, airportWeather);
        }

        public void SaveCapitalWeather(WeatherCapital capitalWeather)
        {
            var query = @"
                INSERT INTO WeatherCapital (
                    Codigo_icao, Atualizado_em, Pressao_atmosferica,
                    Visibilidade, Vento, Direcao_vento,
                    Umidade, Condicao, Condicao_Desc, Temp
                ) 
                VALUES (
                    @Codigo_icao, @Atualizado_em, @Pressao_atmosferica,
                    @Visibilidade, @Vento, @Direcao_vento,
                    @Umidade, @Condicao, @Condicao_Desc, @Temp
                )";
            _connection.Execute(query, capitalWeather);
        }

        public void SaveErrorLog(ErrorLog errorLog)
        {
            var query = @"
                INSERT INTO ErrorLog (Message, StackTrace, Date) 
                VALUES (@Message, @StackTrace, @Date)";
            _connection.Execute(query, errorLog);
        }

    }
}
