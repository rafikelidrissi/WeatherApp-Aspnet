using WeatherApp.Models;

namespace WeatherApp.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeatherDataAsync();
    }
}