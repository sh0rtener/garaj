FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY src/servers/orders/Core/Garaj.Orders.Domain/*.csproj src/servers/orders/Core/Garaj.Orders.Domain/
COPY src/servers/orders/Core/Garaj.Orders.UseCases/*.csproj src/servers/orders/Core/Garaj.Orders.UseCases/

COPY src/servers/orders/Infra/Garaj.Orders.Caching/*.csproj src/servers/orders/Infra/Garaj.Orders.Caching/
COPY src/servers/orders/Infra/Garaj.Orders.Events/*.csproj src/servers/orders/Infra/Garaj.Orders.Events/
COPY src/servers/orders/Infra/Garaj.Orders.Persistense/*.csproj src/servers/orders/Infra/Garaj.Orders.Persistense/

COPY src/servers/orders/Presenters/Garaj.Orders.WebApi/*.csproj src/servers/orders/Presenters/Garaj.Orders.WebApi/

RUN dotnet restore src/servers/orders/Presenters/Garaj.Orders.WebApi/*.csproj

COPY src/servers/orders/ src/servers/orders/

WORKDIR /src/src/servers/orders/Presenters/Garaj.Orders.WebApi
RUN dotnet publish -c Release -o /app/publish --no-restore


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "Garaj.Orders.WebApi.dll"]