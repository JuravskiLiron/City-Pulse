using System.Linq;
using CityPulse.Application.Interfaces;
using CityPulse.Application.Models;
using CityPulse.Domain.Entities;

namespace CityPulse.Application.Services;

public class CityService : ICityService
{
    private readonly ICityRepository _repository;

    public CityService(ICityRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CityDto>> GetAllAsync()
    {
        var cities = await _repository.GetAllAsync();
        return cities.Select(c => new CityDto(c.Id, c.Name, c.Population));
    }

    public async Task<CityDto?> GetByIdAsync(int id)
    {
        var city = await _repository.GetByIdAsync(id);
        return city is null ? null : new CityDto(city.Id, city.Name, city.Population);
    }

    public async Task<CityDto> CreateAsync(CreateCityDto dto)
    {
        var city = new City { Name = dto.Name, Population = dto.Population };
        var created = await _repository.AddAsync(city);
        return new CityDto(created.Id, created.Name, created.Population);
    }

    public async Task UpdateAsync(int id, UpdateCityDto dto)
    {
        var city = await _repository.GetByIdAsync(id);
        if (city is null) return;
        city.Name = dto.Name;
        city.Population = dto.Population;
        await _repository.UpdateAsync(city);
    }

    public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
}
