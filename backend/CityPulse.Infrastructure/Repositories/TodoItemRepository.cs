using CityPulse.Application.Interfaces;
using CityPulse.Domain.Entities;
using CityPulse.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CityPulse.Infrastructure.Repositories;

public class TodoItemRepository : ITodoItemRepository
{
    private readonly AppDbContext _db;

    public TodoItemRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<TodoItem?> GetAsync(int id) =>
        await _db.TodoItems.FindAsync(id);

    public async Task<IReadOnlyList<TodoItem>> ListAsync() =>
        await _db.TodoItems.AsNoTracking().ToListAsync();

    public async Task<int> AddAsync(TodoItem item)
    {
        _db.TodoItems.Add(item);
        await _db.SaveChangesAsync();
        return item.Id;
    }

    public async Task UpdateAsync(TodoItem item)
    {
        _db.TodoItems.Update(item);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _db.TodoItems.FindAsync(id);
        if (entity is null) return;
        _db.TodoItems.Remove(entity);
        await _db.SaveChangesAsync();
    }
}
