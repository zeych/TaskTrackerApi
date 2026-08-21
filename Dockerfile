
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["TaskTrackerApi.csproj", "./"]
RUN dotnet restore "./TaskTrackerApi.csproj"


COPY . .
WORKDIR "/src/."
RUN dotnet publish "TaskTrackerApi.csproj" -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .


ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 8080
ENTRYPOINT ["dotnet", "TaskTrackerApi.dll"]

HEALTHCHECK --interval=10s --timeout=5s --retries=3 CMD curl -f http://localhost:8080/health || exit 1
