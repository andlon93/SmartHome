namespace SmartHomeWebApp.Data.Yr
{
    public static class Urls
    {
        public static string WeatherLocationForecastUrl => $"{UrlBase}{UrlWeatherLocationForecastPath}";

        private static readonly string UrlBase = "https://api.met.no";
        private static readonly string UrlWeatherLocationForecastPath = "/weatherapi/locationforecast/2.0/compact";
    }
}
