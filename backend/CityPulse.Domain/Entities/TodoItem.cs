using CityPulse.Domain.Common;

namespace CityPulse.Domain.Entities;

public class TodoItem : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public bool IsCompleted { get; set; }
}
