using System;
using Moq;
using Real_time_weather_monitoring_and_reporting_service.Bots;
using Real_time_weather_monitoring_and_reporting_service;
using Xunit;

public class WeatherBotTests
{
    [Fact]
    public void RainBot_ShouldPrintMessage_WhenHumidityIsAboveThreshold()
    {
        var data = new WeatherInputData { Humidity = 80 };
        var rainBot = new RainBot(70, "It's raining!");

        
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            rainBot.ActivateBot(data);

            
            var output = sw.ToString().Trim();
            Assert.Contains("RainBot is activated", output);
            Assert.Contains("It's raining!", output);
        }
    }

    [Fact]
    public void RainBot_ShouldReturnTrue_WhenHumidityIsAboveThreshold()
    {
       
        var data = new WeatherInputData { Humidity = 80 };
        var rainBot = new RainBot(70, "It's raining!");

        
        var result = rainBot.IsActivated(data);

        
        Assert.True(result);
    }

    [Fact]
    public void SnowBot_ShouldPrintMessage_WhenTemperatureIsBelowThreshold()
    {

        var data = new WeatherInputData { Temperature = -5 };
        var snowBot = new SnowBot(0, "It's snowing!");

        // Act
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            snowBot.ActivateBot(data);

            
            var output = sw.ToString().Trim();

            Assert.Contains("SnowBot is activated", output);
        }
    }

    [Fact]
    public void SnowBot_ShouldReturnTrue_WhenTemperatureIsBelowThreshold()
    {
        
        var data = new WeatherInputData { Temperature = -5 };
        var snowBot = new SnowBot(0, "It's snowing!");

        
        var result = snowBot.IsActivated(data);

        
        Assert.True(result);
    }

    [Fact]
    public void SunBot_ShouldPrintMessage_WhenTemperatureIsAboveThreshold()
    {
        
        var data = new WeatherInputData { Temperature = 30 };
        var sunBot = new SunBot(25, "It's sunny!");

        
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            sunBot.ActivateBot(data);

            
            var output = sw.ToString().Trim();
            Assert.Contains("SunBot is activated", output);
            Assert.Contains("It's sunny!", output);
        }
    }

    [Fact]
    public void SunBot_ShouldReturnTrue_WhenTemperatureIsAboveThreshold()
    {
        
        var data = new WeatherInputData { Temperature = 30 };
        var sunBot = new SunBot(25, "It's sunny!");

        
        var result = sunBot.IsActivated(data);

        
        Assert.True(result);
    }
}
