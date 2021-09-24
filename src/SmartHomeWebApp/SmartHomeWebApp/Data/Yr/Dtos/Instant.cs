using System.Text.Json.Serialization;

namespace SmartHomeWebApp.Data.Yr.Dtos
{
    public class Instant
    {
        [JsonPropertyName("details")]
        public Details Details { get; set; }
    }
}
