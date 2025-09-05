using CityPulse.Domain.Entities;

namespace CityPulse.Application.Interfaces;

public interface IWeatherForecastService
{
    IEnumerable<WeatherForecast> GetForecast();
}
