using CityPulse.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityPulse.Infrastructure.Persistence.Configurations;

public class WeatherForecastConfiguration : IEntityTypeConfiguration<WeatherForecast>
{
    public void Configure(EntityTypeBuilder<WeatherForecast> builder)
    {
        builder.HasKey(w => w.Id);
        builder.Property(w => w.Date).IsRequired();
    }
}
