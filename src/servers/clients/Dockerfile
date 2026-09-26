FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY src/servers/clients/Core/Garaj.Clients.Domain/*.csproj src/servers/clients/Core/Garaj.Clients.Domain/
COPY src/servers/clients/Core/Garaj.Clients.UseCases/*.csproj src/servers/clients/Core/Garaj.Clients.UseCases/

COPY src/servers/clients/Infra/Garaj.Clients.Caching/*.csproj src/servers/clients/Infra/Garaj.Clients.Caching/
COPY src/servers/clients/Infra/Garaj.Clients.Events/*.csproj src/servers/clients/Infra/Garaj.Clients.Events/
COPY src/servers/clients/Infra/Garaj.Clients.Persistense/*.csproj src/servers/clients/Infra/Garaj.Clients.Persistense/

COPY src/servers/clients/Presenters/Garaj.Clients.WebApi/*.csproj src/servers/clients/Presenters/Garaj.Clients.WebApi/

RUN dotnet restore src/servers/clients/Presenters/Garaj.Clients.WebApi/*.csproj

COPY src/servers/clients/ src/servers/clients/

WORKDIR /src/src/servers/clients/Presenters/Garaj.Clients.WebApi
RUN dotnet publish -c Release -o /app/publish --no-restore


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "Garaj.Clients.WebApi.dll"]