FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY src/servers/finances/Core/Garaj.Finances.Domain/*.csproj src/servers/finances/Core/Garaj.Finances.Domain/
COPY src/servers/finances/Core/Garaj.Finances.UseCases/*.csproj src/servers/finances/Core/Garaj.Finances.UseCases/

COPY src/servers/finances/Infra/Garaj.Finances.Caching/*.csproj src/servers/finances/Infra/Garaj.Finances.Caching/
COPY src/servers/finances/Infra/Garaj.Finances.Events/*.csproj src/servers/finances/Infra/Garaj.Finances.Events/
COPY src/servers/finances/Infra/Garaj.Finances.Persistense/*.csproj src/servers/finances/Infra/Garaj.Finances.Persistense/

COPY src/servers/finances/Presenters/Garaj.Finances.WebApi/*.csproj src/servers/finances/Presenters/Garaj.Finances.WebApi/

RUN dotnet restore src/servers/finances/Presenters/Garaj.Finances.WebApi/*.csproj

COPY src/servers/finances/ src/servers/finances/

WORKDIR /src/src/servers/finances/Presenters/Garaj.Finances.WebApi
RUN dotnet publish -c Release -o /app/publish --no-restore


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "Garaj.Finances.WebApi.dll"]