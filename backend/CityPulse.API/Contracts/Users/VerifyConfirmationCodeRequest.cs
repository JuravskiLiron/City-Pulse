using System.ComponentModel.DataAnnotations;

namespace CityPulse.API.Contracts.Users;

public record VerifyConfirmationCodeRequest
{
    [Required] [Phone] public string PhoneNumber { get; init; }
    [Required] public string ConfirmationCode { get; init; }
}