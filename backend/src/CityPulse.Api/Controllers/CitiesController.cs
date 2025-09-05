using CityPulse.Application.Interfaces;
using CityPulse.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityPulse.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CitiesController : ControllerBase
{
    private readonly ICityService _service;

    public CitiesController(ICityService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cities = await _service.GetAllAsync();
        return Ok(cities);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var city = await _service.GetByIdAsync(id);
        return city is null ? NotFound() : Ok(city);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCityDto dto)
    {
        var city = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(Get), new { id = city.Id }, city);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateCityDto dto)
    {
        await _service.UpdateAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
