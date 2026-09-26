FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY src/servers/identity/Core/Garaj.Identity.Domain/*.csproj src/servers/identity/Core/Garaj.Identity.Domain/
COPY src/servers/identity/Core/Garaj.Identity.UseCases/*.csproj src/servers/identity/Core/Garaj.Identity.UseCases/

COPY src/servers/identity/Infra/Garaj.Identity.Caching/*.csproj src/servers/identity/Infra/Garaj.Identity.Caching/
COPY src/servers/identity/Infra/Garaj.Identity.Events/*.csproj src/servers/identity/Infra/Garaj.Identity.Events/
COPY src/servers/identity/Infra/Garaj.Identity.Persistense/*.csproj src/servers/identity/Infra/Garaj.Identity.Persistense/

COPY src/servers/identity/Presenters/Garaj.Identity.WebApi/*.csproj src/servers/identity/Presenters/Garaj.Identity.WebApi/

RUN dotnet restore src/servers/identity/Presenters/Garaj.Identity.WebApi/*.csproj

COPY src/servers/identity/ src/servers/identity/

WORKDIR /src/src/servers/identity/Presenters/Garaj.Identity.WebApi
RUN dotnet publish -c Release -o /app/publish --no-restore


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "Garaj.Identity.WebApi.dll"]