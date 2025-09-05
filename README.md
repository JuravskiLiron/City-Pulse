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
- **CityPulse.Tests** – xUnit test project with sample tests.

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

The API includes a sample `TodoItems` endpoint at `/api/TodoItems` and a health check at `/api/Health`.

### Running tests
```
dotnet test backend/CityPulse.sln
```

### Docker
A `docker-compose.yml` is available under `backend/` to launch the API along with a PostgreSQL instance:
```
docker compose up --build
```
