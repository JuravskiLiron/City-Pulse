using CityPulse.Application.Interfaces;
using CityPulse.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CityPulse.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastService _service;

    public WeatherForecastController(IWeatherForecastService service)
    {
        _service = service;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return _service.GetForecast();
    }
}
