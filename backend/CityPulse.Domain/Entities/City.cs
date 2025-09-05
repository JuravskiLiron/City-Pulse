using CityPulse.Domain.Common;

namespace CityPulse.Domain.Entities;

public class City : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public int Population { get; set; }
}
