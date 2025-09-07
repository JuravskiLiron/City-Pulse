using CityPulse.Domain.Entities;

namespace CityPulse.Application.Interfaces;

public interface ITodoItemRepository
{
    Task<TodoItem?> GetAsync(int id);
    Task<IReadOnlyList<TodoItem>> ListAsync();
    Task<int> AddAsync(TodoItem item);
    Task UpdateAsync(TodoItem item);
    Task DeleteAsync(int id);
}
