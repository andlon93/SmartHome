namespace SmartHomeWebApp.Data.Yr
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public Wind Wind { get; set; }
        public Precipitation Precipitation { get; set; }

        public string? Summary { get; set; }
    }
    public class Wind
    {
        public int Normal { get; set; }
        public int Maximum { get; set; }

        public string Direction { get; set; }
        public string Description { get; set; }
    }
    public class Precipitation
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }
    }
}