namespace WeatherApp.Models
{
    public class WeatherModel
    {
        public List<StationMeasurement> StationMeasurements { get; set; } = new();

        public StationMeasurement? SelectedRegion { get; set; }
        public string SelectedRegionName { get; set; } = string.Empty;
    }
}
