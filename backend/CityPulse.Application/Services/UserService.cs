using System.Collections.Concurrent;
using Microsoft.Extensions.Caching.Memory;
using CityPulse.Application.Interfaces.Auth;
using CityPulse.Application.Interfaces.Repositories;
using CityPulse.Domain.Models;

namespace CityPulse.Application.Services;

public class UserService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;
    private readonly IMemoryCache _cache;

    // Хранение кодов подтверждения и статуса подтверждения
    private static readonly ConcurrentDictionary<string, string> _confirmationCodes = new();
    private static readonly ConcurrentDictionary<string, bool> _confirmedPhones = new();

    public UserService(
        IUsersRepository usersRepository,
        IPasswordHasher passwordHasher,
        IJwtProvider jwtProvider,
        IMemoryCache cache)
    {
        _usersRepository = usersRepository;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
        _cache = cache;
    }

    public string GenerateConfirmationCode(string phoneNumber)
    {
        var random = new Random();
        var code = random.Next(1000, 9999).ToString();
        _confirmationCodes[phoneNumber] = code;
        return code;
    }

    public bool VerifyConfirmationCode(string phoneNumber, string code)
    {
        return _confirmationCodes.TryGetValue(phoneNumber, out var storedCode) && storedCode == code;
    }

    public void MarkPhoneAsConfirmed(string phoneNumber)
    {
        _confirmedPhones[phoneNumber] = true;
    }

    public bool IsPhoneConfirmed(string phoneNumber)
    {
        return _confirmedPhones.TryGetValue(phoneNumber, out var confirmed) && confirmed;
    }

    public async Task Register(string userNickName, string password, string userFullName, string phoneNumber)
    {
        var hashedPassword = _passwordHasher.Generate(password);

        var user = User.Create(
            Guid.NewGuid(),
            userNickName,
            hashedPassword,
            userFullName,
            phoneNumber
        );

        await _usersRepository.Add(user);
    }

    public async Task<string> Login(string phone, string password)
    {
        var user = await _usersRepository.GetByPhone(phone);
        var result = _passwordHasher.Verify(password, user.PasswordHash);

        if (!result)
        {
            throw new Exception("Failed to login");
        }

        return _jwtProvider.Generate(user);
    }

    public Task<bool> IsPhoneNumberTaken(string phoneNumber)
    {
        return _usersRepository.ExistsByPhoneNumber(phoneNumber);
    }
    
    public string GenerateResetPasswordCode(string phoneNumber)
    {
        var code = GenerateConfirmationCode(phoneNumber); 
        _cache.Set($"reset_{phoneNumber}", code, TimeSpan.FromMinutes(10));
        return code;
    }
    
    public bool VerifyResetPasswordCode(string phoneNumber, string resetCode)
    {
        if (_cache.TryGetValue($"reset_{phoneNumber}", out string storedCode))
        {
            return storedCode == resetCode;
        }
        return false;
    }
    
    public async Task UpdatePassword(string phoneNumber, string newPassword)
    {
        var user = await _usersRepository.GetByPhone(phoneNumber);
        user.PasswordHash = HashPassword(newPassword);
        await _usersRepository.Update(user);
    }
    
    private string HashPassword(string password)
    {
        return _passwordHasher.Generate(password);
    }


}
