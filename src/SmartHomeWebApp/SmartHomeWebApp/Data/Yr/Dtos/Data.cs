using System.Text.Json.Serialization;

namespace SmartHomeWebApp.Data.Yr.Dtos
{
    public class Data
    {
        [JsonPropertyName("next_12_hours")]
        public NextHours Next12Hours { get; set; }

        [JsonPropertyName("next_6_hours")]
        public NextHours Next6Hours { get; set; }

        [JsonPropertyName("next_1_hours")]
        public NextHours Next1Hours { get; set; }

        [JsonPropertyName("instant")]
        public Instant Instant { get; set; }
    }
}
