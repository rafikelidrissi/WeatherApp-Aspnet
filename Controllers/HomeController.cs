using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherApp.Models;
using WeatherApp.Services.Interfaces;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWeatherService _weatherService;


        public HomeController(ILogger<HomeController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        public IActionResult Index()
        {

            var data = _weatherService.GetWeatherDataAsync().Result;
            var firstStationMeasurement = data.Actual.StationMeasurements.FirstOrDefault();
            var model = new WeatherModel
            {
                SelectedRegionName = firstStationMeasurement?.Regio ?? string.Empty,
                SelectedRegion = firstStationMeasurement,
                StationMeasurements = data.Actual.StationMeasurements
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult Index(WeatherModel weatherData)
        {
            weatherData.StationMeasurements = _weatherService.GetWeatherDataAsync().Result.Actual.StationMeasurements;
            weatherData.SelectedRegion = weatherData.StationMeasurements.Where(s => s.Regio == weatherData.SelectedRegionName).FirstOrDefault();
            return View(weatherData);
        }
    }
}
