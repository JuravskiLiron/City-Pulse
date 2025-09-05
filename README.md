# City-Pulse

This repository contains a backend skeleton built using ASP.NET Core following the principles of Clean Architecture. The solution is organized into separate layers:

- **CityPulse.Domain** – domain entities.
- **CityPulse.Application** – application services and business logic.
- **CityPulse.Infrastructure** – infrastructure and data access configured for PostgreSQL using Entity Framework Core.
- **CityPulse.Api** – ASP.NET Core Web API project exposing the endpoints.

## Configuration

Update the connection string in `src/CityPulse.Api/appsettings.json` to point to your PostgreSQL database.

## Building

```bash
dotnet build CityPulse.sln
```

## Running the API

```bash
dotnet run --project src/CityPulse.Api
```
