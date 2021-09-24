using System.Text.Json.Serialization;

namespace SmartHomeWebApp.Data.Yr.Dtos
{
    public class Geometry
    {
        [JsonPropertyName("coordinates")]
        public List<double> Coordinates { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
