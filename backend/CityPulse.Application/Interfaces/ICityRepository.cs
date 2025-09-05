using CityPulse.Domain.Entities;

namespace CityPulse.Application.Interfaces;

public interface ICityRepository
{
    Task<City?> GetAsync(int id);
    Task<IReadOnlyList<City>> ListAsync();
    Task<int> AddAsync(City city);
    Task UpdateAsync(City city);
    Task DeleteAsync(int id);
}
