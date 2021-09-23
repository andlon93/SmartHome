using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;
using System;

namespace SmartHome
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnTemparatureGetterClicked(object sender, EventArgs e)
        {
            var random = new Random();
            Temparature.Text = $"Indoor: {random.Next(20, 25)}C";
            Humidity.Text = $"Humidity: {random.Next(35, 45)}%";

            SemanticScreenReader.Announce(Temparature.Text);
            SemanticScreenReader.Announce(Humidity.Text);
        }
    }
}
