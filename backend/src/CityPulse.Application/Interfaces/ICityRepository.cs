using CityPulse.Domain.Entities;

namespace CityPulse.Application.Interfaces;

public interface ICityRepository
{
    Task<IEnumerable<City>> GetAllAsync();
    Task<City?> GetByIdAsync(int id);
    Task<City> AddAsync(City city);
    Task UpdateAsync(City city);
    Task DeleteAsync(int id);
}
