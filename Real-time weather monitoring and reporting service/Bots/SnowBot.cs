using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_time_weather_monitoring_and_reporting_service.Bots
{
    public class SnowBot : IWeatherBotObserver
    {
        private double temperatureThreshold;
        private string message;

        public SnowBot(double temperatureThreshold, string message)
        {
            this.temperatureThreshold = temperatureThreshold; 
            this.message = message;
        }

        public void Update(WeatherData data)
        {
            if (IsActivated(data))
            {
                ActivateBot();
            }
        }

        private void ActivateBot()
        {
            Console.WriteLine("SnowBot is activated!");
            Console.WriteLine(this.message);
        }

        public bool IsActivated(WeatherData data)
        {
            return data.Temperature < this.temperatureThreshold;
        }
    }


}
