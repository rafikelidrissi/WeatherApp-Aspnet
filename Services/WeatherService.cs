using Newtonsoft.Json;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public WeatherService(IConfiguration configuration)
        {
            _client = new HttpClient();
            _configuration = configuration;
        }

        public async Task<WeatherData> GetWeatherDataAsync()
        {
            var response = await _client.GetAsync(_configuration["WeatherApiUri"]);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(data)!;
            return weatherData;
        }
    }
}