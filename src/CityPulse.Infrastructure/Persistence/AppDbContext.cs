using Microsoft.EntityFrameworkCore;

namespace CityPulse.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    // TODO: Add DbSet properties for your entities
}
