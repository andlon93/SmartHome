using System;

namespace Thermometer.Netatmo
{
    public class Measurement
    {
        public DateTime MeasureTime { get; set; }
        public object Temperature { get; set; }
        public object Humidity { get; set; }
    }
}
