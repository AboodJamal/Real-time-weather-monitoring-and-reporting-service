using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_time_weather_monitoring_and_reporting_service.Bots
{
    public interface IWeatherBot
    {
        void ActivateBot(WeatherInputData data);
        bool IsActivated(WeatherInputData data);
    }
}
