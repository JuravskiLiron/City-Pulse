FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CityPulse.API/CityPulse.API.csproj", "CityPulse.API/"]
COPY ["CityPulse.Application/CityPulse.Application.csproj", "CityPulse.Application/"]
COPY ["CityPulse.Domain/CityPulse.Domain.csproj", "CityPulse.Domain/"]
COPY ["CityPulse.Persistence/CityPulse.Persistence.csproj", "CityPulse.Persistence/"]
COPY ["CityPulse.Infrastructure/CityPulse.Infrastructure.csproj", "CityPulse.Infrastructure/"]
RUN dotnet restore "CityPulse.API/CityPulse.API.csproj"
COPY . .
WORKDIR "/src/CityPulse.API"
RUN dotnet build "CityPulse.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CityPulse.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CityPulse.API.dll"]
