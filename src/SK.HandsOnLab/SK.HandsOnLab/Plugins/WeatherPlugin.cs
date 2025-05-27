using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace SK.HandsOnLab.Plugins
{

    internal sealed record WeatherForecast(
        string Date,
        string Location,
        string HighTemperature,
        string LowTemperature,
        string Precipition);

    internal class WeatherPlugin
    {
        private readonly Dictionary<string, WeatherForecast> _forecasts = [];

        [KernelFunction]
        [Description("Provide the weather information for the given date and location.")]
        public WeatherForecast GetWeatherInformation(
            string date,
            string location)
        { 
            Console.WriteLine($"Calling {nameof(GetWeatherInformation)} from {nameof(WeatherPlugin)}");

            string key = $"{date}-{location}";

            if (!this._forecasts.TryGetValue(key, out WeatherForecast? forecast))
            {
                forecast = GenerateForecast(date, location);
                this._forecasts[key] = forecast;
            }

            return forecast;
        }

        private WeatherForecast GenerateForecast(string date, string location)
        {
            int highTemp = Random.Shared.Next(49, 96);
            int lowTemp = highTemp - Random.Shared.Next(12, 20);
            int precip = Random.Shared.Next(0, 80);

            return
                new WeatherForecast(
                    date,
                    location,
                    $"{highTemp} F",
                    $"{lowTemp} F",
                    $"{precip} %");
        }
    }
}
