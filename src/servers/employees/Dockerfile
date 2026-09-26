FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY src/servers/employees/Core/Garaj.Employees.Domain/*.csproj src/servers/employees/Core/Garaj.Employees.Domain/
COPY src/servers/employees/Core/Garaj.Employees.UseCases/*.csproj src/servers/employees/Core/Garaj.Employees.UseCases/

COPY src/servers/employees/Infra/Garaj.Employees.Caching/*.csproj src/servers/employees/Infra/Garaj.Employees.Caching/
COPY src/servers/employees/Infra/Garaj.Employees.Events/*.csproj src/servers/employees/Infra/Garaj.Employees.Events/
COPY src/servers/employees/Infra/Garaj.Employees.Persistense/*.csproj src/servers/employees/Infra/Garaj.Employees.Persistense/

COPY src/servers/employees/Presenters/Garaj.Employees.WebApi/*.csproj src/servers/employees/Presenters/Garaj.Employees.WebApi/

RUN dotnet restore src/servers/employees/Presenters/Garaj.Employees.WebApi/*.csproj

COPY src/servers/employees/ src/servers/employees/

WORKDIR /src/src/servers/employees/Presenters/Garaj.Employees.WebApi
RUN dotnet publish -c Release -o /app/publish --no-restore


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "Garaj.Employees.WebApi.dll"]