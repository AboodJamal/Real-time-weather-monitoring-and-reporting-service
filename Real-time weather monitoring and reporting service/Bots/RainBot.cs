namespace Real_time_weather_monitoring_and_reporting_service.Bots
{
    public class RainBot : IWeatherBotObserver
    {
        private double humidityThreshold;
        private string message;

        public RainBot(double humidityThreshold, string message)
        {
            this.humidityThreshold = humidityThreshold;
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
            Console.WriteLine("RainBot is activated");
            Console.WriteLine(this.message);
        }

        public bool IsActivated(WeatherData data)
        {
            return data.Humidity > this.humidityThreshold;
        }
    }
}
