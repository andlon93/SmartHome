using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Thermometer.Netatmo
{
    public class NetatmoMeasurement
    {
        [JsonPropertyName("beg_time")]
        public int StartTime { get; set; }

        [JsonPropertyName("step_time")]
        public int StepTime { get; set; }

        [JsonPropertyName("value")]
        public List<List<object>> Value { get; set; }
    }

    public class NetatmoMeasureResponse
    {
        [JsonPropertyName("body")]
        public List<NetatmoMeasurement> Measurements { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("time_exec")]
        public double TimeExec { get; set; }

        [JsonPropertyName("time_server")]
        public int TimeServer { get; set; }
    }
}
