using System;
using System.Threading.Tasks;
using Thermometer.GitHub;
using Thermometer.Netatmo;

namespace Thermometer
{
    class Program
    {
        private static readonly GitHubService _gitHubService = new GitHubService();
        private static readonly NetatmoService _netatmoService = new NetatmoService();

        static async Task Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = await MainMenu();
            }

            await MainMenu();
        }

        private static async Task<bool> MainMenu()
        {
            //Console.Clear();
            Console.WriteLine("Hello Thermometer!\r\n");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Login");
            Console.WriteLine("2) Get station data");
            Console.WriteLine("3) Get measures");
            Console.WriteLine("4) Latest");
            Console.WriteLine("5) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    await Login();
                    return true;
                case "2":
                    await GetStationsData();
                    return true;
                case "3":
                    await GetMeasure();
                    return true;
                case "4":
                    await GetLatest();
                    return true;
                case "5":
                    return false;
                default:
                    return true;
            }
        }

        private static async Task Login()
        {
            await _netatmoService.Login();
        }

        private static async Task GetStationsData()
        {
            var weatherData = await _netatmoService.GetNetatmoWeatherDataAsync();
            Console.WriteLine($"User: {weatherData.body.user.mail}");
            Console.WriteLine($"Lang: {weatherData.body.user.administrative.lang}");
            Console.WriteLine($"reg_locale: {weatherData.body.user.administrative.reg_locale}");
            Console.WriteLine($"country: {weatherData.body.user.administrative.country}");
            Console.WriteLine($"unit: {weatherData.body.user.administrative.unit}");
            Console.WriteLine($"windunit: {weatherData.body.user.administrative.windunit}");
            Console.WriteLine($"pressureunit: {weatherData.body.user.administrative.pressureunit}");
            Console.WriteLine($"feel_like_algo: {weatherData.body.user.administrative.feel_like_algo}");
            Console.WriteLine();

            foreach (var device in weatherData.body.devices)
            {
                Console.WriteLine("Home: " + device.home_name);
                Console.WriteLine("Home ID: " + device.home_name);
                Console.WriteLine("Station: " + device.station_name);
                Console.WriteLine("Module Name: " + device.module_name);
                Console.WriteLine("Module ID: " + device._id);
                foreach (var module in device.modules)
                {
                    Console.WriteLine($"Name: {module.module_name}");
                    Console.WriteLine($"ID: {module._id}");
                    Console.WriteLine($"Type: {module.type}");
                    Console.WriteLine($"Battery: {module.battery_percent} %");
                }
            }
        }

        private static async Task GetMeasure()
        {
            var response = await _netatmoService.GetMeasureAsync();
            foreach (var measurement in response.Measurements)
            {
                var time = DateTimeHelper.TimeStampToLocalDateTime(measurement.StartTime);
                Console.WriteLine($"beg_time: { time.ToShortDateString() } {time.ToLongTimeString()}");
                Console.WriteLine($"step_time: {measurement.StepTime}");
                foreach (var value in measurement.Value)
                {
                    if (value.Count == 2)
                    {
                        Console.WriteLine(time.ToLongTimeString() + " " + value[0] + " °C, " + value[1] + " %");
                    }
                    time = time.AddSeconds(measurement.StepTime);
                }
            }
        }

        private static async Task GetLatest()
        {
            Console.WriteLine("Indoor");
            var indoor = await _netatmoService.GetLatestMeasurementIndoor();
            Console.WriteLine(indoor.MeasureTime.ToLongTimeString() + " " + indoor.Temperature + " °C, " + indoor.Humidity + " %");
            Console.WriteLine("Outdoor");
            var outdoor = await _netatmoService.GetLatestMeasurementOutdoor();
            Console.WriteLine(outdoor.MeasureTime.ToLongTimeString() + " " + outdoor.Temperature + " °C, " + outdoor.Humidity + " %");
        }
    }
}
