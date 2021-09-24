using System.Text.Json.Serialization;

namespace SmartHomeWebApp.Data.Yr.Dtos
{
    public class NextHours
    {
        [JsonPropertyName("summary")]
        public Summary Summary { get; set; }

        [JsonPropertyName("details")]
        public Details Details { get; set; }
    }
}
