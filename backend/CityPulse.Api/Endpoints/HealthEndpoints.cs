using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CityPulse.Api.Endpoints;

public static class HealthEndpoints
{
    public static IEndpointRouteBuilder MapHealthEndpoints(this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/health", () => Results.Ok(new { status = "Healthy" }));
        return routes;
    }
}
