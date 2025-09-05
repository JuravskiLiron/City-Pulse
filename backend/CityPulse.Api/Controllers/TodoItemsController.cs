using CityPulse.Application.Interfaces;
using CityPulse.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CityPulse.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoItemsController : ControllerBase
{
    private readonly ITodoItemService _service;

    public TodoItemsController(ITodoItemService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IReadOnlyList<TodoItem>> GetAll() => await _service.ListAsync();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TodoItem>> Get(int id)
    {
        var item = await _service.GetAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(TodoItem item)
    {
        var id = await _service.CreateAsync(item);
        return CreatedAtAction(nameof(Get), new { id }, id);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, TodoItem item)
    {
        if (id != item.Id) return BadRequest();
        await _service.UpdateAsync(item);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}
