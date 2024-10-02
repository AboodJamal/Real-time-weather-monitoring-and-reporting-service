using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_time_weather_monitoring_and_reporting_service.Bots
{
    public class SunBot : IWeatherBot
    {
        private double temperatureThreshold;
        private string message;

        public SunBot(double temperatureThreshold, string message)
        {
            this.temperatureThreshold = temperatureThreshold;
            this.message = message;
        }

        public void Activate(WeatherData data)
        {
            if (IsActivated(data))
            {
                Console.WriteLine("SunBot activated!");
                Console.WriteLine(message);
            }
        }

        public bool IsActivated(WeatherData data)
        {
            return data.Temperature > temperatureThreshold;
        }
    }

}
