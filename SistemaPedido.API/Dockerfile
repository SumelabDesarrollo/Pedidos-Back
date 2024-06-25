FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SistemaPedido.API/SistemaPedido.API.csproj", "SistemaPedido.API/"]
COPY ["SistemaPedido.BLL/SistemaPedido.BLL.csproj", "SistemaPedido.BLL/"]
COPY ["SistemaPedido.DAL/SistemaPedido.DAL.csproj", "SistemaPedido.DAL/"]
COPY ["SistemaPedido.DTO/SistemaPedido.DTO.csproj", "SistemaPedido.DTO/"]
COPY ["SistemaPedido.IOC/SistemaPedido.IOC.csproj", "SistemaPedido.IOC/"]
COPY ["SistemaPedido.Model/SistemaPedido.Model.csproj", "SistemaPedido.Model/"]
COPY ["SistemaPedido.Utility/SistemaPedido.Utility.csproj", "SistemaPedido.Utility/"]
RUN dotnet restore "SistemaPedido.API/SistemaPedido.API.csproj"
COPY . .
WORKDIR "/src/SistemaPedido.API"
RUN dotnet build "SistemaPedido.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SistemaPedido.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SistemaPedido.API.dll"]
