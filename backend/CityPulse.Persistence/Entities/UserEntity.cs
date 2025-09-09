namespace CityPulse.Persistence.Entities;

public class UserEntity
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;
}