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
        void RegisterObserver(IWeatherBotObserver observer);
        void NotifyObservers(WeatherData data);
        IList<IWeatherBotObserver> GetObservers(); 
    }

    public class WeatherPublisher : IWeatherPublisher
    {
        private List<IWeatherBotObserver> observers = new List<IWeatherBotObserver>();

        public void RegisterObserver(IWeatherBotObserver observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException(nameof(observer), "Observer must not be null");
            }

            observers.Add(observer);
        }

        public void NotifyObservers(WeatherData data)
        {
            foreach (var observer in observers)
            {
                observer.Update(data);
            }
        }

        public IList<IWeatherBotObserver> GetObservers() 
        {
            return observers.AsReadOnly(); 
        }
    }

}
