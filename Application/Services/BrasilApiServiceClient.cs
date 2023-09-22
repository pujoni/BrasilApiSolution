using Domain.Models;
using System.Net.Http.Json;

namespace Application.Services
{
    public class BrasilApiServiceClient : IWeatherService
    {
       
        private readonly HttpClient _httpClient;

        public BrasilApiServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherCity> GetCityWeatherAsync(int cityCode)
        {
            var response = await _httpClient.GetAsync($"api/cptec/v1/clima/previsao/{cityCode}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<WeatherCity>();
            return result;
        }

        public async Task<WeatherAirport> GetAirportWeatherAsync(string icaoCode)
        {
            var response = await _httpClient.GetAsync($"api/cptec/v1/clima/aeroporto/{icaoCode}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<WeatherAirport>();
            return result;
        }
        public async Task<IEnumerable<City>> ListCitiesAsync()
        {
            var response = await _httpClient.GetAsync($"api/cptec/v1/cidade");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<IEnumerable<City>>();
            return result;
        }

        public async Task<IEnumerable<WeatherCapital>> GetCurrentWeatherForCapitalsAsync()
        {
            var response = await _httpClient.GetAsync($"api/cptec/v1/clima/capital");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<IEnumerable<WeatherCapital>>();
            return result;
        }

        public async Task<WeatherAirport> GetCurrentWeatherForAirportAsync(string icaoCode) 
        {
            var response = await _httpClient.GetAsync($"api/cptec/v1/clima/aeroporto/{icaoCode}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<WeatherAirport>();
            return result;
        }

        public async Task<WeatherCity> GetWeatherForecastForCityAsync(int cityCode)
        {
            var response = await _httpClient.GetAsync($"api/cptec/v1/clima/previsao/{cityCode}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<WeatherCity>();
            return result;
        }


    }

}
