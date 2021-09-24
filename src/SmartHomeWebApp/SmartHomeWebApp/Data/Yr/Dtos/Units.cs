using System.Text.Json.Serialization;

namespace SmartHomeWebApp.Data.Yr.Dtos
{
    public class Units
    {
        [JsonPropertyName("cloud_area_fraction_low")]
        public string CloudAreaFractionLow { get; set; }

        [JsonPropertyName("air_temperature")]
        public string AirTemperature { get; set; }

        [JsonPropertyName("fog_area_fraction")]
        public string FogAreaFraction { get; set; }

        [JsonPropertyName("precipitation_amount")]
        public string PrecipitationAmount { get; set; }

        [JsonPropertyName("probability_of_thunder")]
        public string ProbabilityOfThunder { get; set; }

        [JsonPropertyName("air_pressure_at_sea_level")]
        public string AirPressureAtSeaLevel { get; set; }

        [JsonPropertyName("ultraviolet_index_clear_sky_max")]
        public string UltravioletIndexClearSkyMax { get; set; }

        [JsonPropertyName("relative_humidity")]
        public string RelativeHumidity { get; set; }

        [JsonPropertyName("cloud_area_fraction_medium")]
        public string CloudAreaFractionMedium { get; set; }

        [JsonPropertyName("precipitation_amount_max")]
        public string PrecipitationAmountMax { get; set; }

        [JsonPropertyName("cloud_area_fraction_high")]
        public string CloudAreaFractionHigh { get; set; }

        [JsonPropertyName("probability_of_precipitation")]
        public string ProbabilityOfPrecipitation { get; set; }

        [JsonPropertyName("precipitation_amount_min")]
        public string PrecipitationAmountMin { get; set; }

        [JsonPropertyName("cloud_area_fraction")]
        public string CloudAreaFraction { get; set; }

        [JsonPropertyName("wind_speed")]
        public string WindSpeed { get; set; }

        [JsonPropertyName("dew_point_temperature")]
        public string DewPointTemperature { get; set; }

        [JsonPropertyName("air_temperature_max")]
        public string AirTemperatureMax { get; set; }

        [JsonPropertyName("wind_speed_of_gust")]
        public string WindSpeedOfGust { get; set; }

        [JsonPropertyName("air_temperature_min")]
        public string AirTemperatureMin { get; set; }

        [JsonPropertyName("wind_from_direction")]
        public string WindFromDirection { get; set; }
    }
}
