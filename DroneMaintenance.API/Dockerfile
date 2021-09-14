#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["DroneMaintenance.API/DroneMaintenance.API.csproj", "DroneMaintenance.API/"]
COPY ["DroneMaintenance.BLL/DroneMaintenance.BLL.csproj", "DroneMaintenance.BLL/"]
COPY ["DroneMaintenance.Models/DroneMaintenance.Models.csproj", "DroneMaintenance.Models/"]
COPY ["DroneMaintenance.DAL/DroneMaintenance.DAL.csproj", "DroneMaintenance.DAL/"]
RUN dotnet restore "DroneMaintenance.API/DroneMaintenance.API.csproj"
COPY . .
WORKDIR "/src/DroneMaintenance.API"
RUN dotnet build "DroneMaintenance.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DroneMaintenance.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DroneMaintenance.API.dll"]
