using CityPulse.Domain.Entities;

namespace CityPulse.Application.Interfaces;

public interface ITodoItemService
{
    Task<TodoItem?> GetAsync(int id);
    Task<IReadOnlyList<TodoItem>> ListAsync();
    Task<int> CreateAsync(TodoItem item);
    Task UpdateAsync(TodoItem item);
    Task DeleteAsync(int id);
}
