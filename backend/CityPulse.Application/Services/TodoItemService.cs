using CityPulse.Application.Interfaces;
using CityPulse.Domain.Entities;

namespace CityPulse.Application.Services;

public class TodoItemService : ITodoItemService
{
    private readonly ITodoItemRepository _repository;

    public TodoItemService(ITodoItemRepository repository)
    {
        _repository = repository;
    }

    public Task<TodoItem?> GetAsync(int id) => _repository.GetAsync(id);
    public Task<IReadOnlyList<TodoItem>> ListAsync() => _repository.ListAsync();
    public Task<int> CreateAsync(TodoItem item) => _repository.AddAsync(item);
    public Task UpdateAsync(TodoItem item) => _repository.UpdateAsync(item);
    public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
}
