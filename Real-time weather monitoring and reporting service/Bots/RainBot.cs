using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_time_weather_monitoring_and_reporting_service.Bots
{
    public class RainBot : IWeatherBot
    {
        private double humidityThreshold;
        private string message;

        public RainBot(double humidityThreshold, string message)
        {
            this.humidityThreshold = humidityThreshold;
            this.message = message;
        }

        public void ActivateBot(WeatherInputData data)
        {
            if (IsActivated(data))
            {
                Console.WriteLine("RainBot is activated");
                Console.WriteLine(this.message);
            }
        }

        public bool IsActivated(WeatherInputData data)
        {
            return data.Humidity > this.humidityThreshold;
        }
    }

}
