using CityPulse.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityPulse.Persistence;

public class CityPulseDbContext(DbContextOptions<CityPulseDbContext> options)
    : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}