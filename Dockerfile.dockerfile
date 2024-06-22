# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY SistemaPedido.API/*.csproj ./SistemaPedido.API/
COPY SistemaPedido.BLL/*.csproj ./SistemaPedido.BLL/
COPY SistemaPedido.DAL/*.csproj ./SistemaPedido.DAL/
COPY SistemaPedido.DTO/*.csproj ./SistemaPedido.DTO/
COPY SistemaPedido.IOC/*.csproj ./SistemaPedido.IOC/
COPY SistemaPedido.Model/*.csproj ./SistemaPedido.Model/
COPY SistemaPedido.Utility/*.csproj ./SistemaPedido.Utility/

RUN dotnet restore

# Copy everything else and build
COPY . .
WORKDIR /app/SistemaPedido.API
RUN dotnet publish -c Release -o out

# Use the official .NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/SistemaPedido.API/out .
ENTRYPOINT ["dotnet", "SistemaPedido.API.dll"]