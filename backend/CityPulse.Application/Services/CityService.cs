using CityPulse.Application.Interfaces;
using CityPulse.Domain.Entities;

namespace CityPulse.Application.Services;

public class CityService : ICityService
{
    private readonly ICityRepository _repository;

    public CityService(ICityRepository repository)
    {
        _repository = repository;
    }

    public Task<City?> GetAsync(int id) => _repository.GetAsync(id);

    public Task<IReadOnlyList<City>> ListAsync() => _repository.ListAsync();

    public Task<int> CreateAsync(City city) => _repository.AddAsync(city);

    public Task UpdateAsync(City city) => _repository.UpdateAsync(city);

    public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
}
