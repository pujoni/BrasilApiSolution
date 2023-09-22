using Domain.Models;

public interface IWeatherRepository
{
    void SaveCityWeather(WeatherCity cityWeather);
    void SaveAirportWeather(WeatherAirport airportWeather);
    void SaveErrorLog(ErrorLog errorLog);
}
