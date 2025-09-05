# City-Pulse

This repository is organized into separate frontend and backend projects.

- **backend/** – ASP.NET Core backend following a Clean Architecture.
- **frontend/** – placeholder for the React frontend.

### Backend structure
The backend solution under `backend/` contains the following projects:

- **CityPulse.Domain** – domain entities.
- **CityPulse.Application** – application services and business logic.
- **CityPulse.Infrastructure** – infrastructure and data access configured for PostgreSQL using Entity Framework Core.
- **CityPulse.Api** – ASP.NET Core Web API project exposing the endpoints.

### Configuration
Update the connection string in `backend/CityPulse.Api/appsettings.json` (and the development variant) to point to your PostgreSQL database.

### Building
```
dotnet build backend/CityPulse.sln
```

### Running the API
```
dotnet run --project backend/CityPulse.Api
```

The API includes a sample `WeatherForecast` endpoint at `/api/WeatherForecast` and a health check at `/api/Health`.
