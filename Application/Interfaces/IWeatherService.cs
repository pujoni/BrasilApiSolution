using Domain.Models;

public interface IWeatherService
{
    Task<WeatherCity> GetCityWeatherAsync(int cityCode);
    Task<WeatherAirport> GetAirportWeatherAsync(string icaoCode);
}
