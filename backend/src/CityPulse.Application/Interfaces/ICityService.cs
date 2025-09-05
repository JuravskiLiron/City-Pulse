using CityPulse.Application.Models;

namespace CityPulse.Application.Interfaces;

public interface ICityService
{
    Task<IEnumerable<CityDto>> GetAllAsync();
    Task<CityDto?> GetByIdAsync(int id);
    Task<CityDto> CreateAsync(CreateCityDto dto);
    Task UpdateAsync(int id, UpdateCityDto dto);
    Task DeleteAsync(int id);
}
