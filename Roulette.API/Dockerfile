#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Roulette.API/Roulette.API.csproj", "Roulette.API/"]
COPY ["Roulette.Core/Roulette.Service.csproj", "Roulette.Core/"]
RUN dotnet restore "Roulette.API/Roulette.API.csproj"
COPY . .
WORKDIR "/src/Roulette.API"
RUN dotnet build "Roulette.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Roulette.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Roulette.API.dll"]