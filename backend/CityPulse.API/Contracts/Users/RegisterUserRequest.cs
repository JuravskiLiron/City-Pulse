using System.ComponentModel.DataAnnotations;

namespace CityPulse.API.Contracts.Users;

public record RegisterUserRequest(
    
    [Required] [Phone] string PhoneNumber,
    [Required] string UserNickName,
    [Required] string UserFullName,
    [Required] string Password
    
    );