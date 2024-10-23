using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_time_weather_monitoring_and_reporting_service
{
    public class BotConfiguration
    {
        public bool Enabled { get; set; }
        public double TemperatureThreshold { get; set; }
        public double HumidityThreshold { get; set; }
        public string Message { get; set; }
    }

    public class WeatherBotConfiguration
    {
        public BotConfiguration RainBot { get; set; }
        public BotConfiguration SunBot { get; set; }
        public BotConfiguration SnowBot { get; set; }
    }


}
