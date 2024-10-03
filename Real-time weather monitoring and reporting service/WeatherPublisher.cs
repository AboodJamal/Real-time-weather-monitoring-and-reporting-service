using Real_time_weather_monitoring_and_reporting_service.Bots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_time_weather_monitoring_and_reporting_service
{
    public interface IWeatherPublisher
    {
        void RegisterObserver(IWeatherBot observer);
        void NotifyObservers(WeatherInputData data); 
    }

    public class WeatherPublisher : IWeatherPublisher
    {
        private List<IWeatherBot> observers = new List<IWeatherBot>();

        public void RegisterObserver(IWeatherBot observer)
        {
            observers.Add(observer);
        }

        public void NotifyObservers(WeatherInputData data)
        {
            foreach (var observer in observers)
            {
                observer.ActivateBot(data);
            }
        }
    }
}
