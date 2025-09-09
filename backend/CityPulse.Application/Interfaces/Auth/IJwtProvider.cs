using CityPulse.Domain.Models;

namespace CityPulse.Application.Interfaces.Auth;

public interface IJwtProvider
{
    string Generate(User user);
}