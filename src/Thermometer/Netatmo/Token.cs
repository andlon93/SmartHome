using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Thermometer.GitHub
{
    public class Token
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("scope")]
        public string[] Scope;

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
