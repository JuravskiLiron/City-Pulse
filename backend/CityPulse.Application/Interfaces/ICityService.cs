using CityPulse.Domain.Entities;

namespace CityPulse.Application.Interfaces;

public interface ICityService
{
    Task<City?> GetAsync(int id);
    Task<IReadOnlyList<City>> ListAsync();
    Task<int> CreateAsync(City city);
    Task UpdateAsync(City city);
    Task DeleteAsync(int id);
}
