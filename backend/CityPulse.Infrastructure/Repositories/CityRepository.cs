using CityPulse.Application.Interfaces;
using CityPulse.Domain.Entities;
using CityPulse.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CityPulse.Infrastructure.Repositories;

public class CityRepository : ICityRepository
{
    private readonly AppDbContext _db;

    public CityRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<City?> GetAsync(int id) =>
        await _db.Cities.FindAsync(id);

    public async Task<IReadOnlyList<City>> ListAsync() =>
        await _db.Cities.AsNoTracking().ToListAsync();

    public async Task<int> AddAsync(City city)
    {
        _db.Cities.Add(city);
        await _db.SaveChangesAsync();
        return city.Id;
    }

    public async Task UpdateAsync(City city)
    {
        _db.Cities.Update(city);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _db.Cities.FindAsync(id);
        if (entity is null) return;
        _db.Cities.Remove(entity);
        await _db.SaveChangesAsync();
    }
}
