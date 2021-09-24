using System.Collections.Generic;

namespace Thermometer.GitHub
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Place
    {
        public int altitude { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string timezone { get; set; }
        public List<double> location { get; set; }
    }

    public class Module
    {
        public string _id { get; set; }
        public string type { get; set; }
        public string module_name { get; set; }
        public int last_setup { get; set; }
        public List<string> data_type { get; set; }
        public int battery_percent { get; set; }
        public bool reachable { get; set; }
        public int firmware { get; set; }
        public int last_message { get; set; }
        public int last_seen { get; set; }
        public int rf_status { get; set; }
        public int battery_vp { get; set; }
    }

    public class Device
    {
        public string _id { get; set; }
        public string station_name { get; set; }
        public int date_setup { get; set; }
        public int last_setup { get; set; }
        public string type { get; set; }
        public int last_status_store { get; set; }
        public string module_name { get; set; }
        public int firmware { get; set; }
        public int last_upgrade { get; set; }
        public int wifi_status { get; set; }
        public bool reachable { get; set; }
        public bool co2_calibrating { get; set; }
        public List<string> data_type { get; set; }
        public Place place { get; set; }
        public string home_id { get; set; }
        public string home_name { get; set; }
        public List<Module> modules { get; set; }
    }

    public class Administrative
    {
        public string lang { get; set; }
        public string reg_locale { get; set; }
        public string country { get; set; }
        public int unit { get; set; }
        public int windunit { get; set; }
        public int pressureunit { get; set; }
        public int feel_like_algo { get; set; }
    }

    public class User
    {
        public string mail { get; set; }
        public Administrative administrative { get; set; }
    }

    public class Body
    {
        public List<Device> devices { get; set; }
        public User user { get; set; }
    }

    public class NetatmoResponse
    {
        public Body body { get; set; }
        public string status { get; set; }
        public double time_exec { get; set; }
        public int time_server { get; set; }
    }
}
