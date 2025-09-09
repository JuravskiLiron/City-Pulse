using CityPulse.Domain.Models;

namespace CityPulse.Application.Interfaces.Repositories;

public interface IUsersRepository
{
    Task Add(User user);
    Task<User> GetByPhone(string phone);
    Task<bool> ExistsByPhoneNumber(string phoneNumber);
    Task Update(User user);
}