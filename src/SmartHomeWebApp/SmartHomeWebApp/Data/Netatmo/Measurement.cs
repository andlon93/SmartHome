using System;

namespace Thermometer.Netatmo
{
    public class Measurement
    {
        public DateTime MeasureTime { get; set; }
        public object Temperature { get; set; }
        public object Humidity { get; set; }
        public object CO2 { get; set; }
        public object Noise { get; set; }
        public object Pressure { get; set; }
    }
}
