using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Thermometer.GitHub;
using System.IO;
using System.Windows;
using System.Text.Json;
using System.Linq;

namespace Thermometer.Netatmo
{

    public class Measurement
    {
        public DateTime MeasureTime { get; set; }
        public object Temperature { get; set; }
        public object Humidity { get; set; }
    }
}
