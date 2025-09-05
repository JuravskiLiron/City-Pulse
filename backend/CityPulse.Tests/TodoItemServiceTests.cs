using CityPulse.Application.Interfaces;
using CityPulse.Application.Services;
using CityPulse.Domain.Entities;
using Moq;
using Xunit;

namespace CityPulse.Tests;

public class TodoItemServiceTests
{
    [Fact]
    public async Task CreateAsync_ReturnsNewId()
    {
        var repo = new Mock<ITodoItemRepository>();
        repo.Setup(r => r.AddAsync(It.IsAny<TodoItem>())).ReturnsAsync(1);
        var service = new TodoItemService(repo.Object);

        var id = await service.CreateAsync(new TodoItem { Title = "Test" });

        Assert.Equal(1, id);
    }
}
