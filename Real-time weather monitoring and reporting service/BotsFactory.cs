using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Real_time_weather_monitoring_and_reporting_service.Bots;

namespace Real_time_weather_monitoring_and_reporting_service
{
    public class BotsFactory
    {
        public static List<IWeatherBot> CreateBots(string configFilePath)
        {
            var bots = new List<IWeatherBot>();
            var configText = File.ReadAllText(configFilePath);
            var config = JsonSerializer.Deserialize<WeatherBotConfiguration>(configText); // properties has to be exactly same as the keys in json

            if (config.RainBot.Enabled)
            {
                bots.Add(new RainBot(config.RainBot.HumidityThreshold, config.RainBot.Message));
            }

            if (config.SunBot.Enabled)
            {
                bots.Add(new SunBot(config.SunBot.TemperatureThreshold, config.SunBot.Message));
            }

            if (config.SnowBot.Enabled)
            {
                bots.Add(new SnowBot(config.SnowBot.TemperatureThreshold, config.SnowBot.Message));
            }

            return bots;
        }
    }
}
