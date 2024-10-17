using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml.Linq;


namespace Real_time_weather_monitoring_and_reporting_service
{
    public class DataInputParser
    {
        public static WeatherInputData ParseData(string data)
        {
            try
            {
                var jsonWeatherData = JsonSerializer.Deserialize<WeatherInputData>(data);
                return jsonWeatherData;
            }
            catch (JsonException)
            {
                try
                {
                    var xmlFile = XDocument.Parse(data);
                    var xmlWeatherData = new WeatherInputData
                    {
                        Location = xmlFile.Root.Element("Location").Value,
                        Temperature = double.Parse(xmlFile.Root.Element("Temperature").Value),
                        Humidity = double.Parse(xmlFile.Root.Element("Humidity").Value)
                    };
                    return xmlWeatherData;
                }
                catch (Exception ex2)
                {
                    throw new InvalidOperationException("Sorry , file has an invalid weather data format (valid fomats : XML , JSON) \n", ex2);
                }

            }
        }
    }

}
