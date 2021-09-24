using SmartHomeWebApp.Data.Yr;
using SmartHomeWebApp.Data.Yr.Dtos;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text.Json;

namespace SmartHomeWebApp.Data
{
    public class WeatherForecastService
    {
        private readonly IHttpClientFactory _httpClientFactory;

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
                Summary = point.Data.Next6Hours == null ? string.Empty : $"{point.Data.Next6Hours.Summary.SymbolCode} {point.Data.Next6Hours.Details.PrecipitationAmount}",
            }).ToArray();
        }

        public async Task<WeatherForecast2> GetForecastAsync2()
        {
            var response = await GetWeatherLocationForecastAsync(59.959490, 11.048220, 109);
            var result = new WeatherForecast2();
            result.Days = response.Properties.Timeseries
                .GroupBy(
                    point => point.Time.Date,
                    (key, points) => new Day
                    {
                        Date = DateOnly.FromDateTime(key),
                        Timeseries = points.Select(p => new Timeserie2
                        {
                            Time = p.Time,
                            AirTemperature = (int)Math.Round(p.Data.Instant.Details.AirTemperature),
                            Symbol = (p.Data.Next1Hours ?? p.Data.Next6Hours ?? p.Data.Next12Hours)?.Summary?.SymbolCode ?? string.Empty,
                            Precipitation = (p.Data.Next1Hours?.Details ?? p.Data.Next6Hours?.Details ?? p.Data.Next12Hours?.Details)?.PrecipitationAmount ?? 0,
                        }).ToList()
                    })
                .ToList();
            return result;
        }

        public async Task<WeatherForecastResponse> GetWeatherLocationForecastAsync(double latitude, double longitude, int altitude)
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
                return JsonSerializer.Deserialize<WeatherForecastResponse>(datastr);
            }
        }
    }
}