using System.Text.Json.Serialization;

namespace SmartHomeWebApp.Data.Yr.Dtos
{
    public class Properties
    {
        [JsonPropertyName("timeseries")]
        public List<Timeserie> Timeseries { get; set; }

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
    }
}
