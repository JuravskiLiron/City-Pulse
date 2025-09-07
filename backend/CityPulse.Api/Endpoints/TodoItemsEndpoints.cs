using CityPulse.Application.Interfaces;
using CityPulse.Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CityPulse.Api.Endpoints;

public static class TodoItemsEndpoints
{
    public static IEndpointRouteBuilder MapTodoItemEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/todoitems");

        group.MapGet("/", async (ITodoItemService service) =>
        {
            var items = await service.ListAsync();
            return Results.Ok(items);
        });

        group.MapGet("/{id:int}", async (int id, ITodoItemService service) =>
        {
            var item = await service.GetAsync(id);
            return item is not null ? Results.Ok(item) : Results.NotFound();
        });

        group.MapPost("/", async (TodoItem item, ITodoItemService service) =>
        {
            var id = await service.CreateAsync(item);
            return Results.Created($"/api/todoitems/{id}", item);
        });

        group.MapPut("/{id:int}", async (int id, TodoItem input, ITodoItemService service) =>
        {
            var existing = await service.GetAsync(id);
            if (existing is null) return Results.NotFound();
            existing.Title = input.Title;
            existing.IsCompleted = input.IsCompleted;
            await service.UpdateAsync(existing);
            return Results.NoContent();
        });

        group.MapDelete("/{id:int}", async (int id, ITodoItemService service) =>
        {
            var item = await service.GetAsync(id);
            if (item is null) return Results.NotFound();
            await service.DeleteAsync(id);
            return Results.NoContent();
        });

        return routes;
    }
}
