namespace CityPulse.API.Contracts.Users;

public class ResetPasswordRequest
{
    public string PhoneNumber { get; set; }
    public string ResetCode { get; set; }
    public string NewPassword { get; set; }
}