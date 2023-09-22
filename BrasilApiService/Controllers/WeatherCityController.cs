using Application.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Repository.WeatherRepository;
using System;
using System.Data;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BrasilApiService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherCityController : ControllerBase
    {
        private readonly IDbConnection _connection;
        private readonly BrasilApiServiceClient _brasilApiService;
        private readonly WeatherRepository _weatherRepository;

        public WeatherCityController(IDbConnection connection, BrasilApiServiceClient brasilApiService, WeatherRepository weatherRepository)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
            _brasilApiService = brasilApiService ?? throw new ArgumentNullException(nameof(brasilApiService));
            _weatherRepository = weatherRepository ?? throw new ArgumentNullException(nameof(weatherRepository));
        }

        [HttpGet("{cityCode}")]
        public async Task<IActionResult> GetCityWeather(int cityCode)
        {
            try
            {
                var cityWeather = await _brasilApiService.GetCityWeatherAsync(cityCode);
                _weatherRepository.SaveCityWeather(cityWeather);

                LogSuccess($"Dados do clima obtidos com sucesso para o código da cidade: {cityCode}", cityWeather.ToString());
                return Ok(cityWeather);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("cities")]
        public async Task<IActionResult> ListCities()
        {
            try
            {
                var cities = await _brasilApiService.ListCitiesAsync();

                LogSuccess("Lista de cidades obtida com sucesso.", cities.ToString());
                return Ok(cities);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("weather/capitals")]
        public async Task<IActionResult> GetCurrentWeatherForCapitals()
        {
            try
            {
                var weather = await _brasilApiService.GetCurrentWeatherForCapitalsAsync();

                LogSuccess("Dados do clima para capitais obtidos com sucesso.", weather.ToString());
                return Ok(weather);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("weather/airport/{icaoCode}")]
        public async Task<IActionResult> GetCurrentWeatherForAirport(string icaoCode)
        {
            try
            {
                var weatherAirport = await _brasilApiService.GetCurrentWeatherForAirportAsync(icaoCode);
                _weatherRepository.SaveAirportWeather(weatherAirport);

                LogSuccess($"Dados do clima obtidos com sucesso para o código ICAO do aeroporto: {icaoCode}", weatherAirport.ToString());
                return Ok(weatherAirport);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("weather/city/{cityCode}")]
        public async Task<IActionResult> GetWeatherForecastForCity(int cityCode)
        {
            try
            {
                var forecast = await _brasilApiService.GetWeatherForecastForCityAsync(cityCode);

                LogSuccess($"Previsão do tempo obtida com sucesso para o código da cidade: {cityCode}", forecast.ToString());
                return Ok(forecast);
            }
            catch (Exception ex)
            {
                LogError(ex);
                return BadRequest(new { error = ex.Message });
            }
        }

        private void LogError(Exception ex)
        {
            var errorLog = new ErrorLog { Message = ex.Message, StackTrace = ex.StackTrace, Date = DateTime.UtcNow };
            _weatherRepository.SaveErrorLog(errorLog);
        }

        private void LogSuccess(string message, object apiData)
        {
            var apiDataString = JsonConvert.SerializeObject(apiData, Formatting.Indented);
            var successLog = new ErrorLog { Message = message, StackTrace = $"API Response:\n{apiDataString}", Date = DateTime.UtcNow };
            _weatherRepository.SaveErrorLog(successLog);
        }
    }
}
