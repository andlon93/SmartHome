using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using System;
using System.Threading.Tasks;
using Thermometer.Netatmo;

namespace SmartHome
{
    public partial class MainPage : ContentPage
    {
        //private readonly NetatmoService _netatmoService;
        public MainPage()
        {
            InitializeComponent();
            //_netatmoService = netatmoService;
        }

        private void OnTemparatureGetterClicked(object sender, EventArgs e)
        {
            var _netatmoService = new NetatmoService();
            var measurement = _netatmoService.GetLatestMeasurementIndoor().GetAwaiter().GetResult();

            Temparature.Text = $"Indoor: {measurement.Temperature}C";
            Humidity.Text = $"Humidity: {measurement.Humidity}%";

            SemanticScreenReader.Announce(Temparature.Text);
            SemanticScreenReader.Announce(Humidity.Text);
            //var random = new Random();
            //Temparature.Text = $"Indoor: {random.Next(20, 25)}C";
            //Humidity.Text = $"Humidity: {random.Next(35, 45)}%";

            //SemanticScreenReader.Announce(Temparature.Text);
            //SemanticScreenReader.Announce(Humidity.Text);
        }
    }
}
