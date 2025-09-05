using CityPulse.Application.Interfaces;
using CityPulse.Application.Services;
using CityPulse.Domain.Entities;
using Moq;
using Xunit;

namespace CityPulse.Tests;

public class CityServiceTests
{
    [Fact]
    public async Task CreateAsync_ReturnsNewId()
    {
        var repo = new Mock<ICityRepository>();
        repo.Setup(r => r.AddAsync(It.IsAny<City>())).ReturnsAsync(1);
        var service = new CityService(repo.Object);

        var id = await service.CreateAsync(new City { Name = "Test" });

        Assert.Equal(1, id);
    }
}
