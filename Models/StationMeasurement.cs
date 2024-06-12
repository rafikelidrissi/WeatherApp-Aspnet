using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class StationMeasurement
    {
        [JsonProperty("$id")]
        public string id { get; set; }
        public string Regio { get; set; } = string.Empty;
        public string WindDirection { get; set; } = string.Empty;
        public double Temperature { get; set; }
        public double GroundTemperature { get; set; }
        public double FeelTemperature { get; set; }
        public double SunPower { get; set; }
        public double RainFallLastHour { get; set; }
    }
}
