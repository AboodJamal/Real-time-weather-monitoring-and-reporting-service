using System;
using Xunit;

namespace Real_time_weather_monitoring_and_reporting_service.Tests
{
    public class DataInputParserTests
    {
        [Fact]
        public void ParseData_ShouldParseJsonCorrectly()
        {
            string jsonData = "{\"Location\": \"New York\", \"Temperature\": 22.5, \"Humidity\": 65.0}";

            var result = DataInputParser.ParseData(jsonData);

            Assert.NotNull(result);
            Assert.Equal("New York", result.Location);
            Assert.Equal(22.5, result.Temperature);
            Assert.Equal(65.0, result.Humidity);
        }

        [Fact]
        public void ParseData_ShouldParseXmlCorrectly()
        {
            
            string xmlData = @"<Weather>
                                <Location>New York</Location>
                                <Temperature>22.5</Temperature>
                                <Humidity>65.0</Humidity>
                               </Weather>";

            var result = DataInputParser.ParseData(xmlData);

            Assert.NotNull(result);
            Assert.Equal("New York", result.Location);
            Assert.Equal(22.5, result.Temperature);
            Assert.Equal(65.0, result.Humidity);
        }

        [Fact]
        public void ParseData_ShouldThrowInvalidOperation_ForInvalidFormat()
        {
            string invalidData = "This is not a valid JSON or XML , normal text";

            var exception = Assert.Throws<InvalidOperationException>(() => DataInputParser.ParseData(invalidData));
            Assert.Contains("invalid weather data format", exception.Message);
        }
    }
}
