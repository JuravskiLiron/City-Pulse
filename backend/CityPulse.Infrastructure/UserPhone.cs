/*
using CityPulse.Application.Interfaces.Auth;
using CityPulse.Application.Services;

namespace CityPulse.Infrastructure;

public class UserPhone : IUserPhone
{
    
    
    public async bool VerifyPhoneNumber(string phoneNumber, string verificationCode)
    {
        var smsService = new SmsService();
        
        await smsService.SendSmsAsync(phoneNumber, verificationCode);
        
        return phoneNumber == verificationCode;
    }
}
*/