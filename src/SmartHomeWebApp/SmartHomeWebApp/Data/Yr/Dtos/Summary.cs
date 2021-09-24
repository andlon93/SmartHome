using System.Text.Json.Serialization;

namespace SmartHomeWebApp.Data.Yr.Dtos
{
    public class Summary
    {
        [JsonPropertyName("symbol_code")]
        public string SymbolCode { get; set; }
    }
}
