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
            var weatherPublisher = new WeatherPublisher();
            var mockBot = new Mock<IWeatherBot>();

            weatherPublisher.RegisterObserver(mockBot.Object);

            var exception = Record.Exception(() => weatherPublisher.RegisterObserver(mockBot.Object));
            exception.Should().BeNull();
        }

        [Fact]
        public void NotifyObservers_ShouldCallActivateBot_OnAllRegisteredBots()
        {
            var weatherPublisher = new WeatherPublisher();

            var mockBot1 = new Mock<IWeatherBot>();
            var mockBot2 = new Mock<IWeatherBot>();

            var weatherData = _fixture.Create<WeatherInputData>();

            weatherPublisher.RegisterObserver(mockBot1.Object);
            weatherPublisher.RegisterObserver(mockBot2.Object);
            weatherPublisher.NotifyObservers(weatherData);


            mockBot1.Verify(b => b.ActivateBot(weatherData), Times.Once);
            mockBot2.Verify(b => b.ActivateBot(weatherData), Times.Once);

            mockBot1.Invocations.Count.Should().Be(1);
            mockBot2.Invocations.Count.Should().Be(1);
        }

     

        [Fact]
        public void NotifyObservers_ShouldNotActivateBot_WhenNoObserverIsRegistered()
        {
            var weatherPublisher = new WeatherPublisher();

            var weatherData = _fixture.Create<WeatherInputData>();

            var mockBot = new Mock<IWeatherBot>();
            mockBot.Verify(b => b.ActivateBot(It.IsAny<WeatherInputData>()), Times.Never);

            mockBot.Invocations.Count.Should().Be(0);
        }
    }
}
