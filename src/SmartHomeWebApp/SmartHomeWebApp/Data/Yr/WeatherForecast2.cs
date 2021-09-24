namespace SmartHomeWebApp.Data.Yr
{
    public class WeatherForecast2
    {
        public List<Day> Days { get; set; } = new List<Day>();
    }

    public class Day
    {
        public DateOnly Date { get; set; }

        public List<Timeserie2> Timeseries { get; set; } = new List<Timeserie2>();
        public int AirTemperatureMin => Timeseries.MinBy(t => t.AirTemperature).AirTemperature;
        public int AirTemperatureMax => Timeseries.MaxBy(t => t.AirTemperature).AirTemperature;
        public string Night => Timeseries.FirstOrDefault(t => t.Time.Hour == 0)?.Symbol;
        public string Morning => Timeseries.FirstOrDefault(t => t.Time.Hour == 6)?.Symbol;
        public string Afternoon => Timeseries.FirstOrDefault(t => t.Time.Hour == 12)?.Symbol;
        public string Evening => Timeseries.FirstOrDefault(t => t.Time.Hour == 18)?.Symbol;
        public double Precipitation => Timeseries.Sum(t => t.Precipitation);
        //Wind
    }

    public class Timeserie2
    {
        public DateTime Time { get; set; }
        public int AirTemperature { get; set; }
        public string Symbol {  get; set; }
        public double Precipitation {  get; set; }
    }
}