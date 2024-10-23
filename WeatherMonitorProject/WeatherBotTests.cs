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
        // Arrange
        var data = new WeatherData { Humidity = 80 };
        var rainBot = new RainBot(70, "It's raining!");

        // Act
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            rainBot.Update(data);

            var output = sw.ToString().Trim();

            // Assert
            Assert.Contains("RainBot is activated", output);
            Assert.Contains("It's raining!", output);
        }
    }

    [Fact]
    public void RainBot_ShouldBeActivated_WhenHumidityIsAboveThreshold()
    {
        // Arrange
        var data = new WeatherData { Humidity = 80 };
        var rainBot = new RainBot(70, "It's raining!");

        // Act
        var result = rainBot.IsActivated(data);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void SnowBot_ShouldPrintMessage_WhenTemperatureIsBelowThreshold()
    {
        // Arrange
        var data = new WeatherData { Temperature = -5 };
        var snowBot = new SnowBot(0, "It's snowing!");

        // Act
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            snowBot.Update(data);

            var output = sw.ToString().Trim();

            // Assert
            Assert.Contains("SnowBot is activated", output);
        }
    }

    [Fact]
    public void SnowBot_ShouldBeActivated_WhenHumidityIsAboveThreshold()
    {
        // Arrange
        var data = new WeatherData { Temperature = -5 };
        var snowBot = new SnowBot(0, "It's snowing!");

        // Act
        var result = snowBot.IsActivated(data);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void SunBot_ShouldPrintMessage_WhenTemperatureIsAboveThreshold()
    {
        // Arrange
        var data = new WeatherData { Temperature = 30 };
        var sunBot = new SunBot(25, "It's sunny!");

        // Act
        using (var sw = new StringWriter())
        {
            Console.SetOut(sw);
            sunBot.Update(data);

            var output = sw.ToString().Trim();

            // Assert
            Assert.Contains("SunBot is activated", output);
            Assert.Contains("It's sunny!", output);
        }
    }

    [Fact]
    public void SunBot_ShouldBeActivated_WhenHumidityIsAboveThreshold()
    {
        // Arrange
        var data = new WeatherData { Temperature = 30 };
        var sunBot = new SunBot(25, "It's sunny!");

        // Act
        var result = sunBot.IsActivated(data);

        // Assert
        Assert.True(result);
    }

}
