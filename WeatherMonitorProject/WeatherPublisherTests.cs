using Moq;
using Xunit;
using AutoFixture;
using FluentAssertions;
using System.Collections.Generic;
using Real_time_weather_monitoring_and_reporting_service.Bots;

namespace Real_time_weather_monitoring_and_reporting_service.Tests
{
    public class WeatherPublisherTests
    {
        private readonly Fixture _fixture;

        public WeatherPublisherTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void RegisterObserver_ShouldAddObserverToList()
        {
            // Arrange
            var weatherPublisher = new WeatherPublisher();
            var mockBot = new Mock<IWeatherBotObserver>();

            // Act
            weatherPublisher.RegisterObserver(mockBot.Object);

            // Assert
            var observers = weatherPublisher.GetObservers();
            Assert.Contains(mockBot.Object, observers);

            var exception = Record.Exception(() => weatherPublisher.RegisterObserver(mockBot.Object));
            exception.Should().BeNull();
        }


        [Fact]
        public void NotifyObservers_ShouldCallActivateBot_OnAllRegisteredBots()
        {
            // Arrange
            var weatherPublisher = new WeatherPublisher();

            var mockBot1 = new Mock<IWeatherBotObserver>();
            var mockBot2 = new Mock<IWeatherBotObserver>();

            var weatherData = _fixture.Create<WeatherData>();

            weatherPublisher.RegisterObserver(mockBot1.Object);
            weatherPublisher.RegisterObserver(mockBot2.Object);

            // Act
            weatherPublisher.NotifyObservers(weatherData);

            // Assert
            mockBot1.Verify(b => b.Update(weatherData), Times.Once);
            mockBot2.Verify(b => b.Update(weatherData), Times.Once);

            mockBot1.Invocations.Count.Should().Be(1);
            mockBot2.Invocations.Count.Should().Be(1);
        }

        [Fact]
        public void NotifyObservers_ShouldNotActivateBot_WhenNoObserverIsRegistered()
        {
            // Arrange
            var weatherPublisher = new WeatherPublisher();
            var weatherData = _fixture.Create<WeatherData>();

            // Act
            // Note: No observers are registered, so we don't need to register a mockBot here.

            // Assert
            var mockBot = new Mock<IWeatherBotObserver>();
            mockBot.Verify(b => b.Update(It.IsAny<WeatherData>()), Times.Never);
            mockBot.Invocations.Count.Should().Be(0);
        }

    }
}
