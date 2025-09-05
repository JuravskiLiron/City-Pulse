using CityPulse.Application.Services;
using System.Linq;
using Xunit;

namespace CityPulse.Tests;

public class WeatherForecastServiceTests
{
    [Fact]
    public void GetForecast_Returns_FiveEntries()
    {
        var service = new WeatherForecastService();
        var result = service.GetForecast();
        Assert.Equal(5, result.Count());
    }
}
