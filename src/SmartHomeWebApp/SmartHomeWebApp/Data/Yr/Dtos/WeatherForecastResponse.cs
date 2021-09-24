using System.Text.Json.Serialization;

namespace SmartHomeWebApp.Data.Yr.Dtos
{
    public class WeatherForecastResponse
    {
        [JsonPropertyName("properties")]
        public Properties Properties { get; set; }

        [JsonPropertyName("geometry")]
        public Geometry Geometry { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
