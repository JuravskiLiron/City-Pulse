using System.ComponentModel.DataAnnotations;

namespace CityPulse.API.Contracts.Users;


public record LoginUserRequest(
    [Required] string Phone,
    [Required] string Password);