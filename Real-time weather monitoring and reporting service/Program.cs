using Real_time_weather_monitoring_and_reporting_service.Bots;
using Real_time_weather_monitoring_and_reporting_service;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        WeatherPublisher publisher = new WeatherPublisher();


        List<IWeatherBotObserver> bots = BotsFactory.CreateBots("botConfigFile.json");
        foreach (var bot in bots)
        {
            publisher.RegisterObserver(bot);
        }

        Console.WriteLine("Enter weather data (only JSON or XML format) or press Enter to read from a file:");
        string inputData = Console.ReadLine(); 

        if (string.IsNullOrWhiteSpace(inputData))
        {
            Console.WriteLine("Enter the file path (only JSON or XML format):");
            string filePath = Console.ReadLine();
            try
            {
                inputData = File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return; 
            }
        }

        try
        {
            WeatherData inputDataOfWeather = DataInputParser.ParseData(inputData);

            publisher.NotifyObservers(inputDataOfWeather);

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An Error occurred: {ex}");
        }
    }
}
