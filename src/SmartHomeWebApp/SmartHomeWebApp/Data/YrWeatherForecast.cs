﻿using System.Text.Json.Serialization;

namespace SmartHomeWebApp.Data
{
    public class Details
    {
        [JsonPropertyName("precipitation_amount_max")]
        public double PrecipitationAmountMax { get; set; }

        [JsonPropertyName("air_temperature_min")]
        public double AirTemperatureMin { get; set; }

        [JsonPropertyName("probability_of_precipitation")]
        public int ProbabilityOfPrecipitation { get; set; }

        [JsonPropertyName("air_temperature_max")]
        public double AirTemperatureMax { get; set; }

        [JsonPropertyName("ultraviolet_index_clear_sky_max")]
        public int UltravioletIndexClearSkyMax { get; set; }

        [JsonPropertyName("probability_of_thunder")]
        public double ProbabilityOfThunder { get; set; }

        [JsonPropertyName("precipitation_amount")]
        public double PrecipitationAmount { get; set; }

        [JsonPropertyName("precipitation_amount_min")]
        public double PrecipitationAmountMin { get; set; }

        [JsonPropertyName("cloud_area_fraction_high")]
        public double CloudAreaFractionHigh { get; set; }

        [JsonPropertyName("wind_from_direction")]
        public double WindFromDirection { get; set; }

        [JsonPropertyName("cloud_area_fraction_medium")]
        public double CloudAreaFractionMedium { get; set; }

        [JsonPropertyName("relative_humidity")]
        public double RelativeHumidity { get; set; }

        [JsonPropertyName("wind_speed_of_gust")]
        public double WindSpeedOfGust { get; set; }

        [JsonPropertyName("wind_speed")]
        public double WindSpeed { get; set; }

        [JsonPropertyName("dew_point_temperature")]
        public double DewPointTemperature { get; set; }

        [JsonPropertyName("air_pressure_at_sea_level")]
        public double AirPressureAtSeaLevel { get; set; }

        [JsonPropertyName("cloud_area_fraction")]
        public double CloudAreaFraction { get; set; }

        [JsonPropertyName("fog_area_fraction")]
        public double FogAreaFraction { get; set; }

        [JsonPropertyName("air_temperature")]
        public double AirTemperature { get; set; }

        [JsonPropertyName("cloud_area_fraction_low")]
        public double CloudAreaFractionLow { get; set; }
    }

    public class Summary
    {
        [JsonPropertyName("symbol_code")]
        public string SymbolCode { get; set; }
    }

    public class Next12Hours
    {
        [JsonPropertyName("details")]
        public Details Details { get; set; }

        [JsonPropertyName("summary")]
        public Summary Summary { get; set; }
    }

    public class Next6Hours
    {
        [JsonPropertyName("details")]
        public Details Details { get; set; }

        [JsonPropertyName("summary")]
        public Summary Summary { get; set; }
    }

    public class Next1Hours
    {
        [JsonPropertyName("summary")]
        public Summary Summary { get; set; }

        [JsonPropertyName("details")]
        public Details Details { get; set; }
    }

    public class Instant
    {
        [JsonPropertyName("details")]
        public Details Details { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("next_12_hours")]
        public Next12Hours Next12Hours { get; set; }

        [JsonPropertyName("next_6_hours")]
        public Next6Hours Next6Hours { get; set; }

        [JsonPropertyName("next_1_hours")]
        public Next1Hours Next1Hours { get; set; }

        [JsonPropertyName("instant")]
        public Instant Instant { get; set; }
    }

    public class Timesery
    {
        [JsonPropertyName("time")]
        public DateTime Time { get; set; }

        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

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

    public class Meta
    {
        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("units")]
        public Units Units { get; set; }
    }

    public class Properties
    {
        [JsonPropertyName("timeseries")]
        public List<Timesery> Timeseries { get; set; }

        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }
    }

    public class Geometry
    {
        [JsonPropertyName("coordinates")]
        public List<double> Coordinates { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class YrWeatherForecast
    {
        [JsonPropertyName("properties")]
        public Properties Properties { get; set; }

        [JsonPropertyName("geometry")]
        public Geometry Geometry { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }


}