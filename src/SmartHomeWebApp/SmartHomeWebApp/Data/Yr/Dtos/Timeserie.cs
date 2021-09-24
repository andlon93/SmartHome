using System.Text.Json.Serialization;

namespace SmartHomeWebApp.Data.Yr.Dtos
{
    public class Timeserie
    {
        [JsonPropertyName("time")]
        public DateTime Time { get; set; }

        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }
}
