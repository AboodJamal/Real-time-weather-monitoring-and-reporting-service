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

        public void ActivateBot(WeatherInputData data)
        {
            if (IsActivated(data))
            {
                Console.WriteLine("SunBot is activated!");
                Console.WriteLine(message);
            }
        }

        public bool IsActivated(WeatherInputData data)
        {
            return data.Temperature > temperatureThreshold;
        }
    }

}
