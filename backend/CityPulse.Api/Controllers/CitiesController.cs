using CityPulse.Application.Interfaces;
using CityPulse.Domain.Entities;
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
    public async Task<IReadOnlyList<City>> GetAll() => await _service.ListAsync();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<City>> Get(int id)
    {
        var city = await _service.GetAsync(id);
        return city is null ? NotFound() : Ok(city);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(City city)
    {
        var id = await _service.CreateAsync(city);
        return CreatedAtAction(nameof(Get), new { id }, id);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, City city)
    {
        if (id != city.Id) return BadRequest();
        await _service.UpdateAsync(city);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
