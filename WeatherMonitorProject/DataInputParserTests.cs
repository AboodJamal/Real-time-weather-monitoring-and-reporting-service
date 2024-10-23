using System;
using Xunit;

namespace Real_time_weather_monitoring_and_reporting_service.Tests
{
    public class DataInputParserTests
    {
        [Fact]
        public void ParseData_ShouldParseJsonCorrectly()
        {
            // Arrange
            string jsonData = "{\"Location\": \"New York\", \"Temperature\": 22.5, \"Humidity\": 65.0}";

            // Act
            var result = DataInputParser.ParseData(jsonData);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("New York", result.Location);
            Assert.Equal(22.5, result.Temperature);
            Assert.Equal(65.0, result.Humidity);
        }

        [Fact]
        public void ParseData_ShouldParseXmlCorrectly()
        {
            // Arrange
            string xmlData = @"<Weather>
                            <Location>New York</Location>
                            <Temperature>22.5</Temperature>
                            <Humidity>65.0</Humidity>
                           </Weather>";

            // Act
            var result = DataInputParser.ParseData(xmlData);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("New York", result.Location);
            Assert.Equal(22.5, result.Temperature);
            Assert.Equal(65.0, result.Humidity);
        }

        [Fact]
        public void ParseData_ShouldThrowInvalidOperation_ForInvalidFormat()
        {
            // Arrange
            string invalidData = "This is not a valid JSON or XML , normal text";

            // Act
            var exception = Assert.Throws<InvalidOperationException>(() => DataInputParser.ParseData(invalidData));

            // Assert
            Assert.Contains("invalid weather data format", exception.Message);
        }
    }

}
