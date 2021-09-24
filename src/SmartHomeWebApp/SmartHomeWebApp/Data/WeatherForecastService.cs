using System.Globalization;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SmartHomeWebApp.Data
{
    public class WeatherForecastService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var response = await GetWeatherLocationForecastAsync(59.959490, 11.048220, 109);
            return response.Properties.Timeseries.Select(point => new WeatherForecast
            {
                Date = point.Time,
                TemperatureC = (int)Math.Round(point.Data.Instant.Details.AirTemperature),
                Summary = point.Data.Next1Hours == null ? string.Empty : $"{point.Data.Next1Hours.Summary.SymbolCode} {point.Data.Next1Hours.Details.PrecipitationAmount}",
            }).ToArray();
        }

        public async Task<YrWeatherForecast> GetWeatherLocationForecastAsync(double latitude, double longitude, int altitude)
        {
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("SmartHome", "0.1"));

                var values = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("altitude", altitude.ToString()),
                    new KeyValuePair<string, string>("lat", latitude.ToString()),
                    new KeyValuePair<string, string>("lon", longitude.ToString()),
                };
                var content = new FormUrlEncodedContent(values);

                var response = await httpClient.GetAsync($"{Urls.WeatherLocationForecastUrl}?altitude={altitude.ToString(CultureInfo.InvariantCulture)}&lat={latitude.ToString(CultureInfo.InvariantCulture)}&lon={longitude.ToString(CultureInfo.InvariantCulture)}");
                var datastr = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<YrWeatherForecast>(datastr);
            }
        }
    }
}