using CityPulse.Application.Interfaces;
using CityPulse.Domain.Entities;
using CityPulse.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CityPulse.Infrastructure.Repositories;

public class CityRepository : ICityRepository
{
    private readonly AppDbContext _context;

    public CityRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<City>> GetAllAsync() => await _context.Cities.ToListAsync();

    public async Task<City?> GetByIdAsync(int id) => await _context.Cities.FindAsync(id);

    public async Task<City> AddAsync(City city)
    {
        _context.Cities.Add(city);
        await _context.SaveChangesAsync();
        return city;
    }

    public async Task UpdateAsync(City city)
    {
        _context.Cities.Update(city);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var city = await _context.Cities.FindAsync(id);
        if (city is null) return;
        _context.Cities.Remove(city);
        await _context.SaveChangesAsync();
    }
}
