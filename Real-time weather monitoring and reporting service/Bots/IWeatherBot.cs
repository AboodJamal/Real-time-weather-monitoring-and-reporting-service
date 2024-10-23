﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_time_weather_monitoring_and_reporting_service.Bots
{
    public interface IWeatherBotObserver
    {
        void Update(WeatherData data);
        bool IsActivated(WeatherData data);
    }
}
